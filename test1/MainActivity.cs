using System;

using Android.App;
using Android.Widget;
using Android.OS;

namespace test1
{
	[Activity (Label = "test1", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Define a listener that responds to location updates
			var gpsObservable = this.GpsObservable ();
			gpsObservable.Subscribe (location => Logger.Debug (location.ToString ()));

		}
	}
}


