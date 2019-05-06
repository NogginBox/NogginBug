Feature: CloseBug
	In order to record that a bug is no longer active
	As a user
	I want to be able to close bugs

Scenario: Close bug from bug detail screen
	Given there are 1 bugs with status open
	When I visit the 'home' page
	And I click the bug title
	And I click the 'close bug' button
	Then a success message is displayed
	And the bug's status is 'Closed'
