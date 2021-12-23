using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTools;
using TattooStudio.Models;

namespace TattooStudio.Client
{
    class Menu
    {
        RestService restService;

        Customer cCreate;        
        public Menu(RestService restService)
        {
            this.restService = restService;
            this.cCreate = new Customer();            
        }

        public void Start()
        {
            var menu = new ConsoleMenu().Add("Tasks", () => new ConsoleMenu()
               .Add("List tatto type", () => ListItems<Tattoo>(restService.Get<Tattoo>("tattoo")))
               .Add("Create customer", () => new ConsoleMenu().Add("Name", () => CreateItemC("Name"))
                    .Add("BornDate", () => CreateItemC("BornDate"))
                    .Add("Email", () => CreateItemC("Email"))
                    .Add("Create", () => CreateItemC("Create"))
                    .Add("Back", ConsoleMenu.Close).Show())              
               .Add("WhatWantedByName", () => NonCrud("name"))
               .Add("Back", ConsoleMenu.Close).Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }

        public void ListC(List<Customer> items)
        {
            Console.Clear();
            ConsoleMenu m = new ConsoleMenu();

            foreach (var item in items)
            {
                m.Add(item.Name, () => Console.WriteLine());
            }
            Console.ReadLine();

            m.Show();
        }

        public void ListItems<T>(List<T> items)
        {
            Console.Clear();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
        public void CreateItemC(string property)
        {
            Console.Clear();
            if (property == "ID")
            {
                Console.WriteLine($"CustomerID: {cCreate.CustomerID}\r");
                Console.Write("New ID: ");
                int id = int.Parse(Console.ReadLine());
                cCreate.CustomerID = id;

            }
            else if (property == "Name")
            {
                Console.WriteLine($"Name: {cCreate.Name}\r");
                Console.Write("New Name: ");
                string t = Console.ReadLine();
                cCreate.Name = t;
            }
            else if (property == "BornDate")
            {
                // 2000.11.11
                Console.WriteLine($"BornDate: {cCreate.BornDate}\r");
                Console.Write("New BornDate: ");
                string[] year = Console.ReadLine().Split(".");
                DateTime y = new DateTime(int.Parse(year[0]), int.Parse(year[1]), int.Parse(year[2]));
                cCreate.BornDate = y;
            }
            else if (property == "Email")
            {
                Console.WriteLine($"Email: {cCreate.Email}\r");
                Console.Write("New Email: ");
                string p = Console.ReadLine();
                cCreate.Email = p;
            }
            else if(property== "Create")
            {
                restService.Post(cCreate, "customer");
                cCreate = new Customer();
            }
        }

        public void NonCrud(string property)
        {
            Console.Clear();

            if (property == "name")
            {
                var v = restService.Get<object>("task/WhatWantedByName");
                foreach (var item in v)
                {
                    Console.WriteLine(item);
                }
            }
            Console.ReadLine();
        }
    }

}
