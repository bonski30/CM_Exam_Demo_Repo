Feature: Elements
		 As a user I want to Verify Textbox Details

Scenario: Verify TextBox Details - Post Submission - Valid Email
	
	Given I'm navigated to Elements - Text Box Page
	When I submit the ff. valid Infomation
	| FullName | Email              | CurrentAddr | PermanentAddr |
	| FName     | testemail@test.com | Lot 13, Blk 40  | Lot 13, Blk 40   |
	Then Output result should be correct

Scenario: Verify TextBox Details - Post Submission - Invalid Email

	Given I'm navigated to Elements - Text Box Page
	When I submit the ff. valid Infomation
	| FullName | Email      | CurrentAddr     | PermanentAddr |
	| FName    | testemail  | Lot 13, Blk 40  | Lot 13, Blk 40   |
	Then Email Field should display error

Scenario: Verify Checkbox
	Given I'm navigated to Elements - Check Box Page
	When I Tick the ff. checkboxes: React,Public,Word File.doc
	Then Result should display You have selected: react public wordFile

Scenario: Edit Contents of The Web Table  

Given I'm navigated to Elements - Web Tables Page
	When I click Edit on record with email: cierra@example.com
	And I Edit the values with the ff.
	| FirstName       | LastName        | Email                 | Age | Salary | Department |
	| FName - Updated | LName - Updated | email@testupdated.com | 20  | 2000   | IT         |
	Then Changes should reflect on the table

Scenario: Verify Button Selected

Given I'm navigated to Elements - Buttons Page
	When I click Double Click Me Button
	Then "You have done a double click" message should appear
	When I click Right Click Me Button
	Then "You have done a right click" message should appear
	When I click Click Me Button
	Then "You have done a dynamic click" message should appear

Scenario: Upload and Download Test
	Given I'm navigated to Elements - Upload and Download Page
	When I Click on Download Button 
	Then the file should be downloaded	
	When I want to upload a file by click Choose File and entering its path
	Then Filepath should display Upload.txt
 