using System.ComponentModel.DataAnnotations;
namespace BookApi.Requests.Permission
{
    public class PermissionCreate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
    public class PermissionUpdate
    {
        [Required]
        [MinLength(6)]
        public string Name { get; set; }
    }
}