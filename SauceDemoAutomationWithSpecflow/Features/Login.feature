Feature: Logging In

@mytag
Scenario: Login Test
	Given User navigates to "https://www.saucedemo.com/"
	When User input text "standard_user" on "//input[@id='user-name']"
	When User input password text "secret_sauce" on "//input[@id='password']"
	When User clicks on "//input[@id='login-button']"
	When User is redirected to "https://www.saucedemo.com/inventory.html"