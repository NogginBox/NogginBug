Feature: Create new bug
	In order to keep track of new bugs
	As a user
	I want to add new bugs

@mytag
Scenario: Add new bug
	# Given I have entered 50 into the calculator
	When I visit the 'add-bug' page
	And enter details of a new bug
	And click save
	Then a success message is displayed
