using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.RequestModel
{
    public class Pager
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderBy { get; set; }
        public string SortBy { get; set; }
    }
}
