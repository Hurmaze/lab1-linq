using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class ComputingMachine
    {
        private static int _id = 1;
        public List<Worker> workers = new List<Worker>();
        public Company Manufacter { get; }
        public string Name { get; }
        public decimal Cost { get; }
        public double Power { get; }
        public int Id { get; }
        public ComputingMachine(Company comp, string name, decimal cost, double power)
        {
            Manufacter = comp;
            Name = name;
            Cost = cost;
            Power = power;
            Id = _id++;
        }
        public override string ToString()
        {
            return String.Format($"Manufacture = {Manufacter}, Name = {Name}, Cost = {Cost}, Power = {Power}, ID = {Id}");
        }
        public void AddRange(params Worker[] works)
        {
            foreach (var work in works)
                workers.Add(work);
        }
    }
}
