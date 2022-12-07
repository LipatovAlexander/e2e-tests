using Edge.Specs.Drivers;
using Edge.Specs.Hooks;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace Edge.Specs.Steps;

[Binding]
public class EdgeStepsDefinitions
{
    private readonly EdgeApp _edge = EdgeHooks.Edge;

    [When(@"the new tab button clicked")]
    public void WhenTheNewTabButtonClicked()
    {
        _edge.OpenNewTab();
    }

    [When(@"the (.*) address entered")]
    public void WhenTheAddressEntered(string address)
    {
        _edge.GoTo(address);
    }

    [Then(@"the tab name should be (.*)")]
    public void ThenTheTabNameShouldBe(string tabName)
    {
        _edge.GetCurrentTabName().Should().Be(tabName);
    }
}