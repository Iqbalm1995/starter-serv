using starter_serv.Constant;

namespace starter_serv.Helper
{
    public class StatusHelper
    {
        public static string getStatusProjectDetail(string statusProject)
        {
            string result = "";

            if (statusProject == ApplicationConstant.PROJECT_STATUS_CODE_OPEN.ToString())
            {
                result = "Not Started";
                return result;
            }

            if (statusProject == ApplicationConstant.PROJECT_STATUS_CODE_IN_PROGRESS.ToString())
            {
                result = "On Schedule";
                return result;
            }

            if (statusProject == ApplicationConstant.PROJECT_STATUS_CODE_ON_HOLD.ToString())
            {
                result = "Delay";
                return result;
            }

            if (statusProject == ApplicationConstant.PROJECT_STATUS_CODE_CANCEL.ToString())
            {
                result = "Drop Out";
                return result;
            }

            if (statusProject == ApplicationConstant.PROJECT_STATUS_CODE_COMPLETED.ToString())
            {
                result = "Done";
                return result;
            }

            return result;
        }

        public static string getStatusTaskDetail(string statusTask)
        {
            string result = "";

            if (statusTask == ApplicationConstant.TASK_STATUS_CODE_OPEN.ToString())
            {
                result = "Not Started";
                return result;
            }

            if (statusTask == ApplicationConstant.TASK_STATUS_CODE_IN_PROGRESS.ToString())
            {
                result = "On Schedule";
                return result;
            }

            if (statusTask == ApplicationConstant.TASK_STATUS_CODE_ON_HOLD.ToString())
            {
                result = "Delay";
                return result;
            }

            if (statusTask == ApplicationConstant.TASK_STATUS_CODE_CANCEL.ToString())
            {
                result = "Drop Out";
                return result;
            }

            if (statusTask == ApplicationConstant.TASK_STATUS_CODE_COMPLETED.ToString())
            {
                result = "Done";
                return result;
            }

            return result;
        }

        public static string getPhaseTaskDetail(string phaseTask)
        {
            string result = "";

            if (phaseTask == ApplicationConstant.TASK_PHASE_INITIATING.ToString())
            {
                result = "Initiating";
                return result;
            }

            if (phaseTask == ApplicationConstant.TASK_PHASE_PLANNING.ToString())
            {
                result = "Planning";
                return result;
            }

            if (phaseTask == ApplicationConstant.TASK_PHASE_EXECUTING.ToString())
            {
                result = "Executing";
                return result;
            }

            if (phaseTask == ApplicationConstant.TASK_PHASE_MONITORING_AND_CONTROLLING.ToString())
            {
                result = "Monitoring & Controlling";
                return result;
            }

            if (phaseTask == ApplicationConstant.TASK_PHASE_CLOSING.ToString())
            {
                result = "Closing";
                return result;
            }

            return result;
        }

        public static string getApprovalStatusTaskDetail(string approvalStatus)
        {
            string result = "";

            if (approvalStatus == ApplicationConstant.TASK_APPROVAL_STATUS_NOT_SUBMITTED.ToString())
            {
                result = "Not Submited";
                return result;
            }

            if (approvalStatus == ApplicationConstant.TASK_APPROVAL_STATUS_SUBMITTED.ToString())
            {
                result = "Submitting";
                return result;
            }

            if (approvalStatus == ApplicationConstant.TASK_APPROVAL_STATUS_APPROVED.ToString())
            {
                result = "Approved";
                return result;
            }

            if (approvalStatus == ApplicationConstant.TASK_APPROVAL_STATUS_DECLINED.ToString())
            {
                result = "Rejected";
                return result;
            }

            return result;
        }

        public static string getProjectInitStrategisDetail(string code)
        {
            string result = "";

            if (code == ApplicationConstant.PROJECT_INISIATIF_STRATEGIS.ToString())
            {
                result = "Inisiatif Strategis";
                return result;
            }

            if (code == ApplicationConstant.PROJECT_INISIATIF_NON_STRATEGIS.ToString())
            {
                result = "Inisiatif Non Strategis";
                return result;
            }

            return result;
        }

        public static string getProjectRPPBDetail(string code)
        {
            string result = "";

            if (code == ApplicationConstant.PROJECT_INISIATIF_STRATEGIS_RPPB.ToString())
            {
                result = "Inisiatif Strategis - RPPB";
                return result;
            }

            if (code == ApplicationConstant.PROJECT_INISIATIF_STRATEGIS_NON_RPPB.ToString())
            {
                result = "Inisiatif Strategis - Non RPPB";
                return result;
            }

            if (code == ApplicationConstant.PROJECT_INISIATIF_NON_STRATEGIS_RPPB.ToString())
            {
                result = "Inisiatif Non Strategis";
                return result;
            }

            return result;
        }

        public static string getProjectTransformDigitalDetail(string code)
        {
            string result = "";

            if (code == ApplicationConstant.PROJECT_TRANSFORMASI_DIGITAL_YES.ToString())
            {
                result = "Yes";
                return result;
            }

            if (code == ApplicationConstant.PROJECT_TRANSFORMASI_DIGITAL_NO.ToString())
            {
                result = "No";
                return result;
            }

            return result;
        }
    }
}
