Feature: VerifyShoppingBasketItems
	Search for a book, check its detail and Add it to the basket successfully

Background:
	Given I start the Chrome browser

Scenario: Verify the shopping basket items
	#TestID - 123456
	When I navigate to Amazon home page
	And I perform search by "Harry Potter and the Cursed Child" in "Books" category
	Then I verify that the first search result is "Harry Potter and the Cursed Child - Parts One & Two"
	When I navigate to book "Harry Potter and the Cursed Child - Parts One and Two: The Official Playscript of the Original West End Production" details page and verify the book title
	Then I verify the book details:
		| Type      | Price | Quantity |
		| Paperback | £4.00 | 1        |
	When I add the book to the basket
	Then I verify that notification is shown with title: "Added to Basket"
	# Didn't manage to create and finalize the Edit step
	Then I stop the Chrome browser