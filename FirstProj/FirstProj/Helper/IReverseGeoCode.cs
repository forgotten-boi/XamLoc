using FirstProj.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstProj.Helper
{
    public interface IReverseGeoCode
    {
        Task<LocationAddress> ReverseLocationAsync(double lat, double lng);
    }
}
