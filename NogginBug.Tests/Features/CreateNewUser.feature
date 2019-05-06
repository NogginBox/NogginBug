Feature: Create new user
	In order to let other people do the work
	As a user
	I want to be add new users to the system

Scenario: Add new user
	When I visit the 'add-user' page
	And enter details of a new user
	And click save
	Then a success message is displayed
