using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Sport
    {
        public int Id { get; set; }
        public String Name { get; set; }

        //override ToString() method
        public override string ToString()
        {
            return Name;
        }
    }
}