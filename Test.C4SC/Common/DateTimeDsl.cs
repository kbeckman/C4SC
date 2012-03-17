using System;
using C4SC.Core;
using C4SC.Core.Testability;
using NUnit.Framework;

namespace Test.C4SC.Common
{
	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the singular C4SC DateTime DSL methods (Year, Month, etc.)
	/// </summary>
	[TestFixture]
	public class DateTimeDsl_DateTimeNow
	{
		#region Setup / TearDown

		private IDateTimeNowAdapter _nowAdapter;

		/// <summary>
		/// Executes individual Test-level setup and initialization prior to each test being run.
		/// </summary>
		[SetUp]
		public void SetUpTest()
		{
			_nowAdapter = new TestDateTimeNowAdapter(DateTime.Now);
			DateTimeComponentsConversionToDateTime.SetDateTimeNowAdapter(_nowAdapter);
		}

		/// <summary>
		/// Executes individual Test-level clean-up after each test has been run. This method is guaranteed to run 
		/// even if an exception is thrown.
		/// </summary>
		[TearDown]
		public void TearDownTest()
		{
			DateTimeComponentsConversionToDateTime.SetDateTimeNowAdapter(new SystemDateTimeNowAdapter());
		}

		#endregion
			
		#region Singular Addition Methods - Without Chaining

		[Test]
		public void it_should_add_1_year_to_now()
		{
			DateTime actual		= 1.Year().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddYears(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_add_1_month_to_now()
		{
			DateTime actual		= 1.Month().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMonths(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_add_1_day_to_now()
		{
			DateTime actual		= 1.Day().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_add_1_week_to_now()
		{
			DateTime actual		= 1.Week().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(7);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_add_1_minute_to_now()
		{
			DateTime actual		= 1.Minute().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMinutes(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_add_1_second_to_now()
		{
			DateTime actual		= 1.Second().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddSeconds(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_add_1_millisecond_to_now()
		{
			DateTime actual		= 1.Millisecond().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMilliseconds(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Plural Addition Methods - Without Chaining

		[Test]
		[TestCase(1)]
		[TestCase(10)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_add_years_to_now(Int32 arg)
		{
			DateTime actual		= arg.Years().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddYears(arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(6)]
		[TestCase(12)]
		[TestCase(24)]
		[TestCase(48)]
		public void it_should_add_months_to_now(Int32 arg)
		{
			DateTime actual		= arg.Months().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMonths(arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(6)]
		[TestCase(12)]
		[TestCase(24)]
		[TestCase(48)]
		public void it_should_add_weeks_to_now(Int32 arg)
		{
			DateTime actual		= arg.Weeks().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(arg * 7);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(30)]
		public void it_should_add_days_to_now(Int32 arg)
		{
			DateTime actual		= arg.Days().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		[TestCase(60)]
		public void it_should_add_minutes_to_now(Int32 arg)
		{
			DateTime actual		= arg.Minutes().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMinutes(arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(55)]
		[TestCase(109)]
		[TestCase(166)]
		[TestCase(216)]
		public void it_should_add_seconds_to_now(Int32 arg)
		{
			DateTime actual		= arg.Seconds().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddSeconds(arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(150)]
		[TestCase(267)]
		[TestCase(644)]
		[TestCase(932)]
		public void it_should_add_milliseconds_to_now(Int32 arg)
		{
			DateTime actual		= arg.Milliseconds().FromNow();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMilliseconds(arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Singular Addition Methods - Chaining

		[Test]
		public void it_should_add_1_of_each_component_to_now()
		{
			DateTime actual	= 1.Year()
							.And(1.Month())
							.And(1.Day())
							.And(1.Week())
							.And(1.Minute())
							.And(1.Second())
							.And(1.Millisecond()).FromNow();

			DateTime expected = _nowAdapter.DateTimeNow().AddYears(1)
									.AddMonths(1)
									.AddDays(8)
									.AddMinutes(1)
									.AddSeconds(1)
									.AddMilliseconds(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Plural Addition Methods - Chaining

		[Test]
		[TestCase(1, 2, 2, 3, 4, 5, 6)]
		[TestCase(2, 4, 3, 6, 8, 10, 12)]
		[TestCase(5, 10, 4, 15, 20, 25, 30)]
		[TestCase(100, 200, 5, 300, 400, 500, 600)]
		public void it_should_add_all_components_to_now(Int32 years, Int32 months, Int32 weeks, Int32 days, Int32 minutes, Int32 seconds, Int32 milliseconds)
		{
			DateTime actual	= years.Years()
								.And(months.Months())
								.And(days.Days())
								.And(weeks.Weeks())
								.And(minutes.Minutes())
								.And(seconds.Seconds())
								.And(milliseconds.Milliseconds()).FromNow();

			DateTime expected = _nowAdapter.DateTimeNow().AddYears(years)
									.AddMonths(months)
									.AddDays(days + (weeks * 7))
									.AddMinutes(minutes)
									.AddSeconds(seconds)
									.AddMilliseconds(milliseconds);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Singular Subtraction Methods - Without Chaining

		[Test]
		public void it_should_subtract_1_year_from_now()
		{
			DateTime actual		= 1.Year().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddYears(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_subtract_1_month_from_now()
		{
			DateTime actual		= 1.Month().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMonths(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_subtract_1_week_from_now()
		{
			DateTime actual		= 1.Week().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(-7);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_subtract_1_day_from_now()
		{
			DateTime actual		= 1.Day().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_subtract_1_minute_from_now()
		{
			DateTime actual		= 1.Minute().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMinutes(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}
		
		[Test]
		public void it_should_subtract_1_second_from_now()
		{
			DateTime actual		= 1.Second().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddSeconds(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void it_should_subtract_1_millisecond_from_now()
		{
			DateTime actual		= 1.Millisecond().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMilliseconds(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Plural Subtraction Methods - Without Chaining

		[Test]
		[TestCase(1)]
		[TestCase(10)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_subtract_years_from_now(Int32 arg)
		{
			DateTime actual		= arg.Years().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddYears(-arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(6)]
		[TestCase(12)]
		[TestCase(24)]
		[TestCase(48)]
		public void it_should_subtract_months_from_now(Int32 arg)
		{
			DateTime actual		= arg.Months().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMonths(-arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(2)]
		[TestCase(3)]
		[TestCase(10)]
		[TestCase(12)]
		public void it_should_subtract_weeks_from_now(Int32 arg)
		{
			DateTime actual		= arg.Weeks().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(-(arg * 7));

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(30)]
		public void it_should_subtract_days_from_now(Int32 arg)
		{
			DateTime actual		= arg.Days().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddDays(-arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		[TestCase(60)]
		public void it_should_subtract_minutes_from_now(Int32 arg)
		{
			DateTime actual		= arg.Minutes().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMinutes(-arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(55)]
		[TestCase(109)]
		[TestCase(166)]
		[TestCase(216)]
		public void it_should_subtract_seconds_from_now(Int32 arg)
		{
			DateTime actual		= arg.Seconds().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddSeconds(-arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		[TestCase(150)]
		[TestCase(267)]
		[TestCase(644)]
		[TestCase(932)]
		public void it_should_subtract_milliseconds_from_now(Int32 arg)
		{
			DateTime actual		= arg.Milliseconds().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMilliseconds(-arg);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Singular Subtraction Methods - Chaining

		[Test]
		public void it_should_subtract_1_of_each_component_from_now()
		{
			DateTime actual = 1.Year()
							.And(1.Month())
							.And(1.Week())
							.And(1.Day())
							.And(1.Minute())
							.And(1.Second())
							.And(1.Millisecond()).Ago();

			DateTime expected = _nowAdapter.DateTimeNow().AddYears(-1)
									.AddMonths(-1)
									.AddDays(-8)
									.AddMinutes(-1)
									.AddSeconds(-1)
									.AddMilliseconds(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Plural Subtraction Methods - Chaining

		[Test]
		[TestCase(1, 2, 2, 3, 4, 5, 6)]
		[TestCase(2, 4, 3, 6, 8, 10, 12)]
		[TestCase(5, 10, 4, 15, 20, 25, 30)]
		[TestCase(100, 200, 5, 300, 400, 500, 600)]
		public void it_should_subtract_all_components_from_now(Int32 years, Int32 months, Int32 weeks, Int32 days, Int32 minutes, Int32 seconds, Int32 milliseconds)
		{
			DateTime actual = years.Years()
								.And(months.Months())
								.And(weeks.Weeks())
								.And(days.Days())
								.And(minutes.Minutes())
								.And(seconds.Seconds())
								.And(milliseconds.Milliseconds()).Ago();

			DateTime expected = _nowAdapter.DateTimeNow().AddYears(-years)
									.AddMonths(-months)
									.AddDays(-days + -(weeks * 7))
									.AddMinutes(-minutes)
									.AddSeconds(-seconds)
									.AddMilliseconds(-milliseconds);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion
	}

	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the C4SC DateTime DSL.
	/// </summary>
	[TestFixture]
	public class DateTimeDsl_GivenDate
	{
		#region Singular Addition Methods - Without Chaining

		[Test]
		public void it_should_add_1_year_to_a_date()
		{
			DateTime nineEleven = new DateTime(2011, 9, 11);
			DateTime actual		= 1.Year().From(nineEleven);

			Assert.That(actual, Is.EqualTo(nineEleven.AddYears(1)));
		}

		[Test]
		public void it_should_add_1_month_to_a_date()
		{
			DateTime kentuckyDerby	= new DateTime(2011, 5, 7);
			DateTime actual			= 1.Month().From(kentuckyDerby);

			Assert.That(actual, Is.EqualTo(kentuckyDerby.AddMonths(1)));
		}

		[Test]
		public void it_should_add_1_week_to_a_date()
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= 1.Week().From(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(7)));
		}

		[Test]
		public void it_should_add_1_day_to_a_date()
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= 1.Day().From(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(1)));
		}

		[Test]
		public void it_should_add_1_minute_to_a_timestamp()
		{
			DateTime kickoff	= new DateTime(2011, 11, 20, 15, 0, 0);
			DateTime actual		= 1.Minute().From(kickoff);

			Assert.That(actual, Is.EqualTo(kickoff.AddMinutes(1)));
		}

		[Test]
		public void it_should_add_1_second_to_a_timestamp()
		{
			DateTime mileRelayStart = new DateTime(2000, 4, 10, 15, 0, 0);
			DateTime actual			= 1.Second().From(mileRelayStart);

			Assert.That(actual, Is.EqualTo(mileRelayStart.AddSeconds(1)));
		}

		[Test]
		public void it_should_add_1_millisecond_to_a_timestamp()
		{
			DateTime executionTime	= new DateTime(2011, 06, 30, 0, 0, 0);
			DateTime actual			= 1.Second().From(executionTime);

			Assert.That(actual, Is.EqualTo(executionTime.AddSeconds(1)));
		}

		#endregion

		#region Plural Addition Methods - Without Chaining

		[Test]
		[TestCase(1)]
		[TestCase(10)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_add_years_to_a_date(Int32 arg)
		{
			DateTime nineEleven = new DateTime(2011, 9, 11);
			DateTime actual		= arg.Years().From(nineEleven);

			Assert.That(actual, Is.EqualTo(nineEleven.AddYears(arg)));
		}

		[Test]
		[TestCase(6)]
		[TestCase(12)]
		[TestCase(24)]
		[TestCase(48)]
		public void it_should_add_months_to_a_date(Int32 arg)
		{
			DateTime kentuckyDerby	= new DateTime(2011, 5, 7);
			DateTime actual			= arg.Months().From(kentuckyDerby);

			Assert.That(actual, Is.EqualTo(kentuckyDerby.AddMonths(arg)));
		}

		[Test]
		[TestCase(4)]
		[TestCase(8)]
		[TestCase(12)]
		[TestCase(24)]
		public void it_should_add_weeks_to_a_date(Int32 arg)
		{
			DateTime kentuckyDerby	= new DateTime(2011, 5, 7);
			DateTime actual			= arg.Weeks().From(kentuckyDerby);

			Assert.That(actual, Is.EqualTo(kentuckyDerby.AddDays(arg * 7)));
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(30)]
		public void it_should_add_days_to_a_date(Int32 arg)
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= arg.Days().From(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(arg)));
		}

		[Test]
		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		[TestCase(60)]
		public void it_should_add_minutes_to_a_timestamp(Int32 arg)
		{
			DateTime kickoff	= new DateTime(2011, 11, 20, 15, 0, 0);
			DateTime actual		= arg.Minutes().From(kickoff);

			Assert.That(actual, Is.EqualTo(kickoff.AddMinutes(arg)));
		}

		[Test]
		[TestCase(55)]
		[TestCase(109)]
		[TestCase(166)]
		[TestCase(216)]
		public void it_should_add_seconds_to_a_timestamp(Int32 arg)
		{
			DateTime mileRelayStart = new DateTime(2000, 4, 10, 15, 0, 0);
			DateTime actual			= arg.Seconds().From(mileRelayStart);

			Assert.That(actual, Is.EqualTo(mileRelayStart.AddSeconds(arg)));
		}

		[Test]
		[TestCase(150)]
		[TestCase(267)]
		[TestCase(644)]
		[TestCase(932)]
		public void it_should_add_milliseconds_to_a_timestamp(Int32 arg)
		{
			DateTime executionTime	= new DateTime(2011, 06, 30, 0, 0, 0);
			DateTime actual			= arg.Seconds().From(executionTime);

			Assert.That(actual, Is.EqualTo(executionTime.AddSeconds(arg)));
		}

		#endregion

		#region Singular Addition Methods - Chaining

		[Test]
		public void it_should_add_1_of_each_component_to_a_timestamp()
		{
			DateTime twentyTwelve = new DateTime(2012, 1, 1, 0, 0, 0, 0);

			DateTime actual = 1.Year()
							.And(1.Month())
							.And(1.Week())
							.And(1.Day())
							.And(1.Minute())
							.And(1.Second())
							.And(1.Millisecond()).From(twentyTwelve);

			DateTime expected = twentyTwelve.AddYears(1)
									.AddMonths(1)
									.AddDays(8)
									.AddMinutes(1)
									.AddSeconds(1)
									.AddMilliseconds(1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Plural Addition Methods - Chaining

		[Test]
		[TestCase(1, 2, 2, 3, 4, 5, 6)]
		[TestCase(2, 4, 3, 6, 8, 10, 12)]
		[TestCase(5, 10, 4, 15, 20, 25, 30)]
		[TestCase(100, 200, 5, 300, 400, 500, 600)]
		public void it_should_add_all_components_to_a_timestamp(Int32 years, Int32 months, Int32 weeks, Int32 days, Int32 minutes, Int32 seconds, Int32 milliseconds)
		{
			DateTime twentyTwelve = new DateTime(2012, 1, 1, 0, 0, 0, 0);

			DateTime actual = years.Years()
								.And(months.Months())
								.And(weeks.Weeks())
								.And(days.Days())
								.And(minutes.Minutes())
								.And(seconds.Seconds())
								.And(milliseconds.Milliseconds()).From(twentyTwelve);

			DateTime expected = twentyTwelve.AddYears(years)
									.AddMonths(months)
									.AddDays(days + (weeks * 7))
									.AddMinutes(minutes)
									.AddSeconds(seconds)
									.AddMilliseconds(milliseconds);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Singular Subtraction Methods - Without Chaining

		[Test]
		public void it_should_subtract_1_year_from_a_date()
		{
			DateTime nineEleven = new DateTime(2011, 9, 11);
			DateTime actual		= 1.Year().AgoFrom(nineEleven);

			Assert.That(actual, Is.EqualTo(nineEleven.AddYears(-1)));
		}

		[Test]
		public void it_should_subtract_1_month_from_a_date()
		{
			DateTime kentuckyDerby	= new DateTime(2011, 5, 7);
			DateTime actual			= 1.Month().AgoFrom(kentuckyDerby);

			Assert.That(actual, Is.EqualTo(kentuckyDerby.AddMonths(-1)));
		}

		[Test]
		public void it_should_subtract_1_week_from_a_date()
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= 1.Week().AgoFrom(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(-7)));
		}

		[Test]
		public void it_should_subtract_1_day_from_a_date()
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= 1.Day().AgoFrom(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(-1)));
		}

		[Test]
		public void it_should_subtract_1_minute_from_a_timestamp()
		{
			DateTime kickoff	= new DateTime(2011, 11, 20, 15, 0, 0);
			DateTime actual		= 1.Minute().AgoFrom(kickoff);

			Assert.That(actual, Is.EqualTo(kickoff.AddMinutes(-1)));
		}

		[Test]
		public void it_should_subtract_1_second_from_a_timestamp()
		{
			DateTime mileRelayStart = new DateTime(2000, 4, 10, 15, 0, 0);
			DateTime actual			= 1.Second().AgoFrom(mileRelayStart);

			Assert.That(actual, Is.EqualTo(mileRelayStart.AddSeconds(-1)));
		}

		[Test]
		public void it_should_stubract_1_millisecond_from_a_timestamp()
		{
			DateTime executionTime	= new DateTime(2011, 06, 30, 0, 0, 0);
			DateTime actual			= 1.Millisecond().AgoFrom(executionTime);

			Assert.That(actual, Is.EqualTo(executionTime.AddMilliseconds(-1)));
		}

		#endregion

		#region Plural Subtraction Methods - Without Chaining

		[Test]
		[TestCase(1)]
		[TestCase(10)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_subtract_years_from_a_date(Int32 arg)
		{
			DateTime nineEleven = new DateTime(2011, 9, 11);
			DateTime actual = arg.Years().AgoFrom(nineEleven);

			Assert.That(actual, Is.EqualTo(nineEleven.AddYears(-arg)));
		}

		[Test]
		[TestCase(6)]
		[TestCase(12)]
		[TestCase(24)]
		[TestCase(48)]
		public void it_should_subtract_months_from_a_date(Int32 arg)
		{
			DateTime kentuckyDerby = new DateTime(2011, 5, 7);
			DateTime actual = arg.Months().AgoFrom(kentuckyDerby);

			Assert.That(actual, Is.EqualTo(kentuckyDerby.AddMonths(-arg)));
		}

		[Test]
		[TestCase(2)]
		[TestCase(4)]
		[TestCase(6)]
		[TestCase(12)]
		public void it_should_subtract_weeks_from_a_date(Int32 arg)
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= arg.Weeks().AgoFrom(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(-(arg * 7))));
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(30)]
		public void it_should_subtract_days_from_a_date(Int32 arg)
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual = arg.Days().AgoFrom(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(-arg)));
		}

		[Test]
		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		[TestCase(60)]
		public void it_should_subtract_minutes_from_a_timestamp(Int32 arg)
		{
			DateTime kickoff = new DateTime(2011, 11, 20, 15, 0, 0);
			DateTime actual = arg.Minutes().AgoFrom(kickoff);

			Assert.That(actual, Is.EqualTo(kickoff.AddMinutes(-arg)));
		}

		[Test]
		[TestCase(55)]
		[TestCase(109)]
		[TestCase(166)]
		[TestCase(216)]
		public void it_should_subtract_seconds_from_a_timestamp(Int32 arg)
		{
			DateTime mileRelayStart = new DateTime(2000, 4, 10, 15, 0, 0);
			DateTime actual = arg.Seconds().AgoFrom(mileRelayStart);

			Assert.That(actual, Is.EqualTo(mileRelayStart.AddSeconds(-arg)));
		}

		[Test]
		[TestCase(150)]
		[TestCase(267)]
		[TestCase(644)]
		[TestCase(932)]
		public void it_should_stubract_milliseconds_from_a_timestamp(Int32 arg)
		{
			DateTime executionTime = new DateTime(2011, 06, 30, 0, 0, 0);
			DateTime actual = arg.Milliseconds().AgoFrom(executionTime);

			Assert.That(actual, Is.EqualTo(executionTime.AddMilliseconds(-arg)));
		}

		#endregion

		#region Singular Subtraction Methods - Chaining

		[Test]
		public void it_should_subtract_1_of_each_component_from_a_timestamp()
		{
			DateTime twentyTwelve = new DateTime(2012, 1, 1, 0, 0, 0, 0);

			DateTime actual = 1.Year()
							.And(1.Month())
							.And(1.Week())
							.And(1.Day())
							.And(1.Minute())
							.And(1.Second())
							.And(1.Millisecond()).AgoFrom(twentyTwelve);

			DateTime expected = twentyTwelve.AddYears(-1)
									.AddMonths(-1)
									.AddDays(-8)
									.AddMinutes(-1)
									.AddSeconds(-1)
									.AddMilliseconds(-1);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion

		#region Plural Subtraction Methods - Chaining

		[Test]
		[TestCase(1, 2, 2, 3, 4, 5, 6)]
		[TestCase(2, 4, 3, 6, 8, 10, 12)]
		[TestCase(5, 10, 4, 15, 20, 25, 30)]
		[TestCase(100, 200, 5, 300, 400, 500, 600)]
		public void it_should_subtract_all_components_from_a_timestamp(Int32 years, Int32 months, Int32 weeks, Int32 days, Int32 minutes, Int32 seconds, Int32 milliseconds)
		{
			DateTime twentyTwelve = new DateTime(2012, 1, 1, 0, 0, 0, 0);

			DateTime actual = years.Years()
								.And(months.Months())
								.And(weeks.Weeks())
								.And(days.Days())
								.And(minutes.Minutes())
								.And(seconds.Seconds())
								.And(milliseconds.Milliseconds()).AgoFrom(twentyTwelve);

			DateTime expected = twentyTwelve.AddYears(-years)
									.AddMonths(-months)
									.AddDays(-days + -(weeks * 7))
									.AddMinutes(-minutes)
									.AddSeconds(-seconds)
									.AddMilliseconds(-milliseconds);

			Assert.That(actual, Is.EqualTo(expected));
		}

		#endregion
	}
}
