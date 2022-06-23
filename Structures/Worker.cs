using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class Worker
    {
        private static int _id = 1;
        public string FirstName { get; }
        public string LastName { get; }
        public int Id { get; }
        public Worker(string fn, string ln)
        {
            FirstName = fn;
            LastName = ln;
            Id = _id++;
        }
        public override string ToString()
        {
            return String.Format($"FN = {FirstName}, LN = {LastName}, ID = {Id}");
        }
    }
}
