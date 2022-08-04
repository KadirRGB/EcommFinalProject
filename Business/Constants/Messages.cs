using System.Runtime.Serialization;
using Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded="Product Added";
        public static string ProductNameInvalid ="Invalid Product Name";
      //  public static string productsListed = "Products are listed";
        public static string MaintenanceTime="system in maintenance";
        public static string productsListed = "Products are listed";
          public static string productsCountOfCategoryError = "Max 10 product in one category";

        public static string ProductNameAlreadyExist ="Name exist";

        public static string CategoryLimitExceed ="exceed";

        public static string AuthorizationDenied ="Authorization Denied";
    }
}