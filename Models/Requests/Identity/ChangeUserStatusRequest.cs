using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseWrapperLib.Models.Requests.Identity
{
    public class ChangeUserStatusRequest
    {
        public string UserId { get; set; }
        public bool ActiveOrDeactivate { get; set; }
    }
}
