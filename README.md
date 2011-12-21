#C4SC#
This is an open source C'# .NET library that contains useful functionality that has made my job easier during .NET development. Much of the content in this library has been blogged about in my technical blog, [Coding4StreetCred](http://www.coding4streetcred.com/blog). 

Throughout development, a strong attempt has been made make all libraries available in this solution CLSCompliant allowing for usage in either a C'# or VB.NET application. Please let me know if you find otherwise or issue a pull request to fix whatever issue(s) you might encounter.

---

##C4SC.Common##
C4SC.Common is a common library with functionality valuable to all types of .NET projects independent of development platform. Types and classes in this library can be considered extensions, supplements or enhancements to functionality found in the .NET Framework base libraries.

####DateTime DSL#### -- [C4SC post](http://www.coding4streetcred.com/blog/post/A-C4SC-Series-DSL-Development-in-NET-with-C.aspx)
Provides a more English-like syntax for working with DateTime...

	DateTime endOfSprint 		= 2.Weeks().FromNow();
	DateTime fullyVestedDate 	= 5.Years().From(hireDate);
	DateTime lastWeekAtThisTime = 7.Days().Ago();
	DateTime kickoff 			= 1.Hour().AgoFrom(theEndOfTheGame);

---

##C4SC.Common.WebControls##
C4SC.Common.WebControls contains web controls useful in ASP.NET web forms projects.

####GoogleAnalytics#### -- [C4SC post](http://www.coding4streetcred.com/blog/post/Add-Google-Analytics-to-your-ASPNET-WebForms-Application.aspx)
A configurable WebControl for adding Google Analytics tracking to your site...

	<c4sc:GoogleAnalytics ID="GoogleAnalytics" runat="server" AccountId="yourAccountId" DomainOption="SingleDomain" />

---

##Test.C4SC##
Test.C4SC contains all of the NUnit tests for every project in the C4SC solution and is the definitive documentation source for functionality defined in the C4SC solution. Any details not found in the documentation, markdown files or [Coding4StreetCred blog posts](http://www.coding4streetcred.com/blog) can be obtained from the content in these tests.
