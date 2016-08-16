using HCMS.CRM.Framework;
using HCMS.CRM.ViewModels;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;

namespace HCMS.CRM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LoginViewModel currUser = new LoginViewModel();
        public static string baseWebAPIAddress = "http://localhost:9000/";
        //public static string baseWebSignalRAddress = "http://localhost:8080/";

        private const string Guid = "250C5597-BA73-40DF-B2CF-DD644F044834";
        static readonly Mutex Mutex = new Mutex(true, "{" + Guid + "}");
        //public static HCMS.CRM.Models.AuthenticatedUser currentAuth { get; set; }



        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        public App()
        {

            Process currentProcess = Process.GetCurrentProcess();
            var runningProcess = (from process in Process.GetProcesses()
                                  where
                                    process.Id != currentProcess.Id &&
                                    process.ProcessName.Equals(
                                      currentProcess.ProcessName,
                                      StringComparison.Ordinal)
                                  select process).FirstOrDefault();
            if (runningProcess != null)
            {
                ShowWindow(runningProcess.MainWindowHandle, 1);
                //MessageBox.Show("asdfadf")
                return;
            }

            currUser = currUser ?? new LoginViewModel();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            WebApp.Start(url: baseWebAPIAddress);

            ApplicationView app = new ApplicationView();
            ApplicationViewModel context = new ApplicationViewModel();
            app.DataContext = context;
            app.Show();
            //WebApp.Start<OWINSignalRConfig>(url: baseWebSignalRAddress);
        }
    }
    //public class OWINWebAPIConfig
    //{
    //    public void Configuration(IAppBuilder appBuilder)
    //    {
    //        //appBuilder.UseStaticFiles("/web");
            
    //        // Configure Web API for self-host. 
    //        HttpConfiguration config = new HttpConfiguration();
    //        config.Routes.MapHttpRoute(
    //            name: "DefaultApi",
    //            routeTemplate: "api/{controller}/{id}",
    //            defaults: new { id = RouteParameter.Optional }
    //        );

    //        appBuilder.UseWebApi(config);
    //    }
    //}

    //public class OWINSignalRConfig
    //{
    //    public void Configuration(IAppBuilder appBuilder)
    //    {
    //        appBuilder.UseCors(CorsOptions.AllowAll);
    //        appBuilder.MapSignalR();
    //    }
    //}

    //public class MainHub : Hub
    //{
    //    public void Send(string name, string message)
    //    {
    //        Clients.All.addMessage(name, message);
    //    }
    //}
}
