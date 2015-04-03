using System;
using System.Reactive.Linq;
using Android.Content;
using Android.Locations;

namespace test1
{
	
	public static class MyObservables 
	{	
		public static IObservable<Location> GpsObservable (this Context context) 
		{
			var locationManager = (LocationManager)context.GetSystemService (Context.LocationService);

			return Observable.Create<Location>(observer => {
				// Return disposable object
				return new LocationListenerToObservable (locationManager, observer);
			});
		}
	}


	class LocationListenerToObservable: Java.Lang.Object, ILocationListener 
	{
		readonly LocationManager _locationManager;
		readonly IObserver<Location> _locationObserver;

		public LocationListenerToObservable (LocationManager locationManger, IObserver<Location> locationObserver)
		{
			_locationManager = locationManger;
			_locationManager.RequestLocationUpdates (LocationManager.NetworkProvider, 0, 0, this);
			_locationObserver = locationObserver;
		}

		static void Log (string msg) {
			Logger.Debug(msg, "LocationListener");
		}

		public void OnLocationChanged (Location location)
		{
			Log("OnLocationChanged");
			_locationObserver.OnNext(location);
		}

		#region Only for debugging
		public void OnProviderDisabled (string provider)
		{
			Log("OnProviderDisabled");
		}

		public void OnProviderEnabled (string provider)
		{
			Log("OnProviderEnabled");
		}

		public void OnStatusChanged (string provider, Availability status, Android.OS.Bundle extras)
		{
			Log("OnStatusChanged");
		}
		#endregion


		bool _disposed; 
		public new virtual void Dispose ()
		{ 
			if (!_disposed) // Prevent Disposing twice
			{ 
				_locationManager.RemoveUpdates (this);
				_disposed = true;
			} 
			base.Dispose(); 
		} 
	}
}

