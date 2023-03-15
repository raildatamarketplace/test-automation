Feature: Registration

A short summary of the feature

@registration
Scenario: Registering an Organisation
	Given I have navigated to the registration page
	When I have registered as a new organisation
	Then The organisation should be registered
