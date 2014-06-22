Feature: GetRestaurants
	In order to get restaurants
	As a member of site
	Users can input outcode and get restaurants

Scenario: input valid code and press "get restaurants" button
	Given I have entered se19 into the input
	When I press button and submit form with valid outcode
	Then the result should be PartialView with restaurant list

Scenario: input invalid code and press "get restaurants" button
	Given I have entered dfsdfsdf into the input
	When I press button and submit form with valid outcode
	Then the result should be JsonResult with Error

Scenario: input empty code and press "get restaurants" button
	Given I have entered empty value
	When I press button and submit form with valid outcode
	Then the result should be JsonResult with required error