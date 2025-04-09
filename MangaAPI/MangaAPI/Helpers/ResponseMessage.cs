namespace MangaAPI.Helpers
{
    public class ResponseMessage
    {
        //Success
        public const string SUCCESSFUL = "Successful";
        public const string CREATE_SUCCESSFUL = "Create Successful";
        public const string UPDATE_SUCCESSFUL = "Update Successful";
        public const string DELETE_SUCCESSFUL = "Delete Successful";

        //Fail
        public const string FAILED = "Failed";
        public const string CREATE_FAILED = "Create Failed";
        public const string UPDATE_FAILED = "Update Failed";
        public const string DELETE_FAILED = "Delete Failed";

        //Error
        public const string EMPTY = "Empty Data";
        public const string NOT_FOUND = "Not Found";
        public const string DATA_NOT_FOUND = "Data Not Found";
        public const string DUPLICATE_KEY = "Duplicate Key";
        public const string REFERENCE_ERROR = "Reference Error";
        public const string NAME_EXISTS = "Name Already Exists";
        public const string NOT_PERMISION = "Not Permision";
    }
}
