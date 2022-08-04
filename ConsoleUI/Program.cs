using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{//DTO->Data Transormation Object
    class Program{
        static void Main(string[] args){
            ProductTest();
            //CategoryTest();
        }

        private static void ProductTest(){
            ProductManager productManager = new ProductManager(new EFProductDal(), new CategoryManager(new EFCategoryDal()));
             var result = productManager.GetProductDetails();
             if(result.Success){
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName+"/"+product.ProductName);
            }
             }else{
                Console.WriteLine(result.Message);
             }
        }
          private static void CategoryTest(){
            CategoryManager  categoryManager= new CategoryManager(new EFCategoryDal());
            foreach (var Category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(Category.CategoryName);
            }
        }
    }
}