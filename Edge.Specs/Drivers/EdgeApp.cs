using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Actions.WindowsAppDriver;

namespace Edge.Specs.Drivers;

public sealed class EdgeApp : IDisposable
{
    private readonly AppDriver _appDriver;
    private readonly DefaultWait<AppDriver> _wait;

    public EdgeApp(AppDriver appDriver)
    {
        _appDriver = appDriver;
        _wait = new DefaultWait<AppDriver>(_appDriver)
        {
            Timeout = TimeSpan.FromSeconds(5)
        };
        _wait.IgnoreExceptionTypes(typeof(WebDriverException));
    }

    public void OpenNewTab()
    {
        _wait
            .Until(driver => driver.Current.FindElementByName("Новая вкладка"))
            .Click();
    }

    public string GetCurrentTabName()
    {
        return _wait
            .Until(driver => driver.Current.FindElementByTagName("Document"))
            .GetAttribute("Name");
    }

    public void GoTo(string address)
    {
        var searchPanel = _wait.Until(driver => driver.Current.FindElementByName("Адресная строка и панель поиска"));
        
        searchPanel.Clear();
        searchPanel.SendKeys(address);
        searchPanel.SendKeys(Keys.Enter);
        Thread.Sleep(1000);
    }

    public void Dispose()
    {
        _appDriver?.Dispose();
    }
}