using CompaniesAndEmployers_Console.Management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CompaniesAndEmployers_Console.Data
{
    public class DataXml
    {
        public Company_Manager CompanyData { get; set; }
        public Employer_Manager EmployerData { get; set; }
        public void Save(XmlSerializer DataSerializer, StreamWriter DataWriter,Company_Manager _Company,Employer_Manager _Employer)
        {
            CompanyData = _Company;
            EmployerData = _Employer;
            DataSerializer.Serialize(DataWriter, this);
        }
        public void Load(XmlSerializer DataSerializer, StreamReader DataReader,ref Company_Manager _Company,ref Employer_Manager _Employer)
        {
            DataXml data=DataSerializer.Deserialize(DataReader) as DataXml;
            _Company = data.CompanyData;
            _Employer = data.EmployerData;
            DataReader.Close();
        }
    }
}
