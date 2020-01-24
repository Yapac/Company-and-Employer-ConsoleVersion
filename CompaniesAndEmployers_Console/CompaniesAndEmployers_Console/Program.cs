using System;
using CompaniesAndEmployers_Console.Management;
using System.Xml.Serialization;
using System.Collections.Generic;
using CompaniesAndEmployers_Console.Value;

namespace CompaniesAndEmployers_Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //Management Class declaration
            Employer_Manager _Employer = new Employer_Manager();
            Company_Manager _Company = new Company_Manager();

            Company samsung = new Company("Samsung", "Electronic fabrication", "korea", new DateTime(1938, 3, 1));
            Employer employer1 = new Employer("Daniel kochima", 45, samsung);
            Employer employer2 = new Employer("Park jie hum", 32, samsung);
            Employer employer3 = new Employer("Jamal idrissi", 19, null);
            samsung.AddEmployer(employer1);
            _Employer.Add(employer1);
            _Employer.Add(employer2);
            _Employer.Add(employer3);
            _Company.AddCompany(samsung);



            bool Program = true;
            string Input = "";
            while (Program)
            {
                Console.WriteLine("________COMPANIES AND EMPLOYERS________");
                Console.WriteLine("1/Employers erea\t2/Companies erea");
                Console.Write("Your Choice : ");
                Input = Console.ReadLine();
                if (Input == "1")
                    EmployerErea(_Employer);
                else if (Input == "2")
                    EspaceEntreprise(_Company, _Employer);
                else
                    Console.WriteLine("=> The command cannot be found !!");

                Console.WriteLine("________COMPANIES AND EMPLOYERS________");
                Program = Leave();
            }
        } //done
        static void EmployerErea(Employer_Manager _Employer)
        {
            bool Program = true;
            string Input;
            while (Program)
            {
                Console.WriteLine("________WELCOME TO THE EMPLOYER AREA________");
                Console.WriteLine("1_Show all employers");
                Console.WriteLine("2_Add an employer");
                Console.WriteLine("3_Delete an employer");
                Console.Write("Your Choice : ");
                Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":
                        _Employer.ShowAll();
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        string FullName;
                        int Age;
                        Console.Write("Write the full name of the employer : ");
                        FullName = Console.ReadLine();
                        Console.Write($"Write the age of {FullName} : ");
                        try
                        {
                            Age = int.Parse(Console.ReadLine());
                            Employer E = new Employer(FullName, Age, null);
                            _Employer.Add(E);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Age must be a number");
                        }
                        break;
                    case "3":
                        Console.Write("Write the full name of the employer that you want to delete : ");
                        FullName = Console.ReadLine();
                        Employer a2 = _Employer.FindEmployer(FullName);
                        if (a2 == null)
                        {
                            Console.WriteLine("=> The command cannot be found !!");
                        }
                        else
                        {
                            _Employer.Remove(a2);
                            Console.WriteLine("->L'employer are deleted from the system.");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("=> The command cannot be found !!");
                        break;
                }
                Console.WriteLine("________WELCOME TO THE EMPLOYER AREA________");
                Program = Leave();
            }
        } //done
        static void EspaceEntreprise(Company_Manager _Company, Employer_Manager _Employer)
        {

            bool Program = true;
            string Input;
            Company IndexOfCompany = null;
            while (Program)
            {
                Console.WriteLine("________WELCOME TO THE COMPANY AREA________");
                Console.WriteLine("1_Add a company");
                Console.WriteLine("2_Show all companies");
                Console.WriteLine("3_Delete a company");
                Console.WriteLine("4_Chose a company");
                Console.Write("Your Choice : ");
                Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":
                        Console.WriteLine();
                        string Name, Categorie, Nationality;
                        Console.Write("Write the name of the company : ");
                        Name = Console.ReadLine();
                        Console.Write("Write its categorie : ");
                        Categorie = Console.ReadLine();
                        Console.Write("Write its nationilty : ");
                        Nationality = Console.ReadLine();
                        _Company.AddCompany(new Company(Name, Categorie, Nationality, DateTime.Now));
                        break;
                    case "2":
                        Console.WriteLine();
                        _Company.ShowAllCompanies();
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.Write("Write the name of the company that you want to delete :");
                        string Nom2 = Console.ReadLine();
                        Company a = _Company.FindCompany(Nom2);
                        if (a == null)
                        {
                            Console.WriteLine("->The company cannot be found !");
                        }
                        else
                        {
                            _Company.RemoveCompany(a);
                            Console.WriteLine($"->The company {Nom2} are deleted from the system. ");
                        }
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.Write("Write the name of the company: ");
                        Input = Console.ReadLine();
                        IndexOfCompany = _Company.FindCompany(Input);
                        if (IndexOfCompany == null)
                        {
                            Console.WriteLine("->The name cannot be found");
                            break;
                        }
                        else
                            Company(_Employer, _Company, IndexOfCompany);
                        break;
                    default:
                        Console.WriteLine("=> The command cannot be found !!");
                        break;
                }
                Console.WriteLine("________WELCOME TO THE COMPANY AREA________");
                Program = Leave();
            }
        } //done
        static void Company(Employer_Manager _Employer, Company_Manager _Company, Company Company)
        {
            string Input, Post;
            bool Program = true;
            Employer a;
            while (Program)
            {
                Console.WriteLine();
                Console.WriteLine($"______WELCOME IN {Company.Name.ToUpper()}______");
                Console.WriteLine("1_Show all the employers of the company");
                Console.WriteLine("2_Show all the employer of the system");
                Console.WriteLine("3_Add an employer (from the system)");
                Console.WriteLine("4_Delete an employer");
                Console.WriteLine("5_Change the post of an employer");
                Console.WriteLine("6_Changer the salairy of an employer");
                Console.WriteLine("7_Show all posts of the company");
                Console.WriteLine("8_Add a post to the company");
                Console.WriteLine("9_Delete a post from the company");
                Console.Write("Your Choice : ");
                Input = Console.ReadLine();
                switch (Input)
                {
                    case "1":
                        Console.WriteLine();
                        _Company.ShowAllEmployers(Company);
                        break;
                    case "2":
                        Console.WriteLine();
                        _Employer.ShowAll();
                        break;
                    case "3":
                        Console.WriteLine();
                        string FulllName;
                        Console.Write("Write the name of the employer that you want to add : ");
                        FulllName = Console.ReadLine();
                        a = _Employer.FindEmployer(FulllName);
                        if (a == null)
                        {
                            Console.WriteLine("->The employer cannot be found.");
                        }
                        else
                        {
                            _Company.AddEmployer(Company, a);
                            Console.WriteLine($"->{a.FullName} are added to {Company.Name}");
                        }
                        break;
                    case "4":
                        Console.Write("Write the name of the employer that you want to delete : ");
                        FulllName = Console.ReadLine();
                        a = _Employer.FindEmployer(FulllName);
                        if (a == null)
                        {
                            Console.WriteLine("->The employer cannot be found.");
                        }
                        else
                        {
                            _Company.RemoveEmployer(Company, a);
                            a.PlaceOfWork = null;
                            Console.WriteLine($"->{a.FullName} are deleted from {Company.Name}");
                        }
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.Write("Write the name of the employer that you want to change his post  : ");
                        FulllName = Console.ReadLine();
                        a = _Company.FindEmployerInACompany(Company, FulllName);
                        if (a == null)
                        {
                            Console.WriteLine("->The employer cannot be found.");
                        }
                        else
                        {
                            _Company.ShowAllPosts(Company);
                            Console.Write("Write the name of the post : ");
                            Post = Console.ReadLine();
                            _Company.ChangePostOfEmployer(Company, a, Post);
                        }
                        break;
                    case "6":
                        Console.WriteLine();
                        Console.Write("Write the name of the employer that you want to change his salary : ");
                        FulllName = Console.ReadLine();
                        a = _Company.FindEmployerInACompany(Company, FulllName);
                        if (a == null)
                        {
                            Console.WriteLine("->The employer cannot be found.");
                        }
                        else
                        {
                            Console.Write("Write the new salary : ");
                            int salaire = int.Parse(Console.ReadLine());
                            _Company.ChangeSalaryOfEmployer(a, salaire);
                        }
                        break;
                    case "7":
                        Console.WriteLine();
                        _Company.ShowAllPosts(Company);
                        break;
                    case "8":
                        Console.WriteLine();
                        Console.Write("Write the name of the new post : ");
                        Post = Console.ReadLine();
                        _Company.AddPost(Company, Post);
                        break;
                    case "9":
                        Console.WriteLine();
                        _Company.ShowAllPosts(Company);
                        Console.Write("Write the name of the post that you want to delete : ");
                        Post = Console.ReadLine();
                        _Company.RemovePost(Company, Post);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("=> The command cannot be found !!");
                        break;
                }
                Console.WriteLine($"______WELCOME IN {Company.Name.ToUpper()}______");
                Program = Leave();
            }

        } //done
        static bool Leave()
        {
            string Input;
            Console.WriteLine();
            Console.WriteLine("->Do you want to leave: (1/yes - 2/no) ");
            Console.Write("Your Choice : ");
            Input = Console.ReadLine();
            if (Input == "1")
            {
                Console.WriteLine("_______________________________________________");
                return false;
            }
            Console.WriteLine("_______________________________________________");
            return true;
        } //done
    }
}
