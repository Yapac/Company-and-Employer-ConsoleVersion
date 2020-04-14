using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesAndEmployers_Console.Value
{
    public class Company
    {
        #region Properties
        public string Name { get; set; }
        public string Category { get; set; }
        public string Nationality { get; set; }
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int NumberOfEmployers { get; set; }
        public List<string> Posts { get; set; } = new List<string>();

        private static int CounterOfId = 1;
        public List<Employer> Employers { get; set; } = new List<Employer>();
        #endregion

        #region Constructeur
        public Company(string Name, string Category, string Nationality, DateTime DateOfCreation)
        {
            this.Name = Name;
            this.Category = Category;
            this.Nationality = Nationality;
            this.CreationDate = DateOfCreation;
            Posts.Add("Director");
            Posts.Add("Employer");
            Id = "Company - " + CounterOfId;
            CounterOfId++;
        }
        public Company()
        {
            Id = "Company - " + CounterOfId;
            CounterOfId++;
            Posts.Add("Director");
            Posts.Add("Employer");
        }
        #endregion

        #region overriding & methodes
        public override string ToString()
        {
            return $"Name: {Name}\t Category: {Category}\t Nationality: {Nationality}\nId: {Id}\tDate of creation: {CreationDate}";
        }
        public void AddEmployer(Employer employer)
        {
            Employer E = employer;
            Employers.Add(E);
            NumberOfEmployers++;
        }
        public void AddPost(string Post)
        {
            foreach (string item in Posts)
            {
                if (Post == item)
                    throw new Exception("The post that you entered is already exists");
            }
            Posts.Add(Post);
        }
        public void DeleteAPost(string Post)
        {
            Posts.Remove(Post);
        }
        #endregion
    }
}
