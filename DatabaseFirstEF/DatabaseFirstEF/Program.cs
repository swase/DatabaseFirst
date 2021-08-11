using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseFirstEF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindContext())
            {
                //Method queries

                var custQuery = db.Customers.Where(c => c.City == "Paris");
                foreach (var c in custQuery)
                {
                    Console.WriteLine($"{c.ContactName}, {c.City}");
                }



                //var query2 = db.Customers.Where(c => c.City == "London").OrderBy(c => c.ContactName);
                //foreach(var c in query2)
                //{
                //    Console.WriteLine(c);
                //}
                //Console.WriteLine("");

                //var query = db.Customers.Where(c => c.CustomerId == "BONAP");
                //var selectedCustomer = query.FirstOrDefault();

                ////Query syntax
                //IEnumerable<Customer> LondonCustomerQuery =
                //    from c in db.Customers
                //    where c.City == "London"
                //    orderby c.ContactName
                //    select c;

                ////Only executed once in console command
                //foreach (var c in LondonCustomerQuery)
                //{
                //    Console.WriteLine(c);
                //}

                //Console.WriteLine("");
                //var londonBerlinQuery =
                //    from Customer in db.Customers
                //    where Customer.City == "London" || Customer.City == "Berlin"
                //    select Customer;

                //foreach(var customer in londonBerlinQuery)
                //{
                //    Console.WriteLine(customer);
                //}

                //Console.WriteLine("");
                //var londonBerlinQuery2 =
                //    from customer in db.Customers
                //    where customer.City == "London" || customer.City == "Berlin"
                //    select new { Customer = customer.CompanyName, Country = customer.Country }; //Anonymous object

                //foreach (var customer in londonBerlinQuery2)
                //{
                //    Console.WriteLine(customer);
                //}

                //Console.WriteLine("");
                //var orderByUnitPrice =
                //    from p in db.Products
                //    orderby p.UnitPrice descending
                //    select p;
                //Console.WriteLine("ProductId|\tProduct Name\t\t\t|\tUnit Price");
                //foreach(var p in orderByUnitPrice)
                //{
                //    Console.WriteLine($"{p.ProductId}\t|\t{p.ProductName}\t\t\t|\t{p.UnitPrice}");
                //}

                ////GroupBy
                Console.WriteLine("");
                var groupByUnitInStockQuery =
                    from p in db.Products
                    group p by p.SupplierId into newGroup
                    orderby newGroup.Key descending
                    select new
                    {
                        SupplierID = newGroup.Key,
                        UnitsInStock = newGroup.Sum(c => c.UnitsInStock)
                    };

                foreach (var res in groupByUnitInStockQuery)
                {
                    Console.WriteLine($"{res.SupplierID}");
                }

                //Console.WriteLine(db.ContextId);

                //foreach(var c in db.Customers)
                //{
                //    Console.WriteLine($"CustomerId: {c.CustomerId}, Customer Name: {c.ContactName}, City: {c.City}");
                //}

                //Add New Customer

                //var newCustomer = new Customer
                //{
                //    CustomerId = "BLOGG",
                //    ContactName = "Joe Bloggs",
                //    CompanyName = "ToysRUs"
                //};

                //db.Customers.Add(newCustomer);

                //Update
                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();
                //selectedCustomer.City = "London";

                //var p = db.Customers.Find("BLOGG");
                //var selectedCustomer = db.Customers.Where(c => c.CustomerId == "BLOGG").FirstOrDefault();

                //db.Customers.Remove(selectedCustomer);

                //db.SaveChanges();
            }
            
            //Method and lamda
            //List<Person> people = new List<Person>() 
            //{ 
            //    new Person("Cathy", 40),
            //    new Person("Nish", 55),
            //    new Person("Martin", 20)
            //};

            //var query =
            //    from p in people
            //    where p.Age > 25
            //    select p;
            
            //foreach(var p in query)
            //{
            //    Console.WriteLine($"{p.FirstName}");
            //}

            //var query2 = people.FindAll(a => a.Age > 25);

            //foreach (var p in query2)
            //{
            //    Console.WriteLine($"{p.FirstName}");
            //}

            


        }
    }

    internal class Person
    {
        public int Age { get; set; }
        public string FirstName { get; set; }

        public Person(string fname, int age)
        {
            Age = age;
            FirstName = fname;
        }
    }

    public partial class Customer
    {
        public override string ToString()
        {
            return $"{CustomerId} - {ContactName} - {City}";
        }
    }
}
