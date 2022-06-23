
using System.Collections.Generic;
using System.Linq;
using lab1_linq;
using Structures;
using Xunit;

namespace lab1_linq.Tests
{
    public class LinqTests
    {
        List<Worker> workers = CreateWorkers();
        List<Company> companies = CreateCompanies();
        List<ComputingMachine> machines = CreateCM();

        [Fact]
        public void FindAllFromLG_ShouldReturnCorrectValues()
        {
            SetWorkers(machines, workers);
            List<ComputingMachine> expected = new List<ComputingMachine>() { machines[0], machines[1], machines[2] }; 

            List<ComputingMachine> actual = Program.FindAllFromLG(machines);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void FindAllWherePriceLess1000AndPowerMore450_ShouldReturnCorrectValues()
        {
            SetWorkers(machines, workers);
            List<ComputingMachine> expected = new List<ComputingMachine>() { machines[3] };

            List<ComputingMachine> actual = Program.FindAllWherePriceLess1000AndPowerMore450(machines);

            Assert.Equal(expected,actual);
        }
        [Fact]
        public void SelectAllWorkersWorkingWhithMachine10_ShouldReturnCorrectValues()
        {
            SetWorkers(machines, workers);
            List<Worker> expected = new List<Worker>() { workers[6], workers[9] };

            List<Worker> actual = Program.SelectAllWorkersWorkingWhithMachine10(machines);

            Assert.Equal(expected,actual);  
        }
        [Fact]
        public void SelectAllCompaniesWhereMachinesName2_ShouldReturnCorrectValues()
        {
            SetWorkers(machines, workers);
            List<Company> expected = new List<Company>() {  
                new Company("LG", "Makes cool devices", 1900),
                new Company("Hp", "Makes devices", 1956),
                new Company("Sony", "Hust a company", 1974), };

            List<Company> actual = Program.SelectAllCompaniesWhereMachinesName2(machines);
            if (expected.Count == actual.Count)
                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].Name, actual[i].Name);
                    Assert.Equal(expected[i].Description, actual[i].Description);
                    Assert.Equal(expected[i].FundationYear, actual[i].FundationYear);
                }
            else
                Assert.True(expected.Count == actual.Count);
           
        }
        [Fact]
        public void SelectMaxPrice_ShouldReturn1009()
        {
            SetWorkers(machines, workers);
            decimal expected = 1009;

            decimal actual = Program.SelectMaxPrice(machines);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Task6_ShouldReturnCorrectValues()
        {
            SetWorkers(machines, workers);
            List<String> expected = new List<string>() { "LG-3006", "Hp-2982", "Sony-3018", "MSI-3024" };

            List<String> actual = Program.Task6(machines);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Task9_ShouldReturnMSI()
        {
            SetWorkers(machines, workers);
            string expected = "MSI";

            Company actual = Program.Task9(machines);

            Assert.Equal(expected, actual.Name);
        }
        #region DataCreation
        static List<Worker> CreateWorkers()
        {
            List<Worker> workers = new List<Worker>();
            for (int i = 1; i < 16; i++)
            {
                workers.Add(new Worker("worker" + i.ToString(), "WORKER" + i.ToString()));
            }
            return workers;
        }

        static List<Company> CreateCompanies()
        {
            List<Company> companies = new List<Company>()
            {
                new Company("LG", "Makes cool devices", 1900),
                new Company("Hp", "Makes devices", 1956),
                new Company("Sony", "Hust a company", 1974),
                new Company("MSI", "Makes gaming devices", 1993)
            };
            return companies;
        }

        static List<ComputingMachine> CreateCM()
        {
            List<Company> companies = new List<Company>()
            {
                new Company("LG", "Makes cool devices", 1900),
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
        #endregion
    }
}
