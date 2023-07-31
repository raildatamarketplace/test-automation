using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;   
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using SeleniumExtras.WaitHelpers;
using System.Drawing.Drawing2D;
using System.Xml.Linq;

namespace RDMQA
{
    public class Utils
    {
        private IWebDriver _seleniumDriver;
        private WebDriverWait wait;
        private string dataProductFileName;
        private string dataProductPath;
        private string usernameFileName;
        private string usernamePath;
        private string usersFileName;
        private string usersPath;

        public Utils(IWebDriver _driver)
        {
            _seleniumDriver = _driver;
            this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            dataProductFileName = @"..\..\DataProductNumber.txt";
            dataProductPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataProductFileName);
            usernameFileName = @"..\..\UsernameNumber.txt";
            usernamePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, usernameFileName);
            usersFileName = @"..\..\Users.xml";
            usersPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, usersFileName);
        }
        public void MoveToLocation(IWebElement element)
        {
            //Thread.Sleep(2000);
            int deltaY = element.Location.Y;
            new Actions(_seleniumDriver).ScrollByAmount(0, deltaY).Perform();
            //Thread.Sleep(2000);
        }

        public string GetNewDataProductNumber()
        {
            StreamReader sr = new StreamReader(dataProductPath);
            string line = sr.ReadLine();
            sr.Close();
            int current = Convert.ToInt32(line);
            int updated = current + 1;


            StreamWriter sw = new StreamWriter(dataProductPath);
            sw.WriteLine(updated);
            sw.Close();
            return current.ToString();
        }

        public string GetDataProductNumber()
        {
            StreamReader sr = new StreamReader(dataProductPath);
            string line = sr.ReadLine();
            sr.Close();
            int current = Convert.ToInt32(line) - 1;
            return current.ToString();
        }

        public string GetNewUsernameNumber()
        {
            StreamReader sr = new StreamReader(usernamePath);
            string line = sr.ReadLine();
            sr.Close();
            int current = Convert.ToInt32(line);
            int updated = current + 1;


            StreamWriter sw = new StreamWriter(usernamePath);
            sw.WriteLine(updated);
            sw.Close();
            return current.ToString();
        }

        public string GetUsernameNumber()
        {
            StreamReader sr = new StreamReader(usernamePath);
            string line = sr.ReadLine();
            sr.Close();
            int current = Convert.ToInt32(line) - 1;
            return current.ToString();
        }

        public string GetUsername(UserType userType)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(usersPath);
            XmlNode node = doc.SelectSingleNode("/Users/" + userType.ToString() + "/Username");
            string text = node.InnerText;
            return text;
        }

        public string GetPassword(UserType userType)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(usersPath);
            XmlNode node = doc.SelectSingleNode("/Users/" + userType.ToString() + "/Password");
            string text = node.InnerText;
            return text;
        }

        public enum UserType
        {
            RDMAdmin,
            Admin,
            Publisher,
            Consumer,
            FAConsumer,
            FinanceApprover,
            ContentManager
        }

    }
}
