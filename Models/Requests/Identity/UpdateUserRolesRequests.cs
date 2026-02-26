using ResponseWrapperLib.Models.Responses.Identity;

namespace ResponseWrapperLib.Models.Requests.Identity
{
    public class UpdateUserRolesRequests
    {
        public string UserId { get; set; }
        public List<UserRoleViewModel> Roles { get; set; }
    }
}
