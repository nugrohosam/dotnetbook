using System;

namespace BookApi
{
    public class Global
    {
        // Role

        public static long UserId { get; set; }
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
        public const string CreateBook = "CREATE_BOOK";
        public const string UpdateBook = "UPDATE_BOOK";

        public const string GetAuthor = "GET_AUTHOR";
        public const string DeleteAuthor = "DELETE_AUTHOR";
        public const string CreateAuthor = "CREATE_AUTHOR";
        public const string UpdateAuthor = "UPDATE_AUTHOR";

        public const string GetUser = "GET_USER";
        public const string DeleteUser = "DELETE_USER";
        public const string UpdateUser = "UPDATE_USER";

        public const string GetUserRole = "GET_USER_ROLE";
        public const string DeleteUserRole = "DELETE_USER_ROLE";
        public const string CreateUserRole = "CREATE_USER_ROLE";
        public const string UpdateUserRole = "UPDATE_USER_ROLE";

        public const string GetRolePermission = "GET_ROLE_PERMISSION";
        public const string DeleteRolePermission = "DELETE_ROLE_PERMISSION";
        public const string CreateRolePermission = "CREATE_ROLE_PERMISSION";
        public const string UpdateRolePermission = "UPDATE_ROLE_PERMISSION";

        public const string GetPermission = "GET_PERMISSION";
        public const string GetRole = "GET_ROLE";

        public readonly string[] Permissions = {
            GetAuthor,
            DeleteAuthor,
            CreateAuthor,
            UpdateAuthor,
            GetBook,
            DeleteBook,
            CreateBook,
            UpdateBook,
            GetUser,
            DeleteUser,
            UpdateUser,
            GetUserRole,
            DeleteUserRole,
            CreateUserRole,
            UpdateUserRole,
            GetRolePermission,
            DeleteRolePermission,
            CreateRolePermission,
            UpdateRolePermission,
            GetPermission,
            GetRole
        };

        // Route

        public const string separatorRoutePermission = "->";

        public const string RouteListBook = "ROUTE_GET_LIST_BOOK" + separatorRoutePermission + GetBook;
        public const string RouteDetailBook = "ROUTE_GET_BOOK" + separatorRoutePermission + GetBook;
        public const string RouteUpdateBook = "ROUTE_UPDATE_BOOK" + separatorRoutePermission + UpdateBook;
        public const string RouteCreateBook = "ROUTE_CREATE_BOOK" + separatorRoutePermission + CreateBook;
        public const string RouteDeleteBook = "ROUTE_DELETE_BOOK" + separatorRoutePermission + DeleteBook;

        public static string GetPermissionFromRoute(string routeName)
        {
            var routeSplited = routeName.Split(separatorRoutePermission);
            string permission = routeSplited[1];

            return permission;
        }
    }
}