using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace C4SC.Web.UI.WebControls
{
	/// <summary>
	/// Emits Google Analytics JavaScript. Be sure to include this control on your site's MasterPage or a base page
	/// that will ensure this JavaScript gets emitted inside the HEAD element on every rendered page. 
	/// </summary>
	[DefaultProperty("AccountId")]
	[ToolboxData("<{0}:GoogleAnalytics runat=server></{0}:GoogleAnalytics>")]
	[ToolboxBitmap(typeof(GoogleAnalytics), @"GoogleAnalytics.bmp")]
	public class GoogleAnalytics : WebControl
	{
		#region Member/Type Variables
		
		private static string _googleAnalyticsJavaScript	= String.Empty;
		private static readonly object _lockObject			= new object();
		private const char Quote							= '"';

		/// <summary>
		/// Contains the ViewState keys used for GoogleAnalytics.
		/// </summary>
		private static class ViewStateKeys
		{
			public const string AccountId		= "GoogleAnalytics.AccountId";
			public const string DomainOption	= "GoogleAnlytics.AccountOption";
			public const string DomainName		= "GoogleAnalytics.DomainName";
		}

		/// <summary>
		/// Contains static options for DomainOption property.
		/// </summary>
		private static class DomainOptions
		{
			public const string SingleDomain					= "SingleDomain";
			public const string SingleDomainMultipleSubDomains	= "SingleDomainMultipleSubDomains";
			public const string MultipleTopLevelDomains			= "MultipleTopLevelDomains";
			public static readonly IList<string> ValidOptions = new List<string> {SingleDomain, SingleDomainMultipleSubDomains, MultipleTopLevelDomains};
		}

		#endregion

		#region Properties

		/// <summary>
		/// Google Analytics Account Id.
		/// </summary>
		public string AccountId
		{
			get { return ((string)ViewState[ViewStateKeys.AccountId]); }
			set { ViewState[ViewStateKeys.AccountId] = value; }
		}

		/// <summary>
		/// Google Analytics Domain Option.
		/// </summary>
		public string DomainOption
		{
			get { return ((string)ViewState[ViewStateKeys.DomainOption]); }
			set { ViewState[ViewStateKeys.DomainOption] = value; }	
		}

		/// <summary>
		/// Google Analytics Domain Name.
		/// </summary>
		public string DomainName
		{
			get { return ((string)ViewState[ViewStateKeys.DomainName]); }
			set { ViewState[ViewStateKeys.DomainName] = value; }
		}

		#endregion

		/// <summary>
		/// Renders control's begin HTML tag.
		/// </summary>
		/// <remarks>
		/// Pass-through call to ignore the default SPAN tag rendered by WebControl base class. 
		/// </remarks>
		/// <param name="writer"><see cref="HtmlTextWriter"/></param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			return;
		}

		/// <summary>
		/// Renders control's end HTML tag.
		/// </summary>
		/// <remarks>
		/// Pass-through call to ignore the default SPAN tag rendered by WebControl base class.
		/// </remarks>
		/// <param name="writer"><see cref="HtmlTextWriter"/></param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
			return;
		}

		/// <summary>
		/// Renders control's contents.
		/// </summary>
		/// <param name="output"><see cref="HtmlTextWriter"/></param>
		protected override void RenderContents(HtmlTextWriter output)
		{
			output.Write(GetGoogleAnalyticsJavaScript());
		}
		 
		/// <summary>
		/// Builds the Google Analytics JavaScript block.
		/// </summary>
		/// <returns>Google Analytics JavaScript block.</returns>
		private string GetGoogleAnalyticsJavaScript()
		{
			if (_googleAnalyticsJavaScript.Length == 0)
			{
				ValidatePropertySettings();

				StringBuilder bldr = new StringBuilder();

				bldr.AppendLine(@"<script type=" + Quote + "text/javascript" + Quote + ">");
				bldr.AppendLine(@"    var _gaq = _gaq || [];");
				bldr.AppendLine(@"    _gaq.push(['_setAccount', '" + AccountId + "']);");

				if (DomainOption.Equals(DomainOptions.SingleDomainMultipleSubDomains))
				{
					bldr.AppendLine(@"    _gaq.push(['_setDomainName', '" + DomainName + "']);");
				}
				else if (DomainOption.Equals(DomainOptions.MultipleTopLevelDomains))
				{
					bldr.AppendLine(@"    _gaq.push(['_setDomainName', 'none']);");
					bldr.AppendLine(@"    _gaq.push(['_setAllowLinker', true]);");
				}

				bldr.AppendLine(@"    _gaq.push(['_trackPageview']);");
				bldr.AppendLine(@"    (function() {");
				bldr.AppendLine(@"        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;");
				bldr.AppendLine(@"        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';");
				bldr.AppendLine(@"        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);");
				bldr.AppendLine(@"    })();");
				bldr.AppendLine(@"</script>");

				lock (_lockObject) { _googleAnalyticsJavaScript = bldr.ToString(); }
			}

			return _googleAnalyticsJavaScript;
		}

		/// <summary>
		/// Validates control's property settings to ensure proper configuration.
		/// </summary>
		private void ValidatePropertySettings()
		{
			if (AccountId.Length == 0)
			{
				throw new ArgumentException(Exceptions.GoogleAnalytics_AccountIdNullOrEmpty);
			}

			if (!DomainOptions.ValidOptions.Contains(DomainOption))
			{
				throw new ArgumentException(Exceptions.GoogleAnalytics_DomainOptionInvalid);
			}

			if (DomainOption.Equals(DomainOptions.SingleDomainMultipleSubDomains))
			{
				if (DomainName.Length == 0)
				{
					throw new ArgumentException(Exceptions.GoogleAnalytics_DomainNameMissing);
				}
			}
		}
	}
}
