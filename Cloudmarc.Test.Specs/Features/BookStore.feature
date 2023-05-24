Feature: BookStore

A short summary of the feature

@tag1
Scenario: Login - Valid Credentials
	Given I'm navigated to Book Store Application - Login Page
	When I click on New user Button
	And I registered using valid details
	When I Login to Book Store
	Then I should be successfully logged in

Scenario: Login - Invalid Credentials
	Given I'm navigated to Book Store Application - Login Page
	When I Login to Book Store using invalid credentials
	Then a validation message should display