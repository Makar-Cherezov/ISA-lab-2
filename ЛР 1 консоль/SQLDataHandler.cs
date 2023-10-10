using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ЛР_1_консоль;
using ЛР_1_консоль.Entities;

namespace Server
{
    public class SQLDataHandler : DataHandler
    {
        public override void DeleteProduct(string path, int position)
        {
            throw new NotImplementedException();
        }

        public override dynamic LoadAll(string entity)
        {
            using var context = new _8i11CherezovContext();
            var entities = context.Set<Студенты>();
            return entities.ToList();


        }

        public override ProductData LoadByNumber(string path, int position)
        {
            throw new NotImplementedException();
        }

        public override ProductData ParseFieldsToProduct(List<string> fields)
        {
            throw new NotImplementedException();
        }

        public override ProductData ParseLineToProduct(string line)
        {
            throw new NotImplementedException();
        }

        public override string ParseProductToLine(ProductData product)
        {
            throw new NotImplementedException();
        }

        public override void SaveAllProducts(string path, List<ProductData> allProduct)
        {
            throw new NotImplementedException();
        }

        public override void SaveProduct(string path, ProductData product)
        {
            throw new NotImplementedException();
        }
    }
}
