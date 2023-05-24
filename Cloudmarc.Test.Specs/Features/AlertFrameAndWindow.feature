Feature: AlertFrameAndWindow

Feature to test Alert pop-up interaction

Scenario: Verify Alert prompt should display
	Given I'm navigated to Alerts, Frame & Windows - Alerts Page
	When I click the first Button
	Then Alert window should display

