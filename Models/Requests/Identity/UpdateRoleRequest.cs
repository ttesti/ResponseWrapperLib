using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapperLib.Models.Requests.Identity
{
    public class UpdateRoleRequest
    {
        public string RoleID { get; set; }
        public string Id { get; set; } 
        public string Description { get; set; }
    }
}
