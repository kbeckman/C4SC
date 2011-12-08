using System;
using C4SC.Common;
using NUnit.Framework;

namespace Test.C4SC.Common
{
	/// <summary>
	/// NUnit TestFixture providing unit test coverage of the C4SC DateTime DSL.
	/// </summary>
	[TestFixture]
	public class DateTimeDsl
	{
		#region Singular Addition Methods - Without Chaining

		[Test]
		public void it_should_add_1_year_to_now()
		{
			DateTime actual		= 1.Year().FromNow();
			DateTime expected	= DateTime.Now.AddYears(1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_add_1_month_to_now()
		{
			DateTime actual		= 1.Month().FromNow();
			DateTime expected	= DateTime.Now.AddMonths(1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_add_1_day_to_now()
		{
			DateTime actual		= 1.Day().FromNow();
			DateTime expected	= DateTime.Now.AddDays(1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_add_1_minute_to_now()
		{
			DateTime actual		= 1.Minute().FromNow();
			DateTime expected	= DateTime.Now.AddMinutes(1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_add_1_second_to_now()
		{
			DateTime actual		= 1.Second().FromNow();
			DateTime expected	= DateTime.Now.AddSeconds(1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_add_1_millisecond_to_now()
		{
			DateTime actual = 1.MilliSecond().FromNow();
			Assert.Fail();
			Assert.That(actual.Millisecond, Is.AtLeast(DateTime.Now.AddMilliseconds(1).Millisecond));
			Assert.That(actual.Millisecond, Is.AtMost(DateTime.Now.AddMilliseconds(2).Millisecond));
		}

		#endregion

		#region Singular Subtraction Methods - Without Chaining

		[Test]
		public void it_should_subtract_1_year_from_now()
		{
			DateTime actual		= 1.Year().Ago();
			DateTime expected	= DateTime.Now.AddYears(-1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_subtract_1_month_from_now()
		{
			DateTime actual		= 1.Month().Ago();
			DateTime expected	= DateTime.Now.AddMonths(-1);
			
			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_subtract_1_minute_from_now()
		{
			DateTime actual		= 1.Minute().Ago();
			DateTime expected	= DateTime.Now.AddMinutes(-1);
			
			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_subtract_1_day_from_now()
		{
			DateTime actual = 1.Day().Ago();
			DateTime expected = DateTime.Now.AddDays(-1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_subtract_1_second_from_now()
		{
			DateTime actual		= 1.Second().Ago();
			DateTime expected	= DateTime.Now.AddSeconds(-1);

			InvokeAllDateTimeAssertions(actual, expected);
		}

		[Test]
		public void it_should_subtract_1_millisecond_from_now()
		{
			DateTime actual = 1.MilliSecond().Ago();
			Assert.Fail();
			Assert.That(actual.Millisecond, Is.AtMost(DateTime.Now.AddMilliseconds(-1).Millisecond));
			Assert.That(actual.Millisecond, Is.AtLeast(DateTime.Now.AddMilliseconds(-2).Millisecond));
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

			InvokeAllDateTimeAssertions(actual, nineEleven.AddYears(arg));
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

			InvokeAllDateTimeAssertions(actual, kentuckyDerby.AddMonths(arg));
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

			InvokeAllDateTimeAssertions(actual, lastMonday.AddDays(arg));
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

			InvokeAllDateTimeAssertions(actual, kickoff.AddMinutes(arg));
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

			InvokeAllDateTimeAssertions(actual, mileRelayStart.AddSeconds(arg));
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

			InvokeAllDateTimeAssertions(actual, executionTime.AddSeconds(arg));
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

			InvokeAllDateTimeAssertions(actual, nineEleven.AddYears(-arg));
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

			InvokeAllDateTimeAssertions(actual, kentuckyDerby.AddMonths(-arg));
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

			InvokeAllDateTimeAssertions(actual, lastMonday.AddDays(-arg));
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

			InvokeAllDateTimeAssertions(actual, kickoff.AddMinutes(-arg));
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

			InvokeAllDateTimeAssertions(actual, mileRelayStart.AddSeconds(-arg));
		}

		[Test]
		[TestCase(150)]
		[TestCase(267)]
		[TestCase(644)]
		[TestCase(932)]
		public void it_should_stubract_milliseconds_from_a_timestamp(Int32 arg)
		{
			DateTime executionTime	= new DateTime(2011, 06, 30, 0, 0, 0);
			DateTime actual			= arg.Seconds().From(executionTime);

			InvokeAllDateTimeAssertions(actual, executionTime.AddSeconds(arg));
		}

		#endregion
		
		/// <summary>
		/// Invokes all Assertion methods required to properly compare actual and expected DateTime values.
		/// </summary>
		/// <param name="actual">Actual (DSL calculated) DateTime value.</param>
		/// <param name="expected">Expected DateTime value.</param>
		private static void InvokeAllDateTimeAssertions(DateTime actual, DateTime expected)
		{
			Assert.That(actual.Year, Is.EqualTo(expected.Year));
			Assert.That(actual.Month, Is.EqualTo(expected.Month));
			Assert.That(actual.Day, Is.EqualTo(expected.Day));
			Assert.That(actual.Minute, Is.EqualTo(expected.Minute));
			//Assert.That(actual.Second, Is.AtLeast(expected.Second));
			//Assert.That(actual.Millisecond, Is.AtLeast(expected.Millisecond));	
		}
	}
}
