using Service.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model.ResponseModel
{
    public class Response
    {
        public ResponseStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string Id { get; set; }
    }
}
