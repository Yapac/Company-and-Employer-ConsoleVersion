using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesAndEmployers_Console.Value
{
    public class Employer : Person
    {
        private static int CounterOfId = 1;

        private Company myVar;
        public Company PlaceOfWork
        {
            get { return myVar; }
            set
            {
                Company entreprise = new Company("", "", "", DateTime.Now);
                if (value == null)
                {
                    value = entreprise;
                }
                myVar = value;
            }
        }
        public int Salary { get; set; }
        public string Post { get; set; }
        #region Constructeur
        public Employer(string FullName, int Age, Company PlaceOfWork) : base(FullName, Age)
        {
            this.PlaceOfWork = PlaceOfWork;
            if (PlaceOfWork == null)
            {
                this.PlaceOfWork = new Company();
            }
            Id = "Employer - " + CounterOfId;
            Salary = 0;
            CounterOfId++;
        }

        public Employer()
        {
            this.Id = "Employer - " + CounterOfId;
            CounterOfId++;
        }
        #endregion

        #region Overriding
        public override string ToString()
        {
            return base.ToString() + $"\t Post : {Post}\t Salary:{Salary}DH \tPlace of work: {PlaceOfWork.Name}";
        }
        public override bool Equals(object obj)
        {
            Employer employer = obj as Employer;
            if (employer == null)
            {
                return false;
            }

            return this.Id == employer.Id && this.FullName == employer.FullName;
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode() * FullName.GetHashCode() * Age.GetHashCode() * Salary.GetHashCode() * PlaceOfWork.GetHashCode();
        }


        #endregion

    }
}
