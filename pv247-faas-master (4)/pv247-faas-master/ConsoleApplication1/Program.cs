using System;
using System.Linq;
using Model;
using Newtonsoft.Json;
using System.Data.Entity;

namespace ConsoleApplication
{
    class Program
    {   
        static void Main(string[] args)
        {
            using (var db = new FormAsAServiceDbContext())
            {
                Program.DisplayFormTypes(db);
                Program.DisplayElementTypes(db);
                Program.DisplayForms(db);
                Program.DisplayElements(db);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        private static void DisplayFormTypes(FormAsAServiceDbContext db)
        {
            var query = from ft in db.FormTypes
                        select ft;

            Console.WriteLine("FormTypes: ");
            foreach (var item in query)
            {
                Console.WriteLine("\t" + JsonConvert.SerializeObject(item));
            }
        }

        private static void DisplayElementTypes(FormAsAServiceDbContext db)
        {
            var query = from ft in db.ElementTypes
                        select ft;

            Console.WriteLine("ElementTypes: ");
            foreach (var item in query)
            {
                Console.WriteLine("\t" + JsonConvert.SerializeObject(item));
            }
        }

        private static void DisplayForms(FormAsAServiceDbContext db)
        {
            var query = from ft in db.Forms
                        select ft;

            Console.WriteLine("Forms: ");
            foreach (var item in query)
            {
                Console.WriteLine("\t" + JsonConvert.SerializeObject(item));
            }
        }

        private static void DisplayElements(FormAsAServiceDbContext db)
        {
            var query = from ft in db.Elements
                        select ft;

            Console.WriteLine("Elements: ");
            foreach (var item in query)
            {
                Console.WriteLine("\t" + JsonConvert.SerializeObject(item));
            }
        }
    }

    class FormAsAServiceDbContext : DbContext
    {
        public DbSet<Element> Elements { get; set; }
        public DbSet<ElementType> ElementTypes { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<FormType> FormTypes { get; set; }
    }
}
