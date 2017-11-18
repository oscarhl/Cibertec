using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Automation
{
    public enum DriversOption
    {
        Chrome,
        InternetExplore
    }
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static void GetInstance(DriversOption option)
        {
            switch (option)
            {
                case DriversOption.Chrome:
                    Instance = ChromeInstance();
                    break;
                case DriversOption.InternetExplore:
                    Instance = InternetExploreInstance();
                    break;
                default:
                    Instance = null;
                    break;
            }
        }
        private static IWebDriver InternetExploreInstance()
        {
            //return null;
            return new InternetExplorerDriver();
        }

        private static IWebDriver ChromeInstance()
        {
            var options = new ChromeOptions();
            options.AddArguments("chrome.switches", "--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars--enable-automation --start-maximized");
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enable", false);
            return new ChromeDriver(options);
        }
        public static void CloseInstance()
        {
            Instance.Close();
            Instance.Quit();
            Instance = null;
        }

    }
}
