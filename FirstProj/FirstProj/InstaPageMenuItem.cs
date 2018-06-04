using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProj
{

    public class InstaPageMenuItem
    {
        public InstaPageMenuItem()
        {
            TargetType = typeof(InstaPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}