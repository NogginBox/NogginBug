Feature: View Open Bugs
	In order to see current bugs
	As a user
	I want to see the titles of all bugs with open status

Scenario: Visit home page to see open bugs
       Given there are 2 bugs with status open
       # And I have also entered 70 into the calculator
       When I visit the 'home' page
       Then I see a list of the titles of 2 bugs with open status