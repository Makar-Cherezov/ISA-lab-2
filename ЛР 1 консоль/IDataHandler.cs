using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public interface IDataLoader
    {

        public List<ProductData> LoadAll(string path);

        public ProductData LoadByNumber(string path, int position);


    }
    public interface IDataSaver
    {
        public void SaveProduct(string path, ProductData product);

        public void SaveAllProducts(string path, List<ProductData> allProduct);

        public void DeleteProduct(string path, ProductData product);

    }

    public interface IDataParser
    {
        public ProductData ParseTextToProduct(string line);

        public string ParseProductToLine(ProductData product);
    }


}
