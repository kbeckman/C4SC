using System;
using System.Collections.Generic;
using System.Linq;
using C4SC.Common;
using C4SC.Common.Testability;
using NUnit.Framework;

namespace Test.C4SC.Common
{
	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the C4SC port of the helpers in the Rails Date class.
	/// </summary>
	/// <remarks>
	/// http://api.rubyonrails.org/classes/Date.html
	/// </remarks>
	[TestFixture]
	public class DateTimeExtensions_GivenDate
	{
		private readonly TimeSpan _midnight = new TimeSpan(0, 0, 0);
		private readonly TimeSpan _endOfDay = new TimeSpan(23, 59, 59);
		private readonly int[] _q1 = new[] { 1, 2, 3 };
		private readonly int[] _q2 = new[] { 4, 5, 6 };
		private readonly int[] _q3 = new[] { 7, 8, 9 };
		private readonly int[] _q4 = new[] { 10, 11, 12 };

		private readonly IEnumerable<DateTime> _randomDates
			= new List<DateTime>
			  	{
			  		new DateTime(2012, 12, 21, 10, 0, 0),	//End of the world at 10:00
			  		new DateTime(1944, 6, 6, 14, 45, 13),	//D-Day shortly after 14:45
			  		new DateTime(1900, 7, 4, 8, 10, 49),	//July 4th, 1900 shortly after 08:10
					DateTime.Now
			  	};

		private readonly IEnumerable<DateTime> _dateInEachMonth
			= new List<DateTime>
			  	{
			  		new DateTime(2000, 1, 6, 10, 0, 0),
					new DateTime(2001, 2, 7, 10, 0, 0),
					new DateTime(2002, 3, 8, 10, 0, 0),
					new DateTime(2003, 4, 9, 10, 0, 0),
					new DateTime(2004, 5, 10, 10, 0, 0),
					new DateTime(2005, 6, 11, 10, 0, 0),
					new DateTime(2006, 7, 12, 10, 0, 0),
					new DateTime(2007, 8, 13, 10, 0, 0),
					new DateTime(2008, 9, 14, 10, 0, 0),
					new DateTime(2009, 10, 15, 10, 0, 0),
					new DateTime(2010, 11, 16, 10, 0, 0),
					new DateTime(2011, 12, 17, 10, 0, 0)
			  	};

		[Test]
		public void it_should_return_the_date_at_the_beginning_of_the_day()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtBeginningOfDay();

				Assert.That(expected.Date, Is.EqualTo(date.Date));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_midnight));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_beginning_of_the_week()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtBeginningOfWeek();

				Assert.That(expected.DayOfWeek, Is.EqualTo(DayOfWeek.Sunday));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_midnight));
				Assert.That(date.Day, Is.GreaterThanOrEqualTo(expected.Day));
				Assert.That(date.Day - expected.Day, Is.AtMost(6));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_beginning_of_the_month()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtBeginningOfMonth();

				Assert.That(expected.Date, Is.EqualTo(new DateTime(expected.Year, expected.Month, 1)));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_midnight));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_beginning_of_the_quarter()
		{
			foreach (var date in _dateInEachMonth)
			{
				DateTime expected = date.AtBeginningOfQuarter();

				if (_q1.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 1, 1).AtBeginningOfDay())); }
				if (_q2.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 3, 1).AtBeginningOfDay())); }
				if (_q3.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 7, 1).AtBeginningOfDay())); }
				if (_q4.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 10, 1).AtBeginningOfDay())); }
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_beginning_of_the_year()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtBeginningOfYear();

				Assert.That(expected.Date, Is.EqualTo(new DateTime(expected.Year, 1, 1)));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_midnight));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_end_of_the_day()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtEndOfDay();

				Assert.That(expected.Date, Is.EqualTo(date.Date));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_endOfDay));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_end_of_the_week()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtEndOfWeek();

				Assert.That(expected.DayOfWeek, Is.EqualTo(DayOfWeek.Saturday));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_endOfDay));
				Assert.That(date.Day, Is.LessThanOrEqualTo(expected.Day));
				Assert.That(expected.Day - date.Day, Is.AtMost(6));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_end_of_the_month()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected				= date.AtEndOfMonth();
				DateTime beginningOfNextMonth	= expected.AtBeginningOfMonth().AddMonths(1);

				Assert.That(expected.Date, Is.EqualTo(beginningOfNextMonth.AddDays(-1)));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_endOfDay));
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_end_of_the_quarter()
		{
			foreach (var date in _dateInEachMonth)
			{
				DateTime expected = date.AtEndOfQuarter();

				if (_q1.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 3, 31).AtEndOfDay())); }
				if (_q2.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 6, 30).AtEndOfDay())); }
				if (_q3.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 9, 30).AtEndOfDay())); }
				if (_q4.Contains(date.Month)) { Assert.That(expected, Is.EqualTo(new DateTime(date.Year, 12, 31).AtEndOfDay())); }
			}
		}

		[Test]
		public void it_should_return_the_date_at_the_end_of_the_year()
		{
			foreach (var date in _randomDates)
			{
				DateTime expected = date.AtEndOfYear();

				Assert.That(expected.Date, Is.EqualTo(new DateTime(expected.Year, 12, 31)));
				Assert.That(expected.TimeOfDay, Is.EqualTo(_endOfDay));
			}
		}
	}

	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the C4SC port of the helpers in the Rails Date class. All 
	/// tests in this suite require a testable DateTime.Now value.
	/// </summary>
	/// /// <remarks>
	/// http://api.rubyonrails.org/classes/Date.html
	/// </remarks>
	[TestFixture]
	public class DateTimeExtensions_DateTimeNow
	{
		#region Setup / TearDown

		private IDateTimeNowAdapter _nowAdapter;

		/// <summary>
		/// Executes individual Test-level setup and initialization prior to each test being run.
		/// </summary>
		[SetUp]
		public void SetUpTest()
		{
			_nowAdapter = new TestDateTimeNowAdapter(new DateTime(2012, 1, 21, 23, 0, 0));
			DateTimeExtensions.SetDateTimeNowAdapter(_nowAdapter);
		}

		/// <summary>
		/// Executes individual Test-level clean-up after each test has been run. This method is guaranteed to run 
		/// even if an exception is thrown.
		/// </summary>
		[TearDown]
		public void TearDownTest()
		{
			DateTimeExtensions.SetDateTimeNowAdapter(new SystemDateTimeNowAdapter());
		}

		#endregion

		[Test]
		public void it_should_determine_if_the_date_is_in_the_future()
		{
			Assert.True(_nowAdapter.DateTimeNow().AddYears(1).IsFuture());
			Assert.True(_nowAdapter.DateTimeNow().AddMonths(1).IsFuture());
			Assert.True(_nowAdapter.DateTimeNow().AddDays(1).IsFuture());
			Assert.True(_nowAdapter.DateTimeNow().AddHours(1).IsFuture());
			Assert.True(_nowAdapter.DateTimeNow().AddMinutes(1).IsFuture());
			Assert.True(_nowAdapter.DateTimeNow().AddSeconds(1).IsFuture());
			Assert.True(_nowAdapter.DateTimeNow().AddMilliseconds(1).IsFuture());

			Assert.False(_nowAdapter.DateTimeNow().AddYears(-1).IsFuture());
			Assert.False(_nowAdapter.DateTimeNow().AddMonths(-1).IsFuture());
			Assert.False(_nowAdapter.DateTimeNow().AddDays(-1).IsFuture());
			Assert.False(_nowAdapter.DateTimeNow().AddHours(-1).IsFuture());
			Assert.False(_nowAdapter.DateTimeNow().AddMinutes(-1).IsFuture());
			Assert.False(_nowAdapter.DateTimeNow().AddSeconds(-1).IsFuture());
			Assert.False(_nowAdapter.DateTimeNow().AddMilliseconds(-1).IsFuture());
		}

		[Test]
		public void it_should_determine_if_the_date_is_in_the_past()
		{
			Assert.False(_nowAdapter.DateTimeNow().AddYears(1).IsPast());
			Assert.False(_nowAdapter.DateTimeNow().AddMonths(1).IsPast());
			Assert.False(_nowAdapter.DateTimeNow().AddDays(1).IsPast());
			Assert.False(_nowAdapter.DateTimeNow().AddHours(1).IsPast());
			Assert.False(_nowAdapter.DateTimeNow().AddMinutes(1).IsPast());
			Assert.False(_nowAdapter.DateTimeNow().AddSeconds(1).IsPast());
			Assert.False(_nowAdapter.DateTimeNow().AddMilliseconds(1).IsPast());

			Assert.True(_nowAdapter.DateTimeNow().AddYears(-1).IsPast());
			Assert.True(_nowAdapter.DateTimeNow().AddMonths(-1).IsPast());
			Assert.True(_nowAdapter.DateTimeNow().AddDays(-1).IsPast());
			Assert.True(_nowAdapter.DateTimeNow().AddHours(-1).IsPast());
			Assert.True(_nowAdapter.DateTimeNow().AddMinutes(-1).IsPast());
			Assert.True(_nowAdapter.DateTimeNow().AddSeconds(-1).IsPast());
			Assert.True(_nowAdapter.DateTimeNow().AddMilliseconds(-1).IsPast());
		}

		[Test]
		public void it_should_determine_if_the_date_is_todays_date()
		{
			Assert.False(_nowAdapter.DateTimeNow().AddYears(1).IsToday());
			Assert.False(_nowAdapter.DateTimeNow().AddMonths(1).IsToday());
			Assert.False(_nowAdapter.DateTimeNow().AddDays(1).IsToday());
			Assert.False(_nowAdapter.DateTimeNow().AddHours(1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddMinutes(1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddSeconds(1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddMilliseconds(1).IsToday());

			Assert.False(_nowAdapter.DateTimeNow().AddYears(-1).IsToday());
			Assert.False(_nowAdapter.DateTimeNow().AddMonths(-1).IsToday());
			Assert.False(_nowAdapter.DateTimeNow().AddDays(-1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddHours(-1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddMinutes(-1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddSeconds(-1).IsToday());
			Assert.True(_nowAdapter.DateTimeNow().AddMilliseconds(-1).IsToday());
		}
	}
}
