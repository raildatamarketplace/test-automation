using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using SeleniumExtras.WaitHelpers;
using System.Drawing.Drawing2D;

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

        public Utils(IWebDriver _driver)
        {
            _seleniumDriver = _driver;
            this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            dataProductFileName = @"..\..\DataProductNumber.txt";
            dataProductPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dataProductFileName);
            usernameFileName = @"..\..\UsernameNumber.txt";
            usernamePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, usernameFileName);
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

    }
}
