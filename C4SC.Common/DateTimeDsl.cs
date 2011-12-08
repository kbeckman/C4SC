using System;

namespace C4SC.Common
{
	/// <summary>
	/// Immutable semantic model for C4SC DateTime DSL.
	/// </summary>
	/// <remarks>
	/// http://martinfowler.com/dslCatalog/semanticModel.html
	/// </remarks>
	public struct DateTimeComponents
	{
		public DateTimeComponents(Int32 years, Int32 months, Int32 days, 
			Int32 minutes, Int32 seconds, Int32 milliseconds)
		{
			_years			= years;
			_months			= months;
			_days			= days;
			_minutes		= minutes;
			_seconds		= seconds;
			_milliseconds	= milliseconds;
		}

		private readonly Int32 _years;
		public Int32 Years { get { return _years; } }

		private readonly Int32 _months;
		public Int32 Months { get { return _months; } }

		private readonly Int32 _days;
		public Int32 Days { get { return _days; } }

		private readonly Int32 _minutes;
		public Int32 Minutes { get { return _minutes; } }

		private readonly Int32 _seconds;
		public Int32 Seconds { get { return _seconds; } }

		private readonly Int32 _milliseconds;
		public Int32 MilliSeconds { get { return _milliseconds; } }
	}

	/// <summary>
	/// Extension methods to convert Int32 values to their DateTimeComponents equivalent.
	/// </summary>
	public static class Int32ConversionToDateTimeComponents
	{
		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in years. 
		/// </summary>
		/// <param name="year">Number of years.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given year parameter.</returns>
		public static DateTimeComponents Year(this Int32 year)
		{
			return year.Years();
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in years. 
		/// </summary>
		/// <param name="years">Number of years.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given years parameter.</returns>
		public static DateTimeComponents Years(this Int32 years)
		{
			return new DateTimeComponents(years, 0, 0, 0, 0, 0);
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in months. 
		/// </summary>
		/// <param name="month">Number of months.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given month parameter.</returns>
		public static DateTimeComponents Month(this Int32 month)
		{
			return month.Months();
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in months. 
		/// </summary>
		/// <param name="months">Number of months.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given months parameter.</returns>
		public static DateTimeComponents Months(this Int32 months)
		{
			return new DateTimeComponents(0, months, 0, 0, 0, 0);
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in days. 
		/// </summary>
		/// <param name="day">Number of days.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given day parameter.</returns>
		public static DateTimeComponents Day(this Int32 day)
		{
			return day.Days();
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in days. 
		/// </summary>
		/// <param name="days">Number of days.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given days parameter.</returns>
		public static DateTimeComponents Days(this Int32 days)
		{
			return new DateTimeComponents(0, 0, days, 0, 0, 0);
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in minutes. 
		/// </summary>
		/// <param name="minute">Number of minutes.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given minute parameter.</returns>
		public static DateTimeComponents Minute(this Int32 minute)
		{
			return minute.Minutes();
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in minutes. 
		/// </summary>
		/// <param name="minutes">Number of minutes.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given minutes parameter.</returns>
		public static DateTimeComponents Minutes(this Int32 minutes)
		{
			return new DateTimeComponents(0, 0, 0, minutes, 0, 0);
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in seconds. 
		/// </summary>
		/// <param name="second">Number of seconds.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given second parameter.</returns>
		public static DateTimeComponents Second(this Int32 second)
		{
			return second.Seconds();
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in seconds. 
		/// </summary>
		/// <param name="seconds">Number of seconds.</param>
		/// /// <returns><see cref="DateTimeComponents"/> composed of the given seconds parameter.</returns>
		public static DateTimeComponents Seconds(this Int32 seconds)
		{
			return new DateTimeComponents(0, 0, 0, 0, seconds, 0);
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in milliseconds. 
		/// </summary>
		/// <param name="millisecond">Number of milliseconds.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given millisecond parameter.</returns>
		public static DateTimeComponents MilliSecond(this Int32 millisecond)
		{
			return millisecond.MilliSeconds();
		}

		/// <summary>
		/// Converts an Int32 to its equivalent DateTimeComponents representation in milliseconds. 
		/// </summary>
		/// <param name="milliseconds">Number of milliseconds.</param>
		/// <returns><see cref="DateTimeComponents"/> composed of the given milliseconds parameter.</returns>
		public static DateTimeComponents MilliSeconds(this Int32 milliseconds)
		{
			return new DateTimeComponents(0, 0, 0, 0, 0, milliseconds);
		}
	}

	/// <summary>
	/// Extension methods to calculate DateTime future or past result from DateTimeComponents operand.
	/// </summary>
	public static class DateTimeComponentsConversionToDateTime
	{
		/// <summary>
		/// Calculates the result of DateTimeComponents added to DateTime.Now().
		/// </summary>
		/// <param name="components"><see cref="DateTimeComponents"/> operand.</param>
		/// <returns>Future DateTime calculated from DateTime.Now().</returns>
		public static DateTime FromNow(this DateTimeComponents components)
		{
			return components.From(DateTime.Now);
		}

		/// <summary>
		/// Calculates the result of DateTimeComponents added to a given DateTime.
		/// </summary>
		/// <param name="components"><see cref="DateTimeComponents"/> operand.</param>
		/// <param name="dateTime">DateTime operand from which to calculate a future dateTime.</param>
		/// <returns>Future DateTime calculated from the given DateTimeComponents.</returns>
		public static DateTime From(this DateTimeComponents components, DateTime dateTime)
		{
			return dateTime.AddYears(components.Years)
				.AddMonths(components.Months)
				.AddDays(components.Days)
				.AddMinutes(components.Minutes)
				.AddSeconds(components.Seconds)
				.AddMilliseconds(components.MilliSeconds);
		}

		/// <summary>
		/// Calculates the result of DateTimeComponents subtracted from DateTime.Now().
		/// </summary>
		/// <param name="components"><see cref="DateTimeComponents"/> operand.</param>
		/// <returns>Past DateTime calculated from DateTime.Now().</returns>
		public static DateTime Ago(this DateTimeComponents components)
		{
			return components.AgoFrom(DateTime.Now);
		}

		/// <summary>
		/// Calculates the result of DateTimeComponents subtracted from a given DateTime.
		/// </summary>
		/// <param name="components"><see cref="DateTimeComponents"/> operand.</param>
		/// <param name="dateTime">DateTime operand from which to calculate a past date.</param>
		/// <returns>Past DateTime calculated from the given DateTimeComponents.</returns>
		public static DateTime AgoFrom(this DateTimeComponents components, DateTime dateTime)
		{
			return dateTime.AddYears(-components.Years)
				.AddMonths(-components.Months)
				.AddDays(-components.Days)
				.AddMinutes(-components.Minutes)
				.AddSeconds(-components.Seconds)
				.AddMilliseconds(-components.MilliSeconds);
		}
	}
}
