using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class ComputingMachine
    {
        public List<Worker> workers;
        public Company Manufacter { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public double Power { get; }
        public ComputingMachine(Company comp, string name, decimal cost, double power, List<Worker> workers)
        {
            Manufacter = comp;
            Name = name;
            Cost = cost;
            Power = power;
            this.workers = workers;
        }
        public override string ToString()
        {
            return String.Format($"Manufacture = {Manufacter}, Name = {Name}, Cost = {Cost}, Power = {Power}");
        }
    }
}
