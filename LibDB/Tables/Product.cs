using System;

namespace LibDB
{
    public class Product
    {
        //  Продукт
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProducType { get; set; }
        public string ProducSupplier { get; set; }
        public double ProductQuantity { get; set; }
        public double ProductCost { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}