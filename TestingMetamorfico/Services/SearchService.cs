using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestingMetamorfico.Services
{
    public class SearchService
    {
        public long CountSearchResults(string searchQuery)
        {
            IWebDriver driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Navigate().GoToUrl("http://www.google.com/");
            driver.Manage().Window.Maximize();

            var searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys(searchQuery);
            searchBox.SendKeys(Keys.Enter);

            var resultStats = driver.FindElement(By.Id("result-stats"));
            var textResult = Regex.Matches(resultStats.Text, @"\d+").SkipLast(2).Select(x => x.Value);
            var result = long.Parse(textResult.Aggregate((s1, s2) => s1 + s2));

            return result;
        }
    }
}
