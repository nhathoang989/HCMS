using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.CRM.Models
{
    public class AuthenticatedUser
    {
        public bool isAuth;
        public JArray roles;
        public string username;
        public string fullName;
        public string avatar;
    }
}
