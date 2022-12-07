Feature: Edge

Scenario: Open new tab
	When the new tab button clicked
	Then the tab name should be Новая вкладка

Scenario: Go to google
	When the google.ru address entered
	Then the tab name should be Google