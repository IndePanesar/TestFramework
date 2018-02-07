@AlexaWebOageTests
Feature: LinkMyAvivaToAlexa
	As an Aviva customer I want to link my
	Alexa account with my Aviva account so I can 
	get details about my policy holdings

Scenario Outline: Link my Aviva account with Alexa required field inputs
	Given I have am on the account linking page
	And I have agreed to the skills TnCs
	When I click continue button to submit the TnCs
	Then I land on the Login Page of Link MyAviva to Alexa
	When I input 'username' field as '<Username>'
	And  I input 'password' field as '<Password>'
	And I submit the login form
	Then I see the error message '<ErrorMessage>' 
Examples: 
| Username   | Password   | ErrorMessage                  |
|            | MyPassword | Please enter a valid username |
| MyUsername |            | Please enter a valid password |

