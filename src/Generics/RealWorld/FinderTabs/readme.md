FinderTabs Example
=================================

This example is drawn from a WPF application using Prism.  In this application,
there can be any number of open documents in a tab region.  The purpose of the
FinderTabs class is to encapsulate adding and removing documents from that tab
region.  The generic method used is ActivateViewMeetingCondition, which will
attempt to activate a view if it is open.  It does this so if a particular
document is already open, it will not be opened again, but instead that view 
will be activated.  

Since the tab region can contain a number of different types of documents,
a generic parameter to the activate view method is very handy in this case since
the method by which we want to identify a view may differ between types (or
usages).

The ExampleUsage class hows how the FinderTabs class may be called, and the 
Support file contains interfaces and classes to make the code compile (including
some fake Prism classes).
 