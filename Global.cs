namespace BookApi
{
    public class Global
    {
        public const string AdminRole = "ADMIN";
        public const string StaffRole = "STAFF";
        public const string MemberRole = "MEMBER";

        public readonly string[] Roles = {
            AdminRole,
            StaffRole,
            MemberRole
        };
    }
}