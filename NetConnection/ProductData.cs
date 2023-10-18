using System;
using System.Collections.Generic;

namespace NetConnection
{
    public class ProductData : IDataStructure
    {
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime DateOfUpdating { get; set; }

        public ProductData(string productName, string sellerName, string productDescription, float price, bool isAvailable, DateTime date)
        {
            ProductName = productName;
            SellerName = sellerName;
            ProductDescription = productDescription;
            Price = price;
            IsAvailable = isAvailable;
            DateOfUpdating = date;
        }
        public List<string> GetPrintableStrings()
        {
            List<string> fields = new List<string>();
            fields.Add(ProductName);
            fields.Add(SellerName);
            fields.Add(ProductDescription);
            fields.Add(Price.ToString());
            fields.Add(IsAvailable.ToString());
            fields.Add(DateOfUpdating.ToString());
            return fields;
        }
        public static ProductData ParseFieldsToProduct(List<string> fields)
        {
            return new ProductData(fields[0],
                fields[1], fields[2],
                            float.Parse(fields[3]), bool.Parse(fields[4]),
                            DateTime.Parse(fields[5]));
        }
    }
}
