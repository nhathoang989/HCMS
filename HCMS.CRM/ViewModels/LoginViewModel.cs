using Newtonsoft.Json.Linq;
using HCMS.CRM.Framework;
using HCMS.CRM.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMS.CRM.Views;
using System.Windows.Input;
using System.Windows.Controls;
using HCMS.CRM.Helpers;
using HCMS.CRM.Ultilities;
using System.Windows;

namespace HCMS.CRM.ViewModels
{
    public class LoginViewModel: ObjectBase, IPageViewModel
    {
        public string lblUsername { get { return "Tên đăng nhập"; } }
        public string lblPassword { get { return "Mật khẩu"; } }
        public string lblLogin { get { return "Đăng nhập"; } }

        #region Properties

        private bool isAuth;
        private JArray roles;
        private string username;
        private string password;
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
                RaisePropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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

        public string Title
        {
            get
            {
                return "Login Page";
            }
        }

        public string Key
        {
            get
            {
                return "Login";
            }
        }

        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand(
                        p => LoginExecute((PasswordBox)p),
                        p=> CanLoginExecute());
                }

                return _loginCommand;
            }
        }

        #endregion

        Boolean CanLoginExecute()
        {
            return !string.IsNullOrEmpty(Username);
        }
        async void LoginExecute(PasswordBox passwordBox)
        {
            string value = passwordBox.Password;
            MessageBox.Show(value);
            return;
            if (!CanLoginExecute()) return;

            string apiName = "token";
            string contentType = ApiContentType.XWWWForm;
            ApiParameter paramGrantType = new ApiParameter() { Key = "grant_type", Value = "password" };
            ApiParameter paramUsername = new ApiParameter() { Key = "username", Value = username };
            ApiParameter paramPassword = new ApiParameter() { Key = "password", Value = password };
            List<ApiParameter> lstParam = new List<ApiParameter>();
            lstParam.Add(paramGrantType);
            lstParam.Add(paramUsername);
            lstParam.Add(paramPassword);

            var authResp = await common.postApi(contentType, apiName, lstParam);
            if (!string.IsNullOrEmpty(authResp.ErrorMessage) || string.IsNullOrEmpty(authResp.Content))
            {
                //MessageBox.Show("Error: " + authResp.ErrorMessage);
            }
            else
            {
                JObject jsonAuthResp = JObject.Parse(authResp.Content);
                string uName = jsonAuthResp["userName"].ToString();

                var rsp = await common.getApi(ApiContentType.Json, "api/account/user/" + uName, new List<ApiParameter>());
                JObject jsonCurrentUser = JObject.Parse(rsp.Content);
                App.currUser = new ViewModels.LoginViewModel()
                {
                    IsAuth = true,
                    Roles = (JArray)jsonCurrentUser["roles"],
                    Username = jsonCurrentUser["userName"].ToString(),
                    FullName = jsonCurrentUser["fullName"].ToString()
                };
                if (App.currUser.IsAuth)
                {
                    var mainWindow = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
                    ApplicationViewModel context = (ApplicationViewModel)mainWindow.DataContext;
                    context.CurrentPageViewModel = Helpers.MenuHelper.GetPageView("Home");

                }
            }
        }

    }
}
