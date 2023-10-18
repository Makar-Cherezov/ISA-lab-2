using System;
using System.Collections.Generic;
using NetConnection;
namespace Server.Model;

public partial class ProductDatum
{
    public string ProductName { get; set; }

    public string SellerName { get; set; }

    public string ProductDescription { get; set; }

    public double Price { get; set; }

    public bool IsAvailable { get; set; }

    public DateTime DateOfUpdating { get; set; }

    public Guid Id { get; set; }

    public List<string> GetPrintableStrings()
    {
        List<string> strings = new List<string>();
        strings.Add(ProductName);
        strings.Add(SellerName);
        strings.Add(ProductDescription);
        strings.Add(Price.ToString());
        strings.Add(IsAvailable.ToString());
        strings.Add(DateOfUpdating.ToString());
        return strings;
    }

    public ProductData GetProduct()
    {
        return new ProductData(ProductName, SellerName,
        ProductDescription, (float)Price, IsAvailable, DateOfUpdating);
    }
    public static ProductDatum CreateEntity(ProductData product)
    {
        ProductDatum entity = new ProductDatum();
        entity.ProductName = product.ProductName;
        entity.SellerName = product.SellerName;
        entity.ProductDescription = product.ProductDescription;
        entity.Price = product.Price;
        entity.IsAvailable = product.IsAvailable;
        entity.DateOfUpdating = product.DateOfUpdating;
        entity.Id = Guid.NewGuid();
        return entity;
    }
}
