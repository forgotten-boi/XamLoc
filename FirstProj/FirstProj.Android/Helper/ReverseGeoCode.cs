using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FirstProj;
using FirstProj.Droid;
using FirstProj.Helper;
using FirstProj.Model;
using Xamarin.Forms;
using Java.Util;

[assembly: Dependency(typeof(ReverseGeoCode))]
namespace FirstProj.Droid
{
    public class ReverseGeoCode : IReverseGeoCode
    {
        public async Task<LocationAddress> ReverseLocationAsync(double lat, double lng)
        {
            var geo = new Geocoder(Android.App.Application.Context, Locale.Default);
            var addresses = await geo.GetFromLocationAsync(lat, lng, 1);
            if (addresses.Any())
            {
                var place = new LocationAddress();
                var add = addresses[0];
                place.City = add.Locality;
                place.Province = add.AdminArea;
                return place;
            }
            return null;
        }
    }
}