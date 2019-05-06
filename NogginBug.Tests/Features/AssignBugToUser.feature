Feature: Assign bug to user
	In order to track who is responsible for fixing which bugs
	As a user
	I want to be assign bugs to users

Scenario: Assign open bug to user 
	Given there are 1 bugs with status open
	And there is a User with name 'Baldrick'
	When I visit the 'home' page
	And I click the bug title
	And I assign 'Baldrick' from available users
	Then a success message is displayed
	And the bug is assigned to 'Baldrick'
