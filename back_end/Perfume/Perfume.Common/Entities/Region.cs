using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perfume.Common
{
    public class Region
    {
        public int RegionID { get; set; }
        public int ParentID { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public int RegionLevel { get; set; }
    }
}
