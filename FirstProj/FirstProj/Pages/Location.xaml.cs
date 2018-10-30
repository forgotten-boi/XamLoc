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
using Xamarin.Essentials;
using Plugin.FilePicker;

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

        async void FilePicker_Clicked(object sender, System.EventArgs e)
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                var result = await Plugin.Permissions.CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

                if (result.ContainsKey(Permission.Storage))
                {
                    status = result[Permission.Storage];
                }
            }
            if (status == PermissionStatus.Granted)
            {

                try
                {


                    var fileData = await CrossFilePicker.Current.PickFile();
                    if (fileData == null)
                        return; // user canceled file picking

                    string fileName = fileData.FileName;
                    string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray, 0, -1);

                    //System.Console.WriteLine("File name chosen: " + fileName);
                    //System.Console.WriteLine("File data: " + contents);
                }
                catch (Exception ex)
                {
                    //System.Console.WriteLine("Exception choosing file: " + ex.ToString());
                }
            }
        }
            async void GetLocation_Clicked(object sender, System.EventArgs e)
            {
           
          
             var   _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            var status = await HandleLocation();
            if (status == PermissionStatus.Granted)
            {

                
                var locator = CrossGeolocator.Current;
                if (!locator.IsGeolocationEnabled)
                {
                    //var isLocationEnabled =  CrossPermissions.Current.OpenAppSettings();
                    DependencyService.Get<ILocSettings>().OpenSettings();
                    return;
                 
                }
                if (locator.IsGeolocationEnabled)
                {
                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                    LocationInfo.Latitude = Math.Round(position.Latitude, 5).ToString();
                    LocationInfo.Longitude = Math.Round(position.Longitude, 5).ToString();
                    await DisplayAlert("Location Info","Your current latitude is " + LocationInfo.Latitude + " and Longitude is " + LocationInfo.Longitude,"Finally").ConfigureAwait(false);
                
                
                }
            
                
            }
       
        }

        public async Task<PermissionStatus> HandleLocation()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                
                    //if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    //{
                       var allowLocation = await DisplayAlert("Need location", "Please enable location permission", "Accept", "Cancel").ConfigureAwait(false);
                    //}
                    if(allowLocation)
                    { 
                        Dictionary<Permission, PermissionStatus> results;
                        try
                        {
                           var requestedPermissions = await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location);
                           results = CrossPermissions.Current.RequestPermissionsAsync(Permission.Location).Result;


                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }

                        //Best practice to always check that the key exists
                        if (results.ContainsKey(Permission.Location))
                            status = results[Permission.Location];
                        else
                        {
                             await DisplayAlert("Need location", "Please Authorize for location", "OK");
                            CrossPermissions.Current.OpenAppSettings();
                        }
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