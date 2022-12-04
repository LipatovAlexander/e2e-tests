using GithubGists.Selenium.Extensions;
using GithubGists.Selenium.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GithubGists.Selenium.Helpers;

public sealed class GistHelper : HelperBase
{
    public GistHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor, NavigationHelper navigation)
        : base(driver, wait, javaScriptExecutor)
    {
        _navigation = navigation;
    }

    public void CreateGist(GistData gist)
    {
        _navigation.OpenNewGistPage();

        Wait
            .Until(d => d.FindElement(By.Name("gist[contents][][name]")))
            .SendKeys(gist.FileName);

        if (gist.Description is not null)
        {
            Driver
                .FindElement(By.Name("gist[description]"))
                .SendKeys(gist.Description);
        }
        var element = Driver.FindElement(By.Name("gist[contents][][value]"));
        JavaScriptExecutor.ExecuteScript("arguments[0].style.display = 'block'", element);
        element.SendKeys(gist.Content);
        
        Driver.FindElement(By.CssSelector(".hx_create-pr-button")).Click();
        
        gist.Id = Driver
            .FindElement(By.CssSelector("meta[name=\"octolytics-dimension-gist_name\"]"))
            .GetAttribute("content");
    }

    public GistData? GetGist(string username, string id)
    {
        _navigation.OpenGistPage(username, id);

        if (Driver.Title == "Page not found · GitHub")
        {
            return null;
        }

        var filename = Wait
            .Until(d => d.FindElement(By.CssSelector(".gist-blob-name")))
            .Text;
        var content = Wait
            .Until(d => d.FindElement(By.CssSelector("[name=\"gist[content]\"]")))
            .GetAttribute("value");
        var description = Driver
            .FindElementIfExists(By.CssSelector("div[itemprop=\"about\"]"))
            ?.Text;

        return new GistData
        {
            Id = id,
            Description = description,
            FileName = filename,
            Content = content
        };
    }

    public void DeleteGist(string userName, string id)
    {
        _navigation.OpenGistPage(userName, id);
        Wait.Until(d => d.FindElement(By.CssSelector(".btn-danger"))).Click();
        Driver.SwitchTo().Alert().Accept();
    }
    
    private readonly NavigationHelper _navigation;
}