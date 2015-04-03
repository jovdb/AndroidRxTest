using System;
using Android.Util;
using Android.Widget;

namespace test1
{
	public static class Logger
	{
		public static TextView TextView;

		public static void Debug(string message, string tag = "unknown") 
		{			
			// Write To Console
			Log.WriteLine(LogPriority.Debug, tag, message);	

			// Log to Screen (not yet tested)
			if (TextView != null) {
				TextView.Append (tag + ": " + message + Environment.NewLine);
			}
		}
	}
}

