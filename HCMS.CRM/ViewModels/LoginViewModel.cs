using Newtonsoft.Json.Linq;
using HCMS.CRM.Framework;
using HCMS.CRM.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMS.CRM.Views;

namespace HCMS.CRM.ViewModels
{
    public class LoginViewModel: ObjectBase, IPageViewModel
    {
        private bool isAuth;
        private JArray roles;
        private string username;
        private string fullName;
        private string avatar;

        public bool IsAuth
        {
            get
            {
                return isAuth;
            }

            set
            {
                isAuth = value;
            }
        }

        public JArray Roles
        {
            get
            {
                return roles;
            }

            set
            {
                roles = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string FullName
        {
            get
            {
                return fullName;
            }

            set
            {
                fullName = value;
            }
        }

        public string Avatar
        {
            get
            {
                return avatar;
            }

            set
            {
                avatar = value;
            }
        }

        public string Name
        {
            get
            {
                return "Login";
            }
        }
    }
}
