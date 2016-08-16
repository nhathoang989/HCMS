using HCMS.CRM.Helpers;
using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCMS.CRM.Ultilities;
using Newtonsoft.Json.Linq;
using HCMS.CRM.Models;
using HCMS.CRM.ViewModels;

namespace HCMS.CRM
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            if (!App.currUser.IsAuth)
            {
                InitializeComponent();
            }
            else {
                MainWindow mainForm = new MainWindow();
                this.Hide();
                mainForm.Show();
            }
            
        }
        private async void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            if (await Login())
            {
                MainWindow mainForm = new MainWindow();
                this.Hide();
                mainForm.Show();
            }

        }

        async Task<bool> Login() {
            string username = usernameTB.Text.Trim();
            string password = PasswordBoxPB.Password;

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
                MessageBox.Show("Error: " + authResp.ErrorMessage);
            }
            else
            {
                JObject jsonAuthResp = JObject.Parse(authResp.Content);
                string uName = jsonAuthResp["userName"].ToString();

                var rsp = await common.getApi(ApiContentType.Json, "api/account/user/" + uName, new List<ApiParameter>());
                JObject jsonCurrentUser = JObject.Parse(rsp.Content);
                App.currUser = new LoginViewModel
                {
                    IsAuth = true,
                    Roles = (JArray)jsonCurrentUser["roles"],
                    Username = jsonCurrentUser["userName"].ToString(),
                    FullName = jsonCurrentUser["fullName"].ToString()
                };

                
            }
            return App.currUser.IsAuth;
        }
    }
}
