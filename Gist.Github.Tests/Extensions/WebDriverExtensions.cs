using OpenQA.Selenium;

namespace Gist.Github.Extensions;

public static class WebDriverExtensions
{
    public static IWebElement? FindElementIfExists(this IWebDriver driver, By by)
    {
        var elements = driver.FindElements(by);
        return elements.Any()
            ? elements.First()
            : null;
    }
}