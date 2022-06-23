using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
   public class Company
   { 
        public string Name { get;}
        public string Description { get;}
        public int FundationYear { get;}

        public Company(string name, string description, int year)
        {
            Name = name;
            Description = description;
            FundationYear = year;
        }
   }
}
