#Ignored due to DataProductJourneyFeature. As this is the full process in one test case

@ignore("DataProductJourneyFeature")
Feature: DataProduct

@ignore @Publisher
Scenario: Publisher publish a data product - 2
	Given I have logged in as a Publisher
	When I have navigated to create a Data Product
	When I have entered "TestingSelenium-4321-8" in the name field
	And I have entered "TestingSeleniumDescription" in the description field
	And I have clicked the next step button
	And I have searched for and selected this data source "API Authentication Test"
	And I have clicked the next step button
	And I have selected the tag "Freight" and subtag "0"
	And I have selected the theme "Another theme"
	And I have clicked the next step button
	And I have entered "This is something the data product can do - Using selenium" in what the data product can do
	And I have entered "This is something the data procant can't do - Using selenium" in what the data product cant do
	And I have entered "This is a retirement policy - Using Selenium" in the retirement policy
	And I have clicked immediate publishing after approval
	And I have clicked the next step button
	And I have clicked yes to the SLA
	And I have clicked the next step button
	And I have entered "99" into the service uptime percentage
	And I have entered "48" into the response time outside business hours
	And I have entered "48" into the resolution time outside business hours
	And I have clicked the next step button
	And I have clicked the next step button
	And I have selected who can use the data
	And I have clicked the next step button
	And I have selected what the data can be used for
	And I have clicked the next step button
	And I have selected the charging model
	And I have clicked the next step button
	And I have selected the fair usage limit
	And I have clicked the next step button
	And I have selected my recommended licence
	And I have clicked the next step button
	And I have selected my licence term length to be "1"
	And I have selected my notice period length to be "1"
	And I have selected my territorial permissions to be "4"
	And I have clicked the next step button
	And I have clicked the next step button
	And I have clicked submit
	Then I should be taken to the submit confirmation page

@ignore @OrgAdmin
Scenario: Org Admin publish a data product - 2
	Given I have logged in as a Org Admin
	When I have navigated to create a Data Product
	And I have entered "TestingSelenium-4321" in the name field
	And I have entered "TestingSeleniumDescription" in the description field
	And I have clicked the next step button
	And I have searched for and selected this data source "API Authentication Test"
	And I have clicked the next step button
	And I have selected the tag "Freight" and subtag "0"
	And I have selected the theme "Another theme"
	And I have clicked the next step button
	And I have entered "This is something the data product can do - Using selenium" in what the data product can do
	And I have entered "This is something the data procant can't do - Using selenium" in what the data product cant do
	And I have entered "This is a retirement policy - Using Selenium" in the retirement policy
	And I have clicked immediate publishing after approval
	And I have clicked the next step button
	And I have clicked yes to the SLA
	And I have clicked the next step button
	And I have entered "99" into the service uptime percentage
	And I have entered "48" into the response time outside business hours
	And I have entered "48" into the resolution time outside business hours
	And I have clicked the next step button
	And I have clicked the next step button
	And I have selected who can use the data
	And I have clicked the next step button
	And I have selected what the data can be used for
	And I have clicked the next step button
	And I have selected the charging model
	And I have clicked the next step button
	And I have selected the fair usage limit
	And I have clicked the next step button
	And I have selected my recommended licence
	And I have clicked the next step button
	And I have selected my licence term length to be "1"
	And I have selected my notice period length to be "1"
	And I have selected my territorial permissions to be "5"
	And I have clicked the next step button
	And I have clicked the next step button
	And I have clicked submit
	Then I should be taken to the submit confirmation page

@Publisher
Scenario: 001_Publisher publish a data product
	Given I have logged in as a Publisher
	When I have published a data product
	Then I should be taken to the submit confirmation page

#ignored but can be enabled/switched with Publisher above.
#DataProductJourneyFeature should be used instead. As this is the full process.
@ignore @OrgAdmin
Scenario: Org Admin publish a data product
	Given I have logged in as a Publisher
	When I have published a data product
	Then I should be taken to the submit confirmation page

@FinanceApprover
Scenario: 002_Finance Approver approves data product
	Given I have logged in as a Finance Approver
	When I have approved a data product
	Then The data product is approved

@RDMAdmin
Scenario: 003_RDM Admin approves data product
	Given I have logged in as a RDM Admin
	When I have approved a data product
	Then The data product is approved

#Specific name for a data product approval
@ignore	@FinanceApprover
Scenario: Finance Approver approves this data product
	Given I have logged in as a Finance Approver
	When I have approved the data product "name"
	Then The data product is approved

#Specific name for a data product approval
@ignore @RDMAdmin
Scenario: RDM Admin approves this data product
	Given I have logged in as a RDM Admin
	When I have approved the data product "name"
	Then The data product is approved

#The below would use a table to create one or many data product. 
#Currently not needed as this is for smoke/regression testing
@ignore @Publisher
Scenario: Publisher publish a data product - 3
	Given I have logged in as a Publisher
	When I have created a data product with the information:
	| DataProductName | DataProductDescription | DataSourceName | TagName | SubTagNumber | ThemeName | DataProductCanDescription | DataProductCantDescription | DataProductRetrementDescription | SLAServiceUptimeNumber |
	Then I should be taken to the submit confirmation page
