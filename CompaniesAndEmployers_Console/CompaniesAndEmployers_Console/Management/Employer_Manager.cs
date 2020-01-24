using CompaniesAndEmployers_Console.Value;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesAndEmployers_Console.Management
{
    public class Employer_Manager
    {
        public List<Employer> EmployersManagment = new List<Employer>();

        #region Methodes


        public void Add(Employer employeur)
        {
            EmployersManagment.Add(employeur);
        }
        public void ShowAll()
        {
            int nb = 1;
            Console.WriteLine($"The number of employers in system are : {EmployersManagment.Count}");
            foreach (Employer item in EmployersManagment)
            {
                Console.WriteLine($"Employer n'{nb} :");
                Console.WriteLine(item);
                Console.WriteLine();
                nb++;
            }
        }
        public void Remove(Employer employer)
        {
            EmployersManagment.Remove(employer);
        }
        public void Remove(Employer employer1, Employer employer2)
        {
            EmployersManagment.Remove(employer1);
            EmployersManagment.Remove(employer2);
        }
        public void RemoveById(int Index)
        {
            EmployersManagment.RemoveAt(Index);
        }
        public Employer FindEmployer(string FullName)
        {
            foreach (Employer item in EmployersManagment)
            {
                if (item.FullName.ToUpper() == FullName.ToUpper())
                {
                    return item;
                }
            }
            return null;
        }
        #endregion

    }
}
