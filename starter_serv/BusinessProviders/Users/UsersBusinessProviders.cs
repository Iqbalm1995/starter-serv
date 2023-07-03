using AutoMapper;
using starter_serv.Constant;
using starter_serv.DataProviders;
using starter_serv.Helper;
using starter_serv.Model;
using starter_serv.Models;
using starter_serv.ViewModel;
using starter_serv.ViewModel.Users;
using System.Diagnostics.CodeAnalysis;

namespace starter_serv.BusinessProviders
{
    public class UsersBusinessProviders : IUsersBusinessProviders
    {
        private readonly IUsersDataProvider _UsersDataProvider;
        private readonly IAuthenticateBusinessProviders _AuthenticateBusinessProviders;
        private readonly IMapper _mapper;

        [ExcludeFromCodeCoverage]
        public UsersBusinessProviders(
            IUsersDataProvider usersDataProvider, 
            IAuthenticateBusinessProviders authenticateBusinessProviders,
            IMapper mapper)
        {
            _UsersDataProvider = usersDataProvider ?? throw new ArgumentNullException(nameof(usersDataProvider));
            _AuthenticateBusinessProviders = authenticateBusinessProviders ?? throw new ArgumentNullException(nameof(authenticateBusinessProviders));
            _mapper = mapper;
        }

        public async Task<ResponseViewModel<UsersViewModel>> List(string? search, int limit, int page)
        {
            BasePagination pagination = new BasePagination(page, limit);
            ResponseViewModel<UsersViewModel> result = new ResponseViewModel<UsersViewModel>();

            List<UsrUser> getData = await _UsersDataProvider.List(search, limit, pagination.CalculateOffset());
            int countAll = await _UsersDataProvider.CountFilter(search);

            if (!getData.Any())
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_NOT_FOUND;
                result.Message = ApplicationConstant.STATUS_MSG_NOT_FOUND;
            }
            else
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_OK;
                result.Message = ApplicationConstant.STATUS_MSG_OK;
                result.Data = _mapper.Map<List<UsersViewModel>>(getData);
            }

            result.Count = getData.Count();
            result.CountTotal = countAll;

            return result;

        }

        public async Task<ResponseOneDataViewModel<UsersViewModel>> GetById(int id)
        {
            ResponseOneDataViewModel<UsersViewModel> result = new ResponseOneDataViewModel<UsersViewModel>();

            var getData = await _UsersDataProvider.GetById(id);

            if (getData == null)
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_NOT_FOUND;
                result.Message = ApplicationConstant.STATUS_MSG_NOT_FOUND;
            }
            else
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_OK;
                result.Message = ApplicationConstant.STATUS_MSG_OK;
                result.Data = _mapper.Map<UsersViewModel>(getData);
            }

            return result;

        }

        public async Task<ResponseViewModel<UsersViewModel>> GetList(RequestPagedFilterModel request)
        {
            BasePagination pagination = new BasePagination(request.page, request.limit);
            ResponseViewModel<UsersViewModel> result = new ResponseViewModel<UsersViewModel>();

            QueryPagedFilterModel QueryFilter = new QueryPagedFilterModel()
            {
                search = request.search,
                limit = request.limit,
                page = pagination.CalculateOffset(),
                FilterWhere = request.FilterWhere,
                FieldOrder = request.FieldOrder,
                OrderDir = request.OrderDir
            };

            ListPagedResults<UsrUser> getData = await _UsersDataProvider.QueryPagedList(QueryFilter);

            if (!getData.Data.Any())
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_NOT_FOUND;
                result.Message = ApplicationConstant.STATUS_MSG_NOT_FOUND;
            }
            else
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_OK;
                result.Message = ApplicationConstant.STATUS_MSG_OK;
                result.Data = _mapper.Map<List<UsersViewModel>>(getData.Data);

            }

            result.Count = getData.Count;
            result.CountTotal = getData.CountTotal;

            return result;
        }

        public async Task<ResponseOneDataViewModel<UsersViewModel>> UpdateAvatar(int UserId, IFormFile FileUpload)
        {
            ResponseOneDataViewModel<UsersViewModel> result = new ResponseOneDataViewModel<UsersViewModel>();

            UserCliamTokenViewModel userCliamTokenViewModel = _AuthenticateBusinessProviders.GetUserClaimToken();

            result.StatusCode = ApplicationConstant.STATUS_CODE_OK;
            result.Message = ApplicationConstant.STATUS_MSG_OK;

            // validation user id
            int CurrentUserID = userCliamTokenViewModel.Id != null ? int.Parse(userCliamTokenViewModel.Id) : 0;
            var CheckCurrentUserID = await _UsersDataProvider.GetById(CurrentUserID);
            if (CheckCurrentUserID == null)
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_BAD_REQUEST;
                result.Message = $"Login User ID {userCliamTokenViewModel.Id} is invalid";

                return result;
            }

            // get user ID
            var getUser = await _UsersDataProvider.GetById(UserId);
            if (getUser == null)
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_BAD_REQUEST;
                result.Message = $"User ID {userCliamTokenViewModel.Id} is invalid";

                return result;
            }

            FileUploadOptions uploadOptions = new FileUploadOptions();

            var fileSize = FileUpload.Length;
            var extension = "." + FileUpload.FileName.Split('.')[FileUpload.FileName.Split('.').Length - 1];
            if (!uploadOptions.AllowedUploadTypesImageOnly.Contains(extension))
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_BAD_REQUEST;
                result.Message = $"File extension {extension} is not allowed";

                return result;
            }

            if (fileSize >= uploadOptions.MaxFileSize)
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_BAD_REQUEST;
                result.Message = $"File upload size is too large";

                return result;
            }

            var SaveFileUploadName = await _UsersDataProvider.AvatarWriteFile(FileUpload);

            //getUser.Avatar = SaveFileUploadName;
            getUser.UpdatedAt = DateTimeHelper.GetCurrentDateTime();

            var SaveData = await _UsersDataProvider.Update(getUser);

            if (SaveData.Status == false)
            {
                result.StatusCode = ApplicationConstant.STATUS_CODE_BAD_REQUEST;
                result.Message = SaveData.ExMessage;

                return result;
            }

            var outputData = _mapper.Map<UsersViewModel>(getUser);

            result.Data = outputData;

            return result;
        }
    }
}
