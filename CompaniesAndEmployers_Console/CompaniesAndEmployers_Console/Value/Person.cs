using System;
using System.Collections.Generic;
using System.Text;

namespace CompaniesAndEmployers_Console.Value
{
    public abstract class Person
    {
        #region Properties
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        #endregion

        #region Constructor
        public Person(string FullName, int Age)
        {
            this.FullName = FullName;
            this.Age = Age;
        }
        public Person() { }
        #endregion

        #region Overriding
        public override string ToString()
        {
            return $"Full name : {FullName} \tAge : {Age}";
        }
        #endregion
    }
}
