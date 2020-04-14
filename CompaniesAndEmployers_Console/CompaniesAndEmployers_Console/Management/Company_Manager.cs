using CompaniesAndEmployers_Console.Value;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CompaniesAndEmployers_Console.Management
{
    public class Company_Manager
    {
        public List<Company> CompaniesManagement = new List<Company>();

        public void AddCompany(Company entreprise)
        {
            CompaniesManagement.Add(entreprise);
        }
        public void ShowAllCompanies()
        {
            int nb = 1;
            foreach (Company item in CompaniesManagement)
            {
                Console.WriteLine($"Company n'{nb} :");
                Console.WriteLine(item);
                Console.WriteLine();
                nb++;
            }
        }
        public void RemoveCompany(Company entreprise)
        {
            CompaniesManagement.Remove(entreprise);
        }
        public void ShowAllEmployers(Company company)
        {
            Console.WriteLine("Number of employers are :" + company.NumberOfEmployers);
            foreach (var item in company.Employers)
            {
                Console.WriteLine(item);
            }
        }
        public void AddEmployer(Company Company, Employer employer)
        {
            employer.PlaceOfWork = Company.Name;
            Company.AddEmployer(employer);
        }
        public void RemoveEmployer(Company company, Employer employer)
        {
            company.Employers.Remove(employer);
        }
        public void AddPost(Company company, string Post)
        {
            company.AddPost(Post);
        }
        public void ShowAllPosts(Company company)
        {
            Console.WriteLine("Posts of company : ");
            foreach (var item in company.Posts)
            {
                Console.WriteLine("=>" + item);
            }
        }
        public void RemovePost(Company entreprise, string post)
        {

            bool estTrouver = false;
            for (int i = 0; i < entreprise.Posts.Count; i++)
            {
                if (post == entreprise.Posts[i])
                {
                    entreprise.DeleteAPost(post);
                    Console.WriteLine("->Post are deleted!");
                    estTrouver = true;
                }
            }
            if (!estTrouver)
            {
                Console.WriteLine("->Post cannot be found!");
            }
        }
        public void ChangePostOfEmployer(Company entreprise, Employer employeur, string post)
        {
            bool estTrouver = false;
            foreach (string item in entreprise.Posts)
            {
                if (post == item)
                {
                    employeur.Post = post;
                    estTrouver = true;
                }
            }
            if (!estTrouver)
            {
                Console.WriteLine("->>Post cannot be found!");
            }

        }
        public void ChangeSalaryOfEmployer(Employer employeur, int Salaire)
        {
            employeur.Salary = Salaire;
        }
        public Company FindCompany(string Nom)
        {
            foreach (Company item in CompaniesManagement)
            {
                if (item.Name.ToUpper() == Nom.ToUpper())
                {
                    return item;
                }
            }
            return null;
        }
        public Employer FindEmployerInACompany(Company entreprise, string NomComplet)
        {
            foreach (var item in entreprise.Employers)
            {
                if (item.FullName == NomComplet)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
