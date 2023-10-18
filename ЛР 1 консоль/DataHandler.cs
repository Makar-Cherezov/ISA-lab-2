using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using NetConnection;

namespace Server
{
    public abstract class DataHandler : IDataSaver, IDataLoader
    {
        public abstract void DeleteProduct(int position);
        public abstract List<ProductData> LoadAll();
        public abstract ProductData LoadByNumber(int position);
        
        public abstract void SaveAllProducts(List<ProductData> allProduct);
        public abstract void SaveProduct(ProductData product);
        public abstract void SaveOrUpdateProduct(ProductData product, int pos);
        public abstract void SetPath(string path);
    }
}
