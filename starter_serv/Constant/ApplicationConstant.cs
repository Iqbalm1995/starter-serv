namespace starter_serv.Constant
{
    public class ApplicationConstant
    {
        // timezone
        public const double TIMEZONE_JKT = +7;

        // res status code
        public const int STATUS_CODE_OK = 200;
        public const int STATUS_CODE_NOT_FOUND = 404;
        public const int STATUS_CODE_BAD_REQUEST = 400;
        public const int STATUS_CODE_ERROR = 500;

        // res status message
        public const string STATUS_MSG_OK = "Ok";
        public const string STATUS_MSG_SUCCESS = "Success";
        public const string STATUS_MSG_CREATED = "Created";
        public const string STATUS_MSG_NOT_FOUND = "Not Found";
        public const string STATUS_MSG_BAD_REQUEST = "Bad Request";
        public const string STATUS_MSG_ERROR = "Internal Server Error";
        public const string STATUS_MSG_SUCCESS_DELETED = "Data Is Deleted";

        // custom res status message
        public const string STATUS_MSG_USERNAME_IS_USED = "Username Is Already In Use";
        public const string STATUS_MSG_PASSWORD_IS_NOT_SAME = "Password and password confirmation is not same";


        // enum delete
        public const string DELETED = "1";
        public const string UNDELETED = "0";

        // enum project status
        // 1=Open,2=InProgress,3=OnHold,4=Cancel,5=Completed

        public const int PROJECT_STATUS_CODE_OPEN = 1;
        public const int PROJECT_STATUS_CODE_IN_PROGRESS = 2;
        public const int PROJECT_STATUS_CODE_ON_HOLD = 3;
        public const int PROJECT_STATUS_CODE_CANCEL = 4;
        public const int PROJECT_STATUS_CODE_COMPLETED = 5;

        // enum task status
        // 1=Open,2=In Progress,3=On Hold,4=Waiting For Some one,5=Cancel,6=Completed

        public const int TASK_STATUS_CODE_OPEN = 1;
        public const int TASK_STATUS_CODE_IN_PROGRESS = 2;
        public const int TASK_STATUS_CODE_ON_HOLD = 3;
        public const int TASK_STATUS_CODE_WAITING = 4;
        public const int TASK_STATUS_CODE_CANCEL = 5;
        public const int TASK_STATUS_CODE_COMPLETED = 6;

        // enum task approval status
        // 0=Not Submitted,1=Submitted,2=Approved,3=Declined

        public const int TASK_APPROVAL_STATUS_NOT_SUBMITTED = 0;
        public const int TASK_APPROVAL_STATUS_SUBMITTED = 1;
        public const int TASK_APPROVAL_STATUS_APPROVED = 2;
        public const int TASK_APPROVAL_STATUS_DECLINED = 3;

        // label startdate/enddate for parameter

        public const string LABEL_PARAM_STARTDATE = "startdate";
        public const string LABEL_PARAM_ENDDATE = "endate";

        // role admin constant
        public const int ROLE_ID_ADMIN = 1;
        public const string ROLE_LABEL_ADMIN = "admin";

        // division cmo constant
        public const int DEPARTMENT_ID_CMO = 6;
        public const string DEPARTMENT_LABEL_CMO = "Divisi Change Management Office";


        // project kategori
        public const string PROJECT_KATEGORI_CARRY_OVER = "Carry-Over";
        public const string PROJECT_KATEGORI_MULTIYEARS = "Multiyears";
        public const string PROJECT_KATEGORI_TAHUN_BERJALAN = "Tahun Berjalan";


        // task phase
        public const int TASK_PHASE_INITIATING = 1;
        public const int TASK_PHASE_PLANNING = 2;
        public const int TASK_PHASE_EXECUTING = 3;
        public const int TASK_PHASE_MONITORING_AND_CONTROLLING = 4;
        public const int TASK_PHASE_CLOSING = 5;

        // inisiatif strategis project
        public const int PROJECT_INISIATIF_STRATEGIS = 1;
        public const int PROJECT_INISIATIF_NON_STRATEGIS = 0;

        // rppb project
        public const int PROJECT_INISIATIF_STRATEGIS_RPPB = 1;
        public const int PROJECT_INISIATIF_STRATEGIS_NON_RPPB = 0;
        public const int PROJECT_INISIATIF_NON_STRATEGIS_RPPB = 2;

        // transformasi digital project
        public const int PROJECT_TRANSFORMASI_DIGITAL_YES = 1;
        public const int PROJECT_TRANSFORMASI_DIGITAL_NO = 0;

    }
}
