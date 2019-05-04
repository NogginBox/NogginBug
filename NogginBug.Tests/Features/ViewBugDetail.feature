Feature: View Bug Detail
	In order to see more detail on a bug
	As a user
	I want to see bug details including the title, description and when it was opened

Scenario: Visit home page and click on bug to see details
	Given there are 1 bugs with status open
	# And I have also entered 70 into the calculator
	When I click the bug title
	Then I see a the bug title, description and when it was opended
