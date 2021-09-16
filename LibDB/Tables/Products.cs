using System;

namespace LibDB
{
    public class Products
    {
        //  Продукт
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int TypeId { get; set; }
        public int SupplierId { get; set; }
        public double ProductQuantity { get; set; }
        public double ProductCost { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}