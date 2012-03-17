using System;

namespace C4SC.Core.Testability
{
	/// <summary>
	/// Defines a service for providing the DateTime.Now value. This can be used in testing scenarios to provide a 
	/// testable DateTime.Now value configurable from unit test setup methods.
	/// </summary>
	public interface IDateTimeNowAdapter
	{
		DateTime DateTimeNow();
	}

	/// <summary>
	/// IDateTimeNowAdapter implementation that provides the system's actual DateTime.Now value.
	/// </summary>
	public class SystemDateTimeNowAdapter : IDateTimeNowAdapter
	{
		public DateTime DateTimeNow()
		{
			return DateTime.Now;
		}
	}

	/// <summary>
	/// IDateTimeNowAdapter implementation that provides configurable DateTime.Now value for use in unit testing.
	/// </summary>
	public class TestDateTimeNowAdapter : IDateTimeNowAdapter
	{
		private readonly DateTime _dateTimeNowValue;

		public TestDateTimeNowAdapter(DateTime dateTimeNowValue)
		{
			_dateTimeNowValue = dateTimeNowValue;
		}

		public DateTime DateTimeNow()
		{
			return _dateTimeNowValue;
		}
	}
}
