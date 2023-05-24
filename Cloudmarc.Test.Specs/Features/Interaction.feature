Feature: Interaction

Test Sortable page by usin Click and Hold
Test Droppable page by using DragAndDrop

Scenario: Sort Sortable Elements into Descending Order
	Given I'm navigated to Interactions - Sortable Page
	When I arrange elements into descending order
	Then sortable Elements should be displayed in descending


Scenario: Verify Droppable Elements
	Given I'm navigated to Interactions - Droppable Page
	When I Drag and Drop source element into Target Element
	Then Target Element should display "Dropped" message


