Feature: Search
	As a user
	I would like to search for a given text
	So that I can have results related to the text


Scenario Outline: Valid results are returned
	Given the user has progressed to testautomation page
	And enters search text <SearchTerm> in search field
	When the user clicks Search Icon
	Then the Search results text is displayed in bold
	And the results for <SearchTerm> are displayed in green
	Examples:
	| SearchTerm |
	| Search |
	| Results |


Scenario: Search for valid text result with enter key
	Given the user has progressed to testautomation page
	And enters search text Microsoft in search field
	When the user clicks enter key
	Then the Search results text is displayed in bold
	And the results for Microsoft are displayed in green
	When the user clicks more link
	Then more results page is displayed


Scenario: Message displayed when no results found
	Given the user has progressed to testautomation page
	And enters search text invalidsearchtext in search field
	When the user clicks Search Icon
	Then the Search results text is displayed in bold
	And No results found. text is displayed in red


Scenario: Message displayed when no text is entered in the search
	Given the user has progressed to testautomation page 
	When the user clicks Search Icon
	Then Please enter text to search. text is displayed in red