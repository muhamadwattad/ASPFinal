using FinalProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FinalProjectAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static System.Timers.Timer aTimer;
        public static Stopwatch stopWatch = new Stopwatch();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            setTimer();
            stopWatch.Start();
        }

        private void setTimer()
        {
            // Create a timer with a 1 hour interval.
            aTimer = new System.Timers.Timer(1000 * 60);


            // Activating OnTimedEvent Function every 1 hour
            aTimer.Elapsed += OnTimedEvent;

            //Timer resets after 1 hour
            aTimer.AutoReset = true;
            //Timer starts again after finishing 1 hour
            aTimer.Enabled = true;

        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            int hour = int.Parse(now.ToString("HH"));
            int Minute = now.Minute;
            //Checking if hour is 16 or 9
            if (hour == 15 || hour == 9)
            {
                //GET GAMES
                //int res = SQLdb.putGames();
                //if (res == 1)
                //    sendEmail("Sucess");
                //else
                //    sendEmail("Failed");
                sendEmail("TEST TEST TEST");

            }

        }

        private void sendEmail(string msg)
        {
            //sends email to admin to tell him that games have been updated.
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("firebasemudaif@gmail.com");
            message.To.Add(new MailAddress("muhamadwattad@gmail.com"));
            message.Subject = "Games Add";
            //string ran = RandomString(8);
            //  string url = "http://185.60.170.14/plesk-site-preview/ruppinmobile.ac.il/site10/forgot.aspx?";
            //   string url = "http://localhost:51945/forgot.aspx?";
            DateTime now = DateTime.Now;
            if (msg == "Sucess")
                message.Body = $"Hello Muhamad, GAMES WERE ADDED,EXECUTED at: {now.Hour}:{now.Minute}:{now.Second} FROM API";
            else
            {
                message.Body = $"Hello Muhamad, GAMES WERE NOT ADDED, EXECUTED AT :{now.Hour}:{now.Minute}:{now.Second} FROM API";
            }


            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("firebasemudaif@gmail.com", "abonader99");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }
    }

}
