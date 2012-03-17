using System;
using System.Linq;
using C4SC.Core.Testability;

namespace C4SC.Core
{
	/// <summary>
	/// DateTime extension methods. This class is a .NET partial port of the helper methods in the Rails Date class.
	/// </summary>
	/// <remarks>
	/// http://api.rubyonrails.org/classes/Date.html
	/// </remarks>
	public static class DateTimeExtensions
	{
		private static readonly int[] _q1 = new[] { 1, 2, 3 };
		private static readonly int[] _q2 = new[] { 4, 5, 6 };
		private static readonly int[] _q3 = new[] { 7, 8, 9 };

		#region DateTime.Now Abstraction

		private static IDateTimeNowAdapter _nowAdapter	= new SystemDateTimeNowAdapter();
		private static readonly object _syncLock		= new object();

		/// <summary>
		/// Sets the DSL's IDateTimeNowAdapter. This is the injection point for tests to provide their own adapter
		/// implementation.
		/// </summary>
		/// <param name="adapter"><see cref="IDateTimeNowAdapter"/> implementation.</param>
		internal static void SetDateTimeNowAdapter(IDateTimeNowAdapter adapter)
		{
			lock (_syncLock) { _nowAdapter = adapter; }
		}

		#endregion

		/// <summary>
		///	Resets the time portion of the DateTime to 00:00:00.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Given date value at 00:00:00.</returns>
		public static DateTime AtMidnight(this DateTime dateTime)
		{
			return dateTime.AtBeginningOfDay();
		}

		/// <summary>
		///	Resets the time portion of the DateTime to 00:00:00.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Given date value at 00:00:00.</returns>
		public static DateTime AtBeginningOfDay(this DateTime dateTime)
		{
			return dateTime.Date;
		}

		/// <summary>
		///	Resets the day value to Sunday of the current week at 00:00:00.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Sunday of the current week at 00:00:00.</returns>
		public static DateTime AtBeginningOfWeek(this DateTime dateTime)
		{
			return dateTime.AddDays(-(Int32)dateTime.DayOfWeek).AtBeginningOfDay();
		}

		/// <summary>
		///	Resets the day value to the first of the month at 00:00:00.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>First day of the month at 00:00:00.</returns>
		public static DateTime AtBeginningOfMonth(this DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, 1);
		}

		/// <summary>
		///	Resets the date value to the first day of the quarter at 00:00:00.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>First day of the quarter at 00:00:00.</returns>
		public static DateTime AtBeginningOfQuarter(this DateTime dateTime)
		{
			return _q1.Contains(dateTime.Month) ? new DateTime(dateTime.Year, 1, 1).AtBeginningOfDay() :
				_q2.Contains(dateTime.Month) ? new DateTime(dateTime.Year, 3, 1).AtBeginningOfDay() :
				_q3.Contains(dateTime.Month) ? new DateTime(dateTime.Year, 7, 1).AtBeginningOfDay() :
					new DateTime(dateTime.Year, 10, 1).AtBeginningOfDay();
		}

		/// <summary>
		///	Resets the day value to January 1 of the current year at 00:00:00.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>January 1 of the current year at 00:00:00.</returns>
		public static DateTime AtBeginningOfYear(this DateTime dateTime)
		{
			return new DateTime(dateTime.Year, 1, 1);
		}

		/// <summary>
		///	Resets the time portion of the DateTime to 23:59:59.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Provided DateTime at 23:59:59.</returns>
		public static DateTime AtEndOfDay(this DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
		}

		/// <summary>
		///	Resets the day value to Saturday of the current week at 23:59:59.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Saturday of the current week at 23:59:59.</returns>
		public static DateTime AtEndOfWeek(this DateTime dateTime)
		{
			return dateTime.AddDays(6 - (Int32)dateTime.DayOfWeek).AtEndOfDay();
		}

		/// <summary>
		///	Resets the day value to the last day of the month at 23:59:59.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Last day of the month at 23:59:59.</returns>
		public static DateTime AtEndOfMonth(this DateTime dateTime)
		{
			DateTime endOfMonth = dateTime.AddMonths(1).AtBeginningOfMonth().AddDays(-1);
			return endOfMonth.AtEndOfDay();
		}

		/// <summary>
		///	Resets the date value to the last day of the quarter at 23:59:59.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>Last day of the quarter at 23:59:59.</returns>
		public static DateTime AtEndOfQuarter(this DateTime dateTime)
		{
			return _q1.Contains(dateTime.Month) ? new DateTime(dateTime.Year, 3, 31).AtEndOfDay() :
				_q2.Contains(dateTime.Month) ? new DateTime(dateTime.Year, 6, 30).AtEndOfDay() :
				_q3.Contains(dateTime.Month) ? new DateTime(dateTime.Year, 9, 30).AtEndOfDay() :
					new DateTime(dateTime.Year, 12, 31).AtEndOfDay();
		}

		/// <summary>
		///	Resets the day value to December 31 of the current year at 23:59:59.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>December 31 of the current year at 23:59:59.</returns>
		public static DateTime AtEndOfYear(this DateTime dateTime)
		{
			DateTime endOfYear = dateTime.AddYears(1).AtBeginningOfYear().AddDays(-1);
			return endOfYear.AtEndOfDay();
		}

		/// <summary>
		/// Determines whether or not the DateTime occurs in the future.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>True if the DateTime occurs in the future.</returns>
		public static bool IsFuture(this DateTime dateTime)
		{
			return _nowAdapter.DateTimeNow() < dateTime;
		}

		/// <summary>
		///	Determines whether or not the DateTime occurs in the past.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>True if the DateTime occurs in the past.</returns>
		public static bool IsPast(this DateTime dateTime)
		{
			return _nowAdapter.DateTimeNow() > dateTime;
		}

		/// <summary>
		/// Determines whether or not the DateTime is equal to today's date.
		/// </summary>
		/// <param name="dateTime">DateTime evaluation target.</param>
		/// <returns>True if the DateTime matches today's date.</returns>
		public static bool IsToday(this DateTime dateTime)
		{
			return _nowAdapter.DateTimeNow().Date.Equals(dateTime.Date);
		}
	}
}
