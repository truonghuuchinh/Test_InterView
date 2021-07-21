using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_InterView.Models
{
    public class Parentweather
    {
        public string Message { get; set; }
        public int StatusCode { get; set; } = 200;
        public List<DetailData> Data { get; set; }
    }
}
