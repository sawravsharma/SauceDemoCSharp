Feature: CheckoutPage

A short summary of the feature

Background: 
	Given User is already logged in the website
	And User has added the products in the cart
	And User has clicked on Checkout button


@tag1
Scenario: After adding the products in the cart, user is checking out
	Given User is already on Checkout Page
	When User add his information
	Then User clicks on continue button
