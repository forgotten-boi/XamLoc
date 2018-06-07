using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstProj.Pages
{

    public static class LocationInfo
    {
        internal static string Longitude;
        internal static string Latitude { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Location : ContentPage
	{
        
        public Location ()
		{
			InitializeComponent ();
		}

        async void GetLocation_Clicked(object sender, System.EventArgs e)
        {
            var status = await HandleLocation();
            if (status == PermissionStatus.Granted)
            {

                var locator = CrossGeolocator.Current;
                if (!locator.IsGeolocationEnabled)
                {
                    //CrossPermissions.Current.OpenAppSettings();
                    //StartRequestingLocationUpdates();
                }
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                LocationInfo.Latitude = Math.Round(position.Latitude, 5).ToString();
                LocationInfo.Longitude = Math.Round(position.Longitude, 5).ToString();
                
            }
            //Task.Run(async () =>
            //{
            //    try
            //    {
            //        var locator = CrossGeolocator.Current;
            //        locator.DesiredAccuracy = 10000;
            //        var position = await locator.GetPositionAsync(new TimeSpan(0, 0, 5));
            //        var currentLat = position.Latitude;
            //        var currentLong = position.Longitude;
            //        var address = await DependencyService.Get<Helper.IReverseGeoCode>().ReverseLocationAsync(currentLat, currentLong);
            //        Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
            //        {
            //            lblLocation.Text = address.City;
            //        });
            //    }
            //    catch (Exception ex)
            //    {
            //        System.Diagnostics.Debug.WriteLine(ex.Message);
            //    }
            //});
        }

        public async Task<PermissionStatus> HandleLocation()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Please enable location permission", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                    else
                    {
                        await DisplayAlert("Need location", "Please Authorize for location", "OK");
                        CrossPermissions.Current.OpenAppSettings();
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    return status;
                    var results = await CrossGeolocator.Current.GetPositionAsync(timeout:TimeSpan.FromMilliseconds(10000));
                    
                    //LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
                //LabelGeolocation.Text = "Error: " + ex;
            }
        }
        public async Task<PermissionStatus> CheckLocationPermission()
        {
            var permission = Permission.Location;
            try
            {

                PermissionStatus status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

                if (status != PermissionStatus.Granted)
                {
                    //It has not been granted so lets ask
                    var showRequest = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location);
                    if (showRequest)
                    {
                        await DisplayAlert(Permission.Location + " Permission Request", "In order for the app to, permission must first be granted.", "OK");
                    }

                    Dictionary<Permission, PermissionStatus> results = await CrossPermissions.Current.RequestPermissionsAsync(permission);
                    if (results.Keys.Contains(Permission.Location))
                        status = results[Permission.Location];
                    else
                    {
                       await DisplayAlert("अत्ती भयो", "भाइ तैले झेल्ली गरीस", "मेोज गर");
                    }
                }

                return status;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("\nIn App.Helpers.NetworkHelper.CheckRequestPermissionAsync() - Exception attempting to check or request permission to Permission.{0}:\n{1}\n", permission, ex);
                return PermissionStatus.Unknown;
            }

        }



    }
}