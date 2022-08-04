using System;
using Core.Entities;

namespace Entities.Concrete{
    public class Product:IEntity{
        public int ProductId { get; set; }//primary key
        public int CategoryId { get; set; }//foreign key
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}