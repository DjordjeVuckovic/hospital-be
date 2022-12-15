﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTest.Pages
{
    public class RoomsPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/rooms";

        IWebElement bloodSupplyNav => driver.FindElement(By.XPath("/html/body/app-root/app-sidenav/div/ul/li[8]/a"));
        IWebElement bloodRequestNav => driver.FindElement(By.XPath("/html/body/app-root/app-sidenav/div/ul/li[7]/a/i"));

        public RoomsPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool bloodSupplyNavDisplayed()
        {
            return bloodSupplyNav.Displayed;
        }

        public bool bloodRequestNavDisplayed()
        {
            return bloodRequestNav.Displayed;
        }
        public void bloodSupplyNavClick()
        {
            bloodSupplyNav.Click();
        }
        public void bloodRequestNavClick()
        {
            bloodRequestNav.Click();
        }
        public void WaitForFormSubmit()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("http://localhost:4200/bloodBank"));
        }
    }
}
