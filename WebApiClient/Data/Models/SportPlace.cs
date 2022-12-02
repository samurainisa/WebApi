using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient.Data.Models
{
    class SportPlaces
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string CoverType { get; set; }
    }
}