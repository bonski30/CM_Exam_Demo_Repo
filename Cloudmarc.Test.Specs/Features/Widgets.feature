Feature: Widgets

Testin of Elements under Widgets Parent Menu

Scenario: Verify autocomplete Options - Multiple
	Given I'm navigated to Widgets - Auto Complete Page
	When I enter the ff. colors: Red,Green,Blue
	Then colors should be added in the field
	
Scenario: Verify autocomplete Options - Single
	Given I'm navigated to Widgets - Auto Complete Page
	When I enter color: Red
	Then color should be entered in the field

Scenario: Datepicker Test
	Given I'm navigated to Widgets - Date Picker Page
	When I select a date May 20 2022 using Date Picker

Scenario: Datepicker and Time Test
	Given I'm navigated to Widgets - Date Picker Page
	When I select a date May 20 2022 21:30 using Date Picker With Time

Scenario: ToolTip Message Verification
	Given I'm navigated to Widgets - Tool Tips Page
	When I Hover To Hover Me Button
	Then Tooltip should display "You hovered over the Button" message
	When I Hover To Hover Me Input
	Then Tooltip should display "You hovered over the text field" message
	When I Hover To Contrary Link
	Then Tooltip should display "You hovered over the Contrary" message
	When I Hover To Section Link
	Then Tooltip should display "You hovered over the 1.10.32" message
