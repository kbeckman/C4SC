#C4SC#
This is an open source C# .NET library that contains useful functionality that has made my job easier during .NET 
development. Much of the content in this library has been blogged about in my technical blog, [Coding4StreetCred]
(http://www.coding4streetcred.com/blog). 

Throughout development, a strong attempt has been made make all libraries available in this solution CLSCompliant 
allowing for usage in either a C'# or VB.NET application. Please let me know if you find otherwise or issue a pull 
request to fix whatever issue(s) you might encounter.

---
##C4SC.Core##
C4SC.Core is a common library with functionality valuable to all types of .NET projects independent of development 
platform. Types and classes in this library can be considered extensions, supplements or enhancements to functionality 
found in the .NET Framework base libraries.
<br/><br/>

###DateTime DSL -- [C4SC post](http://www.coding4streetcred.com/blog/post/A-C4SC-Series-DSL-Development-in-NET-with-C.aspx)
Provides a more English-like syntax for working with DateTime... This DSL was inspired by the helper methods present in
[Rails](http://api.rubyonrails.org/classes/Date.html), the open source Ruby MVC web development framework.

	DateTime endOfSprint 		= 2.Weeks().FromNow();
	DateTime fullyVestedDate 	= 5.Years().From(hireDate);
	DateTime lunchTime			= 3.Hours().And(20.Minutes()).FromNow();
	DateTime nineDaysLater		= 1.Week().And(2.Days()).FromNow();
	DateTime lastWeekAtThisTime = 7.Days().Ago();
	DateTime kickoff 			= 1.Hour().AgoFrom(theEndOfTheGame);
	DateTime theOpeningBell		= 6.Hours().And(30.Minutes()).AgoFrom(theClosingBell);

	DateTime yesterdayMidnight	= Yesterday.Date().AtBeginningOfDay();
	DateTime tomorrowAtThisTime = Tomorrow.Date();
	DateTime billsDue			= aDate.AtEndOfMonth();
	DateTime taxesDue			= aDate.AtEndOfQuarter();
	Boolean isToday				= unknownDate.IsToday();
	Boolean isPast				= unknownDate.IsPast();
	Boolean isFuture			= unknownDate.IsFuture();

---
##C4SC.Web.UIs##
C4SC.Web.UI contains various web controls and behavior useful in ASP.NET web forms projects.
<br/><br/>

###GoogleAnalytics -- [C4SC post](http://www.coding4streetcred.com/blog/post/Add-Google-Analytics-to-your-ASPNET-WebForms-Application.aspx)
A configurable WebControl for adding Google Analytics tracking to your site...

	<c4sc:GoogleAnalytics ID="analytics" runat="server" AccountId="yourAccountId" DomainOption="SingleDomain" />

---

##Test.C4SC##
Test.C4SC contains all of the NUnit tests for every project in the C4SC solution and is the definitive documentation 
source for functionality defined in the C4SC solution. Any details not found in the documentation, markdown files or 
[Coding4StreetCred blog posts](http://www.coding4streetcred.com/blog) can be obtained from the content in these tests.
