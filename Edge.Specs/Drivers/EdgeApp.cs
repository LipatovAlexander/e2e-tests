using System;
using OpenQA.Selenium;
using SpecFlow.Actions.WindowsAppDriver;

namespace Edge.Specs.Drivers;

public sealed class EdgeApp : IDisposable
{
    private readonly AppDriver _appDriver;

    public EdgeApp(AppDriver appDriver)
    {
        _appDriver = appDriver;
    }

    public void OpenNewTab()
    {
        _appDriver.Current.FindElementByName("Новая вкладка").Click();
    }

    public string GetCurrentTabName()
    {
        return _appDriver.Current.FindElementByTagName("Document").GetAttribute("Name");
    }

    public void GoTo(string address)
    {
        var searchPanel = _appDriver.Current.FindElementByName("Адресная строка и панель поиска");
        searchPanel.SendKeys(address);
        searchPanel.SendKeys(Keys.Enter);
    }

    public void Dispose()
    {
        _appDriver?.Dispose();
    }
}