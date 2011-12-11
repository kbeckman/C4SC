using System;

namespace C4SC.Common.Testable
{
	/// <summary>
	/// Defines a service for providing the DateTime.Now value. This can be used in testing scenarios to provide a 
	/// testable DateTime.Now value configurable from unit test setup methods.
	/// </summary>
	public interface IDateTimeNowProvider
	{
		DateTime DateTimeNow();
	}

	/// <summary>
	/// DateTimeNowProvider that provides the system's actual DateTime.Now value.
	/// </summary>
	public class SystemDateTimeNowProvider : IDateTimeNowProvider
	{
		public DateTime DateTimeNow()
		{
			return DateTime.Now;
		}
	}

	/// <summary>
	/// DateTimeNowProvider that provides configurable DateTime.Now value for use in unit testing.
	/// </summary>
	public class TestDateTimeNowProvider : IDateTimeNowProvider
	{
		private readonly DateTime _dateTimeNowValue;

		public TestDateTimeNowProvider(DateTime dateTimeNowValue)
		{
			_dateTimeNowValue = dateTimeNowValue;
		}

		public DateTime DateTimeNow()
		{
			return _dateTimeNowValue;
		}
	}
}
