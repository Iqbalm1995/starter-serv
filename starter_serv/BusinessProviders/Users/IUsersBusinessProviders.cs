using starter_serv.Model;
using starter_serv.ViewModel;
using starter_serv.ViewModel.Users;

namespace starter_serv.BusinessProviders
{
    public interface IUsersBusinessProviders
    {
        public Task<ResponseViewModel<UsersViewModel>> List(string? search, int limit, int page);
        public Task<ResponseOneDataViewModel<UsersViewModel>> GetById(int id);
        public Task<ResponseViewModel<UsersViewModel>> GetList(RequestPagedFilterModel request);
        public Task<ResponseOneDataViewModel<UsersViewModel>> UpdateAvatar(int UserId, IFormFile FileUpload);
    }
}
