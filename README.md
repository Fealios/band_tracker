# Band Tracker
### Keep track of what bands are playing at what venues
#### Copywrite March 3rd, 2017 by Melvin Gruschow

#### Description:
This is a c# based application utilizing MSSQL database, run through the browser.  It's purpose is to let the user enter bands and venues, and keep track of what bands are playing where.  

#### Instructions:
Download the repository, and run the dnu restore and dnx kestrel commands from powershell in the root directory of said repository.  Then run the .sql file labeled "database" and that should generate the database in your local machine.  Finally, browse to localhost:5004 in your browser, and begin use.

###Specs:

* User enters venue, venue is saved in DB to be accessed later
    - "El Corozon"
    - output: "El Corozon"

* User adds band, band is saved to database to be accessed later
    - "Mayday Parade"
    - output: "Mayday Parade"

* Using previous, user may add band in relation to a venue, ergo assigning band to 'play' at said venue
    - "Mayday parade" /select dropdown of venues/  /select venue/
    - "Mayday parade is playing at the Wamu Theater"

* User may see what venues a band is playing at by going to the band page
    - /click on "Jason Mraz"
    - output: "Jason Mraz is playing at: The Gorge, Wamu theater, Key Arena"

* User may see what bands are playing at a venue by going to the venu page
    - /click on "Wamu Theater"
    - output: "Jason Mraz, Niki Manage, other artist are playing at the Wamu Theater"
