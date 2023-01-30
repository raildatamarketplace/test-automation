Feature: DataProductJourney

A short summary of the feature

@Publisher @FinanceApprover @OrgAdmin @RDMAdmin
Scenario: Publisher Full Publish Journey
	Given I have logged in as a Publisher
	When I have published a data product
	And I have logged out
	Given I have logged in as a Finance Approver
	When I have approved a data product
	And I have logged out
	Given I have logged in as a RDM Admin
	When I have approved a data product
	Then The data product is approved
