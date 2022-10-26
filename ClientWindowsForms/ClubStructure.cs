using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWindowsForms
{
    public class ClubStructure
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ClubStructure[] Childs { get; set; }
    }
}