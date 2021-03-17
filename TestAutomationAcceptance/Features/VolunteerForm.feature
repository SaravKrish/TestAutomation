Feature: VolunteerForm
	As a user
	I would like to fill volunteer form
	So that I can submit the details


Scenario: Fill Volunteer Form With Valid Values
	Given the user has progressed to testautomation page
	And fills volunteer form
	When the user submits the form
	Then the message should be displayed

Scenario: Fill Volunteer Form With File Upload
	Given the user has progressed to testautomation page
	And fills volunteer form
	When the user uploads the file 
	Then the message should be displayed

Scenario Outline: Fill Volunteer Form With Invalid Values
	Given the user has progressed to testautomation page
	And fills volunteer form with <Field> <Value>
	When the user submits the form
	Then the FirstName validation message should be displayed
	Examples:
	| Field     | Value           |
	| FirstName | asd98asd"£^%    |
	| LastName  | ajksdhajs$%$asa |
	| Phone     | countrycode3432 |
	| Country   | AS&ASDA         |
	| City      | aS^AS*&(        |

Scenario Outline: Fill Volunteer Form With Invalid Email
	Given the user has progressed to testautomation page
	And fills volunteer form with EmailAddress <Email>
	When the user submits the form
	Then the email validation message should be displayed for <Email>
	Examples:
	| Email					|
	| invalidemail.com		|
	| invalidcom			|
	| invalid@				|
	| invalid@emailcom		|
	| invalid@@email.com	|
	| invalid.email.com		|