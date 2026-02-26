using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapperLib.Models.Responses.Identity
{
    public class RoleClaimResponse
    {
        public RoleResponse Role { get; set; }
        public List<RoleClaimViewModel> RoleClaims { get; set; }
    }
}
