using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.ResponseModel
{
    public class ListDataOutput<T> : Response
    {
        public ListDataOutput()
        {
            Data = new List<T>();
        }
        public int TotalRecord { get; set; }
        public List<T> Data { get; set; }
    }
}
