using System.Linq;
using Structures;


namespace lab1_linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            var workers = CreateWorkers();
            var compMach = CreateCM();
            SetWorkers(compMach, workers); 
            var task7 = Task7(compMach);
            foreach (var worker in task7)
                Console.WriteLine(worker.ToString());
            Console.WriteLine();
            Task8(compMach, workers);
            Console.WriteLine();
            var task10 = Task10(compMach);
            foreach (var worker in task10)
                Console.WriteLine(worker.ToString());
            Console.WriteLine();
        }

        public static List<ComputingMachine> FindAllFromLG(List<ComputingMachine> machines)
        {
            return machines.Where(x => x.Manufacter.Name == "LG").ToList();
        }

        public static List<ComputingMachine> FindAllWherePriceLess1000AndPowerMore450(List<ComputingMachine> machines)
        {
            var res = from m in machines
                      where m.Cost < 1000 && m.Power > 450
                      select m;
            return res.ToList();
        }

        public static List<Worker> SelectAllWorkersWorkingWhithMachine10(List<ComputingMachine> machines)
        {
            return machines.Where(x => x.Id == 10).First().workers;
        }

        public static decimal SelectMaxPrice(List<ComputingMachine> machines)
        {
            return  (from m in machines
                      select m.Cost).Max();
        }

        //should return company and sum cost of its products in a way "Sony-1400"
        public static List<String> Task6(List<ComputingMachine> machines)
        {
            var res = machines.GroupBy(x => x.Manufacter.Name).Select(y => $"{y.Key}-{y.Sum(n => n.Cost)}").ToList();
            return res;
        }

        public static List<Company> SelectAllCompaniesWhereMachinesName2(List<ComputingMachine> machines)
        {
            var res = from m in machines
                      where m.Name == "Name2"
                      select m.Manufacter;
            return res.ToList<Company>();
        }

        //should return sorted values by price in asc, then by power in desc.
        public static List<ComputingMachine> Task7(List<ComputingMachine> machines)
        {
            return machines.OrderBy(x => x.Cost).ThenByDescending(x => x.Power).ToList();
        }

        //create anonymous class from joined tables on worker`s Id and computer`s (just to use join method)
        public static void Task8(List<ComputingMachine> machines, List<Worker> workers)
        {
            var result = machines.Join(workers, m => m.Id, w => w.Id, (m, w) => new { ComputerName = m.Name, WorkerName = w.FirstName + " " + w.LastName });
            foreach (var res in result)
               
                Console.WriteLine($"{res.ComputerName} has the same id as {res.WorkerName}");
        
        }

        //find the company with the longest description
        public static Company Task9(List<ComputingMachine> machines)
        {
            return machines.Select(x => x.Manufacter).OrderByDescending(x => x.Description).First();
        }

        public static IEnumerable<string> Task10(List<ComputingMachine> machines)
        {
            var result = (from m in machines
                          where m.Manufacter.Description.StartsWith("Makes") && m.Manufacter.FundationYear >= 1900
                          group m by m.Manufacter.Name).Select(x => $"{x.Key} has {x.Sum(n => n.Power)} power....");
            return result;
        }

        static List<Worker> CreateWorkers()
        {
            List<Worker> workers = new List<Worker>();
            for (int i = 1; i < 16; i++)
            {
                workers.Add(new Worker("worker" + i.ToString(), "WORKER" + i.ToString()));
            }
            return workers;
        }

        static List<ComputingMachine> CreateCM()
        {
            List<Company> companies = new List<Company>() 
            { 
                new Company("LG", "Makes cool devices", 1899),
                new Company("Hp", "Makes devices", 1956),
                new Company("Sony", "Hust a company", 1974),
                new Company("MSI", "Makes gaming devices", 1993)
            };
            List<ComputingMachine> computingMachines = new List<ComputingMachine>();
            for (int i = 1; i < 13; i++)
            {
                if (i < 4)
                    computingMachines.Add(new ComputingMachine(companies[0], "Name" + i.ToString(), 1000 + i, 450 - i));
                else if (i < 7)
                    computingMachines.Add(new ComputingMachine(companies[1], "Name" + (i - 3).ToString(), 1000 - i - 1, 450 - i + 5));
                else if (i < 10)
                    computingMachines.Add(new ComputingMachine(companies[2], "Name" + (i - 6).ToString(), 1000 + i - 2, 450 + i + 3));
                else
                    computingMachines.Add(new ComputingMachine(companies[3], "Name" + i.ToString(), 1000 + i - 3, 450 + i + 1));
            }
            return computingMachines;
        }

        private static void SetWorkers(List<ComputingMachine> compMach, List<Worker> workers)
        {
            compMach[0].AddRange(workers[1], workers[10], workers[3], workers[2]);
            compMach[1].AddRange(workers[2], workers[11], workers[4], workers[6]);
            compMach[2].AddRange(workers[1], workers[10], workers[6], workers[2]);
            compMach[3].AddRange(workers[1], workers[14]);
            compMach[4].AddRange(workers[8], workers[9], workers[7]);
            compMach[5].AddRange(workers[12]);
            compMach[6].AddRange(workers[0], workers[2], workers[3], workers[5]);
            compMach[7].AddRange();
            compMach[8].AddRange(workers[1], workers[10], workers[3], workers[2]);
            compMach[9].AddRange(workers[6], workers[9]);
            compMach[10].AddRange(workers[4], workers[13], workers[12]);
            compMach[11].AddRange(workers[14]);
        }
    }
}