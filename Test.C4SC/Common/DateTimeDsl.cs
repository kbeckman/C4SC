using System;
using C4SC.Common;
using C4SC.Common.Testability;
using NUnit.Framework;

namespace Test.C4SC.Common
{
	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the singular C4SC DateTime DSL methods (Year, Month, etc.)
	/// </summary>
	[TestFixture]
	public class DateTimeDsl_Singular_DateTimeNow
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
			
		#region Addition Methods - Without Chaining

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

		#region Subtraction Methods - Without Chaining

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
		public void it_should_subtract_1_minute_from_now()
		{
			DateTime actual		= 1.Minute().Ago();
			DateTime expected	= _nowAdapter.DateTimeNow().AddMinutes(-1);

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
	}

	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the C4SC DateTime DSL.
	/// </summary>
	[TestFixture]
	public class DateTimeDsl_Plural_GivenDate
	{
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

		#region Plural Subtraction Methods - Without Chaining

		[Test]
		[TestCase(1)]
		[TestCase(10)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_subtract_years_from_a_date(Int32 arg)
		{
			DateTime nineEleven = new DateTime(2011, 9, 11);
			DateTime actual		= arg.Years().AgoFrom(nineEleven);

			Assert.That(actual, Is.EqualTo(nineEleven.AddYears(-arg)));
		}

		[Test]
		[TestCase(6)]
		[TestCase(12)]
		[TestCase(24)]
		[TestCase(48)]
		public void it_should_subtract_months_from_a_date(Int32 arg)
		{
			DateTime kentuckyDerby	= new DateTime(2011, 5, 7);
			DateTime actual			= arg.Months().AgoFrom(kentuckyDerby);

			Assert.That(actual, Is.EqualTo(kentuckyDerby.AddMonths(-arg)));
		}

		[Test]
		[TestCase(1)]
		[TestCase(5)]
		[TestCase(7)]
		[TestCase(30)]
		public void it_should_subtract_days_from_a_date(Int32 arg)
		{
			DateTime lastMonday = new DateTime(2011, 11, 14);
			DateTime actual		= arg.Days().AgoFrom(lastMonday);

			Assert.That(actual, Is.EqualTo(lastMonday.AddDays(-arg)));
		}

		[Test]
		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		[TestCase(60)]
		public void it_should_subtract_minutes_from_a_timestamp(Int32 arg)
		{
			DateTime kickoff	= new DateTime(2011, 11, 20, 15, 0, 0);
			DateTime actual		= arg.Minutes().AgoFrom(kickoff);

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
			DateTime actual			= arg.Seconds().AgoFrom(mileRelayStart);

			Assert.That(actual, Is.EqualTo(mileRelayStart.AddSeconds(-arg)));
		}

		[Test]
		[TestCase(150)]
		[TestCase(267)]
		[TestCase(644)]
		[TestCase(932)]
		public void it_should_stubract_milliseconds_from_a_timestamp(Int32 arg)
		{
			DateTime executionTime	= new DateTime(2011, 06, 30, 0, 0, 0);
			DateTime actual			= arg.Milliseconds().AgoFrom(executionTime);

			Assert.That(actual, Is.EqualTo(executionTime.AddMilliseconds(-arg)));
		}

		#endregion
	}
}
