﻿using Gist.Github.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github;

public sealed class ApplicationManager : IDisposable
{
    public static ApplicationManager GetInstance()
    {
        if (!StaticApplicationManager.IsValueCreated)
        {
            var newInstance = new ApplicationManager();
            newInstance.Navigation.OpenHomePage();
            StaticApplicationManager.Value = newInstance;
        }

        return StaticApplicationManager.Value!;
    }
    
    public void Dispose()
    {
        _driver.Close();
        _driver.Quit();
        _driver.Dispose();
    }

    public NavigationHelper Navigation { get; }

    public AuthHelper Auth { get; }

    public GistHelper Gist { get; }

    private readonly IWebDriver _driver;
    private static readonly ThreadLocal<ApplicationManager> StaticApplicationManager = new();
    
    private ApplicationManager()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        var js = (IJavaScriptExecutor) _driver;

        const string baseUrl = "https://gist.github.com";
        Navigation = new NavigationHelper(_driver, wait, js, baseUrl);
        Auth = new AuthHelper(_driver, wait, js);
        Gist = new GistHelper(_driver, wait, js);
    }
}