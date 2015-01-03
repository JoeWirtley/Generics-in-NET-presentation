Serialization Example
=================================

This folder contains an XML serialization example. XML serialization is the 
poster child for code that is exactly the same except for the type and is
the most common place I've used generic methods across many projects.  The
XmlProcessor class shows generic methods to serialize and deserialize XML.  The
SerializeExtensions shows how these can be called as generic methods.

The Before folder shows the code before the introduction of generics.  
The Support folder contains a number of interface and class definitions 
necessary to make the code able to compile and test. The Test folder contains 
unit tests demonstrating the serialization classes.
