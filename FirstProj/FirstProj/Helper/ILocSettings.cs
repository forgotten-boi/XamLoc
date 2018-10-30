using FirstProj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//[assembly: Xamarin.Forms.Dependency(typeof(ILocSettings))]
namespace FirstProj
{
   public interface ILocSettings
    {
        void OpenSettings();
    }
}
