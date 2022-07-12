Feature: CartPage

A short summary of the feature
Background: 
	Given User is already logged in
	And User add the products in the cart

@tag1

Scenario: Checkout Item
	When I go to the cart page 
	Then I click the checkout button
	#Then I should be on the checkout page "https://www.saucedemo.com/checkout-step-one.html"

