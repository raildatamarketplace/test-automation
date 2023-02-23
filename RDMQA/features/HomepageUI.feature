Feature: HomepageUI

Testing UI on the Homepage

@UI
Scenario: Consumer Navigation UI Check
	Given I have logged in as a Consmer
	When I have navigated to the dashboard homepage
	Then The navigation bar should display correctly for the "Consumer" user

@UI
Scenario: Finance Approver Navigation UI Check
	Given I have logged in as a Finance Approver
	When I have navigated to the dashboard homepage
	Then The navigation bar should display correctly for the "Finance Approver" user

@UI
Scenario: Financially Authorised Consumer Navigation UI Check
	Given I have logged in as a Financially Authorised Consumer
	When I have navigated to the dashboard homepage
	Then The navigation bar should display correctly for the "Financially Authorised Consumer" user

@UI
Scenario: Org Admin Navigation UI Check
	Given I have logged in as a Org Admin
	When I have navigated to the dashboard homepage
	Then The navigation bar should display correctly for the "Org Admin" user

@UI
Scenario: Publisher Navigation UI Check
	Given I have logged in as a Publisher
	When I have navigated to the dashboard homepage
	Then The navigation bar should display correctly for the "Publisher" user

@UI
Scenario: RDM Admin Navigation UI Check
	Given I have logged in as a RDM Admin
	When I have navigated to the dashboard homepage
	Then The navigation bar should display correctly for the "RDM Admin" user
