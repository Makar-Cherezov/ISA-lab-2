using System;
using System.Collections.Generic;
using System.Text;
using ЛР_1_консоль;

namespace Server
{
    public interface IDataLoader
    {

        public dynamic LoadAll(string path);

        public ProductData LoadByNumber(string path, int position);


    }
    public interface IDataSaver
    {
        public void SaveProduct(string path, ProductData product);

        public void SaveAllProducts(string path, List<ProductData> allProduct);

        public void DeleteProduct(string path, int position);

    }

    public interface IDataParser
    {
        public ProductData ParseLineToProduct(string line);
        public ProductData ParseFieldsToProduct(List<string> fields);

        public string ParseProductToLine(ProductData product);
    }


}
