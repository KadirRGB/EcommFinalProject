using System;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product>{
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock= 10},
                 new Product{ProductId = 2, CategoryId = 1, ProductName = "kamera", UnitPrice = 500, UnitsInStock= 10},
                  new Product{ProductId = 3, CategoryId = 2, ProductName = "telefon", UnitPrice = 1500, UnitsInStock= 10},
                   new Product{ProductId = 4, CategoryId = 2, ProductName = "klavye", UnitPrice = 150, UnitsInStock= 10},
                     new Product{ProductId = 5, CategoryId = 2, ProductName = "fare", UnitPrice = 85, UnitsInStock= 10}

            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            /*       
          Product productToDelete;
            foreach (var p in _products)
            { if(product.ProductId == p.ProductId){
                    productToDelete = p;  }  } 
                    
                    İnstead of this, Lets use LINQ-LANGUAGE İNTEGRATED QUERY
                    */
           Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
           _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        /*
       public List<Product> GetAllByCategory(int categoryId)
       {
          return _products.Where(p=>p.CategoryId == categoryId).ToList();
       }
*/
        public void Update(Product product)
        {
           Product productToUpdate = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
           productToUpdate.ProductName = product.ProductName;
           productToUpdate.CategoryId = product.CategoryId;
           productToUpdate.UnitPrice = product.UnitPrice;
           productToUpdate.UnitsInStock = product.UnitsInStock;
           }

        List<ProductDetailDto> IProductDal.GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}