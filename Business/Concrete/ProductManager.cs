using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    //Cross Cutting Concerns->Log, Cache, Transaction, Authorization, Validation...
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService _categoryService)
        {
            _productDal = productDal;
        }
        //an entity maanger can not inject another Dal except itself.



//Attributes are structures that tries to add a meaning to the method

        //claim
        [SecuredOperation("product.add, admin")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]

        public IResult Add(Product product)
        {
      // ValidationTool.Validate(new ProductValidator(),product);
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
             CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded());
           if(result !=null){
            return result;
              }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        
        return new ErrorResult();
        }
        [CacheRemoveAspect("IPRoductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
 
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour==22){
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.productsListed); 
        }
    
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==productId));
        }

        public IDataResult<List<Product>>  GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min&&p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
             if(DateTime.Now.Hour==17){
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId){
        //select count (*) from products where categoryId=1
        var result =_productDal.GetAll(p=>p.CategoryId ==categoryId).Count;
        if(result>=15){
            return new ErrorResult(Messages.productsCountOfCategoryError);
        }
        return new SuccessResult();
    }
    
    private IResult CheckIfProductNameExist(string productName){
        var result =_productDal.GetAll(p=>p.ProductName == productName).Any();
        if(result){
            return new ErrorResult(Messages.ProductNameAlreadyExist);
        }
        return new SuccessResult();
    }
        
    private IResult CheckIfCategoryLimitExceded(){
        var result = _categoryService.GetAll();
        if(result.Data.Count>15){
            return new ErrorResult(Messages.CategoryLimitExceed);
        }
        return new SuccessResult();
    }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            
        }
    }
}