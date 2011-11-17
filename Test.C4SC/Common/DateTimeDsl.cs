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
		#region Singular Add/Subtract Methods Without Chaining

		[Test]
		public void it_should_add_1_year_to_now()
		{
			DateTime actual		= 1.Year().FromNow();
			DateTime expected	= DateTime.Now.AddYears(1);

			Assert.That(actual.Year, Is.EqualTo(expected.Year));
			Assert.That(actual.Month, Is.EqualTo(expected.Month));
			Assert.That(actual.Day, Is.EqualTo(expected.Day));
			Assert.That(actual.Minute, Is.EqualTo(expected.Minute));
			Assert.That(actual.Second, Is.AtLeast(expected.Second));
			Assert.That(actual.Millisecond, Is.AtLeast(expected.Millisecond));
		}

		[Test]
		public void it_should_add_1_month_to_now()
		{
			DateTime actual = 1.Month().FromNow();
			Assert.That(actual.Month, Is.EqualTo(DateTime.Now.AddMonths(1).Month));
		}

		[Test]
		public void it_should_add_1_day_to_now()
		{
			DateTime actual = 1.Day().FromNow();
			Assert.That(actual.Day, Is.EqualTo(DateTime.Now.AddDays(1).Day));
		}

		[Test]
		public void it_should_add_1_minute_to_now()
		{
			DateTime actual = 1.Minute().FromNow();
			Assert.That(actual.Minute, Is.EqualTo(DateTime.Now.AddMinutes(1).Minute));
		}

		[Test]
		public void it_should_add_1_second_to_now()
		{
			DateTime actual = 1.Second().FromNow();
			Assert.That(actual.Second, Is.AtLeast(DateTime.Now.AddSeconds(1).Second));
			Assert.That(actual.Second, Is.AtMost(DateTime.Now.AddSeconds(2).Second));
		}

		[Test]
		public void it_should_add_1_millisecond_to_now()
		{
			DateTime actual = 1.MilliSecond().FromNow();
			Assert.That(actual.Millisecond, Is.AtLeast(DateTime.Now.AddMilliseconds(1).Millisecond));
			Assert.That(actual.Millisecond, Is.AtMost(DateTime.Now.AddMilliseconds(2).Millisecond));
		}

		[Test]
		public void it_should_subtract_1_year_from_now()
		{
			DateTime actual = 1.Year().Ago();
			DateTime expected = DateTime.Now.AddYears(-1);

			Assert.That(actual.Year, Is.EqualTo(expected.Year));
			Assert.That(actual.Month, Is.EqualTo(expected.Month));
			Assert.That(actual.Day, Is.EqualTo(expected.Day));
			Assert.That(actual.Minute, Is.EqualTo(expected.Minute));
			Assert.That(actual.Second, Is.AtLeast(expected.Second));
			Assert.That(actual.Millisecond, Is.AtLeast(expected.Millisecond));
		}

		[Test]
		public void it_should_subtract_1_month_from_now()
		{
			DateTime actual = 1.Month().Ago();
			Assert.That(actual.Month, Is.EqualTo(DateTime.Now.AddMonths(-1).Month));
		}

		[Test]
		public void it_should_subtract_1_minute_from_now()
		{
			DateTime actual = 1.Minute().Ago();
			Assert.That(actual.Minute, Is.EqualTo(DateTime.Now.AddMinutes(-1).Minute));
		}

		[Test]
		public void it_should_subtract_1_day_from_now()
		{
			DateTime actual = 1.Day().Ago();
			Assert.That(actual.Day, Is.EqualTo(DateTime.Now.AddDays(-1).Day));
		}

		[Test]
		public void it_should_subtract_1_second_from_now()
		{
			DateTime actual = 1.Second().Ago();
			Assert.That(actual.Second, Is.EqualTo(DateTime.Now.AddSeconds(-1).Second));
		}

		[Test]
		public void it_should_subtract_1_millisecond_from_now()
		{
			DateTime actual = 1.MilliSecond().Ago();
			Assert.That(actual.Millisecond, Is.AtMost(DateTime.Now.AddMilliseconds(-1).Millisecond));
			Assert.That(actual.Millisecond, Is.AtLeast(DateTime.Now.AddMilliseconds(-2).Millisecond));
		}
		
		#endregion

		#region Singular Add/Subtract Methods Without Chaining

		[Test]
		[TestCase(18)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_add_years_to_now(Int32 arg)
		{
			DateTime actual = arg.Years().FromNow();
			Assert.That(actual.Year, Is.EqualTo(DateTime.Now.AddYears(arg).Year));
		}

		[Test]
		[TestCase(18)]
		[TestCase(49)]
		[TestCase(100)]
		public void it_should_add_months_to_now(Int32 arg)
		{
			DateTime actual = arg.Years().FromNow();
			Assert.That(actual.Year, Is.EqualTo(DateTime.Now.AddYears(arg).Year));
		}

		#endregion
	}
}
