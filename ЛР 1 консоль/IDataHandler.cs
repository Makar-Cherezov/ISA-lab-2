using System;
using System.Collections.Generic;
using System.Text;
using NetConnection;

namespace Server
{
    public interface IDataLoader
    {

        public List<ProductData> LoadAll();

        public ProductData LoadByNumber(int position);


    }
    public interface IDataSaver
    {
        public void SaveProduct(ProductData product);

        public void SaveAllProducts(List<ProductData> allProduct);

        public void DeleteProduct(int position);

    }

 


}
