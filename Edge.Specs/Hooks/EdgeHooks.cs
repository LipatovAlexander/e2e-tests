using Edge.Specs.Drivers;
using SpecFlow.Actions.WindowsAppDriver;
using TechTalk.SpecFlow;

namespace Edge.Specs.Hooks;

[Binding]
public sealed class EdgeHooks
{
    public static EdgeApp Edge; 

    [BeforeTestRun]
    public static void BeforeTestRun(AppDriver driver)
    {
        Edge = new EdgeApp(driver);
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        Edge.Dispose();
    }
}