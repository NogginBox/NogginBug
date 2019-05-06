Feature: Change user's name
	In order deal with any user wanting to change their name
	As a user
	I want to be able to edit any users name

Scenario: Edit users name (Kate, it's short for Bob)
	Given there is a User with name 'Kate'
	And there is not a user called 'Bob'
	When I visit the 'user list' page
	And I click the user name 'Kate'
	And I enter the name 'Bob' for the user
	Then a success message is displayed
	And the user name 'Bob' is displayed
