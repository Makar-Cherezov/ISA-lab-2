using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_1_консоль;

namespace Server
{
    public abstract class DataHandler : IDataSaver, IDataLoader, IDataParser
    {
        public abstract void DeleteProduct(string path, int position);
        public abstract dynamic LoadAll(string path);
        public abstract ProductData LoadByNumber(string path, int position);
        public abstract string ParseProductToLine(ProductData product);
        public abstract ProductData ParseLineToProduct(string line);
        public abstract void SaveAllProducts(string path, List<ProductData> allProduct);
        public abstract void SaveProduct(string path, ProductData product);
        public abstract ProductData ParseFieldsToProduct(List<string> fields);
    }
}
