using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Server
{
    public class SQLDataHandler : DataHandler
    {
        public override void DeleteProduct(int position)
        {
            try
            {
                using var context = new CherezovAisContext();
                var entities = context.Set<ProductDatum>();
                entities.Remove(entities.OrderBy(x => x.ProductName).ToList().ElementAt(position));
                context.SaveChanges();
            }
            catch { throw; }
        }

        public override List<ProductData> LoadAll()
        {
            using var context = new CherezovAisContext();
            var entities = context.Set<ProductDatum>();
            List<ProductData> prList = new List<ProductData>();
            foreach (var ent in entities.OrderBy(x => x.ProductName).ToList())
            {
                prList.Add(ent.GetProduct());
            }
            return prList;
        }

        public override ProductData LoadByNumber(int position)
        {
            using var context = new CherezovAisContext();
            var entities = context.Set<ProductDatum>();
            List<ProductData> prList = new List<ProductData>();
            foreach (var ent in entities.OrderBy(x => x.ProductName).ToList())
            {
                prList.Add(ent.GetProduct());
            }
            return prList[position];
        }

        public override void SaveAllProducts(List<ProductData> allProduct)
        {
            throw new NotImplementedException();
        }

        public override void SaveProduct(ProductData product)
        {
            try
            {
                ProductDatum entry = ProductDatum.CreateEntity(product);
                using var context = new CherezovAisContext();
                var entries = context.Set<ProductDatum>();
                entries.Add(entry);
                context.SaveChanges();
            }
            catch { throw; }
        }

        public override void SetPath(string path)
        {
            //опционально реализовать выбор таблицы?
            throw new NotImplementedException();
        }
    }
}
