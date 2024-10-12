Question: Design a Library Management System
Design a Library Management System that handles books, magazines, and DVDs. 
The system must manage the borrowing, returning, and tracking of items, as well as the availability of each item type.

Assumptions:
The library has three types of items:
Books, Magazines, DVDs

The library has a set limit on the number of each item type:
Books: 100, Magazines: 50, DVDs: 30

Patrons can borrow multiple items at once, but they must return the items by their due date.

Each item has a borrowing limit:
Books: 14 days, Magazines: 7 days, DVDs: 3 days

The system should track:
How many items are currently available.
How many items are currently borrowed.
Whether an item is overdue based on its due date.

Requirements:
Implement methods to:
Check the availability of each item type (Books, Magazines, DVDs).
Borrow an item (update the availability and set a due date).
Return an item (mark it as returned and free up space).
Check if an item is overdue.
List all borrowed items with their due dates.
Ensure that the system prevents borrowing when the limit for an item type has been reached.

Stretch Goals (Optional):
Implement a late fee system that calculates fines for overdue items:
Books: $0.50 per day, Magazines: $0.25 per day, DVDs: $1.00 per day

Add a reservation system where patrons can reserve items that are currently borrowed by others.