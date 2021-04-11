namespace BookApi
{
    public class Global
    {
        public static string emailUser = null;
        public static string localization = "ID";

        public const string AdminRole = "ADMIN";
        public const string StaffRole = "STAFF";
        public const string MemberRole = "MEMBER";

        public readonly string[] Roles = {
            AdminRole,
            StaffRole,
            MemberRole
        };

        // Permissions
        
        public const string GetBook = "GET_BOOK";
        public const string DeleteBook = "DELETE_BOOK";
        public const string CreateBook = "DELETE_BOOK";
        public const string UpdateBook = "UPDATE_BOOK";

        public const string GetAuthor = "GET_AUTHOR";
        public const string DeleteAuthor = "DELETE_AUTHOR";
        public const string CreateAuthor = "DELETE_AUTHOR";
        public const string UpdateAuthor = "UPDATE_AUTHOR";

        public const string GetUser = "GET_USER";
        public const string DeleteUser = "DELETE_USER";
        public const string CreateUser = "DELETE_USER";
        public const string UpdateUser = "UPDATE_USER";

        public const string GetUserRole = "GET_USER_ROLE";
        public const string DeleteUserRole = "DELETE_USER_ROLE";
        public const string CreateUserRole = "DELETE_USER_ROLE";
        public const string UpdateUserRole = "UPDATE_USER_ROLE";

        public const string GetURolePermission = "GET_ROLE_PERMISSION";
        public const string DeleteURolePermission = "DELETE_ROLE_PERMISSION";
        public const string CreateURolePermission = "DELETE_ROLE_PERMISSION";
        public const string UpdateURolePermission = "UPDATE_ROLE_PERMISSION";

        public const string GetPermission = "GET_PERMISSION";
        public const string GetRole = "GET_ROLE";

        public readonly string[] Permissions = {
            GetAuthor,
            DeleteAuthor,
            CreateAuthor,
            UpdateAuthor
        };
    }
}