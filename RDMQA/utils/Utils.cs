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
        private string fileName;
        private string path;

        public Utils(IWebDriver _driver)
        {
            _seleniumDriver = _driver;
            this.wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            fileName = @"..\..\DataProductNumber.txt";
            path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        }
        public void MoveToLocation(IWebElement element)
        {
            //Thread.Sleep(2000);
            int deltaY = element.Location.Y;
            new Actions(_seleniumDriver).ScrollByAmount(0, deltaY).Perform();
            //Thread.Sleep(2000);
        }

        //public void MoveToLocation(By element)
        //{
        //    wait.Until(ExpectedConditions.ElementExists(element));
        //    int deltaY = _seleniumDriver.FindElement(element).Location.Y;
        //    new Actions(_seleniumDriver).ScrollByAmount(0, deltaY).Perform();
        //}

        public string GetNewDataProductNumber()
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            sr.Close();
            int current = Convert.ToInt32(line);
            int updated = current + 1;


            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(updated);
            sw.Close();
            return current.ToString();
        }

        public string GetDataProductNumber()
        {
            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            sr.Close();
            int current = Convert.ToInt32(line) - 1;
            return current.ToString();
        }

    }
}
