using System;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace C4SC.Common.WebControls.Google
{
	/// <summary>
	/// Emits Google Analytics Javascript. Be sure to include this control on your site's MasterPage or a base page
	/// that will ensure this Javascript gets emitted inside the HEAD element on every rendered page. 
	/// </summary>
	[DefaultProperty("AccountId")]
	[ToolboxData("<{0}:GoogleAnalytics runat=server></{0}:GoogleAnalytics>")]
	[ToolboxBitmap(typeof(GoogleAnalytics), @"Resources\google.bmp")]
	public class GoogleAnalytics : WebControl
	{
		private const char Quote = '"';
		private static string _googleAnalyticsJavaScript = String.Empty;
		private static readonly object _lockObject = new object();

		/// <summary>
		/// Google Analytics Account Id.
		/// </summary>
		[Bindable(true)]
		[Category("Google")]
		[DefaultValue("")]
		[Localizable(true)]
		public string AccountId
		{
			get { return ((string)ViewState["GoogleAnalyticsAccountId"]); }
			set { ViewState["GoogleAnalyticsAccountId"] = value; }
		}

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
		/// 
		/// </summary>
		/// <param name="output"></param>
		protected override void RenderContents(HtmlTextWriter output)
		{
			output.Write(GetGoogleAnalyticsJavascript());
		}
		 
		/// <summary>
		/// Builds the Google Analytics Javascript block.
		/// </summary>
		/// <returns>Google Analytics Javascript block.</returns>
		protected string GetGoogleAnalyticsJavascript()
		{
			if (_googleAnalyticsJavaScript.Length == 0)
			{
				lock (_lockObject)
				{
					_googleAnalyticsJavaScript =
						@"<script type=" + Quote + "text/javascript" + Quote + ">" + //Environment.NewLine +
						@"	var _gaq = _gaq || [];" + Environment.NewLine +
						@"	_gaq.push(['_setAccount', '" + AccountId + "']);" + Environment.NewLine +
						@"	_gaq.push(['_trackPageview']);" + Environment.NewLine +
						@"	(function() {" + Environment.NewLine +
						@"	var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;" + Environment.NewLine +
						@"	ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';" + Environment.NewLine +
						@"	var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);" + Environment.NewLine +
						@"	})();" + Environment.NewLine +
						@"</script>" + Environment.NewLine;
				}
			}

			return _googleAnalyticsJavaScript;
		}
	}
}
