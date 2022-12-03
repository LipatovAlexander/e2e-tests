using Gist.Github.Extensions;
using Gist.Github.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Helpers;

public sealed class GistHelper : HelperBase
{
    public GistHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor) : base(driver, wait, javaScriptExecutor)
    {
    }

    public void CreateGist(GistData gist)
    {
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
    }

    public GistData GetCreatedGist()
    {
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
            Description = description,
            FileName = filename,
            Content = content
        };
    }
}