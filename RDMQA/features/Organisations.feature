Feature: Organisations

A short summary of the feature

@users @consumer
Scenario: Add a new Consumer User
	Given I have logged in as a Org Admin
	When I have added a new user "consumerAutomation" "3"
	Then The new user is added to the organisation

@users @publisher
Scenario: Add a new Publisher User
	Given I have logged in as a Org Admin
	When I have added a new user "publisherAutomation" "2"
	Then The new user is added to the organisation

@users @orgadmin
Scenario: Add a new Admin User
	Given I have logged in as a Org Admin
	When I have added a new user "adminAutomation" "1"
	Then The new user is added to the organisation

@users @consumer
Scenario: Add a new FinanciallyAuthorisedConsumer User
	Given I have logged in as a Org Admin
	When I have added a new user "facAutomation" "5"
	Then The new user is added to the organisation

@users @consumer
Scenario: Add a new FinanceApprover User
	Given I have logged in as a Org Admin
	When I have added a new user "faAutomation" "4"
	Then The new user is added to the organisation
