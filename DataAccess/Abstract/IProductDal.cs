using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{//interface operations are already public
    public interface  IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
         
    }
}