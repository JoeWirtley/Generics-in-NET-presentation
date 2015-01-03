Filtering Example
=================================

This folder contains an example demonstrating the usage of generic types in
creating dynamic LINQ query.  The use case for this example is a user entering
criteria that will ultimately be used as where clauses in a SQL qeury.  The
filters demonstrated in this example include allowing the user to specify
that a name contains or is equal to a given string, or that a person's age is
less than or greater than a specified number.  The user interface code that does
this is completely separated from the eventual LINQ query.  

The PersonFilter class represents how the filter information is passed from
the UI to the repository, and is a parameter to the GetFilteredPeople method
on the repository class.

The Support folder contains a number of interface and class definitions 
necessary to make the code able to compile and test. The Test folder 
contains unit tests demonstrating the filtering classes.
