using HCMS.CRM.UserControls;
using HCMS.CRM.Views;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using MaterialMenu;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;
using HCMS.API.DALs.CRM;
using HCMS.API.Models.CRM;

namespace HCMS.CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        bool IsProcessing = false;
        public MainWindow()
        {
            if (!App.currUser.IsAuth)
            {
                //LoadControl(new LoginWindow());
            }
            else
            {
                InitializeComponent();
                //this.LoadControl(new UCHome());             
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadControl(new UCHome());
            foreach (var role in App.currUser.Roles)
            {
                LoadMenuByRole(role.ToString());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            //CreateProductDetailsTemplate f = new CreateProductDetailsTemplate();
            //f.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //LoadControl(new UCHome());
            foreach (var role in App.currUser.Roles)
            {
                LoadMenuByRole(role.ToString());
            }

        }

        public void LoadControl(UserControl uc)
        {
            //this.MainContainer.Children.Clear();
            //this.MainContainer.Children.Add(uc);
        }

        private void MenuButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //CreateProductDetailsTemplate f = new CreateProductDetailsTemplate();
            //f.ShowDialog();
            //IsProcessing = true;         
            ScrollViewer sv = (ScrollViewer)MainMenu.Content;
            StackPanel sp = (StackPanel)sv.Content;
            foreach (var role in App.currUser.Roles)
            {
                MenuButton btnRole = new MenuButton();
                btnRole.Text = role.ToString();
                LoadMenuByRole(role.ToString(),btnRole);
                sp.Children.Add(btnRole);
            }
        }

       

        public void LoadMenuByRole(string role, MenuButton roleMenus = null, List<CRM_Role_Menu> lstMenu = null, MenuButton parent = null, int level = 0)
        {
            
            if (lstMenu == null)
            {
                lstMenu = MenuDAL.GetListMenu(role, null, 0);
                roleMenus = new MenuButton();
                roleMenus.Text = role;
            }

            foreach (var item in lstMenu)
            {
                if (parent == null)
                {
                    parent = new MenuButton();
                    parent.Text = item.CRM_Menu.Name;
                }

                var lstSubMenu = MenuDAL.GetListMenu(role, item.MenuID, level + 1);
                if (lstSubMenu.Count > 0)
                {
                    foreach (var subItem in lstSubMenu)
                    {
                        if (subItem.CRM_Menu.ParentID == item.MenuID)
                        {
                            MenuButton sb = new MenuButton();
                            sb.Text = subItem.CRM_Menu.Name;
                            parent.Children.Add(sb);
                            LoadMenuByRole(role, roleMenus, lstSubMenu, sb, item.CRM_Menu.Level + 1);
                        }

                    }

                }
                if (item.CRM_Menu.Level == 0)
                {                    
                    roleMenus.Children.Add(parent);
                    parent = null;
                    if (lstMenu.IndexOf(item)== lstMenu.Count-1)
                    {
                        ScrollViewer sv = (ScrollViewer)MainMenu.Content;
                        StackPanel sp = (StackPanel)sv.Content;
                        sp.Children.Add(roleMenus);
                    }
                }
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
