using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=myServerAddress;Database=adventureworks;Uid=root;Pwd=myPassword;"; 
            var repo = new ProductRepository(connectionString);

            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }
           
            Console.ReadLine();
        }

       
    }
}
