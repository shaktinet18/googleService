using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace googlemap
{
    [Activity(Label = "googlemap", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, IOnMapReadyCallback
    {

        private GoogleMap GMap;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            SetUpMap();
        }

        private void SetUpMap()
        {
            if (GMap == null)
            {
               FragmentManager.FindFragmentById<MapFragment>(Resource.Id.googlemap).GetMapAsync(this);

            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            this.GMap = googleMap;
            GMap.UiSettings.ZoomControlsEnabled = true;
           
         

            LatLng latlng = new LatLng(Convert.ToDouble(13.0291), Convert.ToDouble(80.2083));
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(latlng, 15);
            GMap.MoveCamera(camera);


            MarkerOptions options = new MarkerOptions()
                        .SetPosition(latlng)
                        .SetTitle("Chennai");

            GMap.AddMarker(options);

        }

    }
}

