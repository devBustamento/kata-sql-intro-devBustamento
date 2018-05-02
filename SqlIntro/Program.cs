using System;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=NOTMYPASSWORDGOTCHA;";
            var repo = new DapperProductRepo(connectionString);
            var delProd = new Product { Id = 1005 };
            var insertProd = new Product { Name = "SANTAS SACK"};
            var upProd = new Product { Name = "BOBS BAGS", Id = 999 };

            Console.WriteLine("READY.....\nSET......\n\tGO!");
            
           repo.DeleteProduct(delProd.Id);
            
           //repo.InsertProduct(insertProd); commented out because I just had 15 SANTAS SACKS show up in my DB and I dont want to have to deal with that ever, ever again
          
           //repo.UpdateProduct(upProd);      HEY, they both DO work. and I used that DeleteProduct method to delete them 1 by 1 to make sure it was working!


            foreach (var prod in repo.GetProducts())
            {
                Console.WriteLine("Product Name:" + prod.Name);
            }

            foreach (var prod in repo.GetProductsWithReview())
            {
                Console.WriteLine("\nProduct Name:" + prod.Name + " Product Review: \n\t\t" + prod.Comments);
            }

            /* it works we dont need to see it everytime
            foreach (var prod in repo.GetProductsAndReview())
            {
                Console.WriteLine("\nProduct Name:" + prod.Name + " Product Review (if avail): \n\t\t" + prod.Comments);
            }
             */

            Console.ReadLine();
        }
    }
}
