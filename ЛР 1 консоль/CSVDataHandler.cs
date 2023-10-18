using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using NetConnection;


namespace Server
{
    public class CSVDataHandler : DataHandler
    {
        private string Path {  get; set; }
        char Delimeter { get; set; }
        public CSVDataHandler(char delimeter)
        {
            Delimeter = delimeter;
        }
        public override void SetPath(string path)
        {
            Path = path;
        }
        public ProductData ParseLineToProduct(string line)
        {
            string[] fields = line.Split(Delimeter);
            return new ProductData(fields[0], 
                fields[1], fields[2],
                            float.Parse(fields[3]), bool.Parse(fields[4]), 
                            DateTime.Parse(fields[5]));
        }
        
        public string ParseProductToLine(ProductData product)
        {
            string line = product.ProductName + Delimeter +
                product.SellerName + Delimeter +
                product.ProductDescription + Delimeter +
                product.Price.ToString() + Delimeter +
                product.IsAvailable.ToString() + Delimeter +
                product.DateOfUpdating.ToString();
            return line;
        }

        public override List<ProductData> LoadAll()
        {
            List<ProductData> allProducts = new List<ProductData>();
            string[] lines = File.ReadAllLines(Path);
            foreach (string line in lines)
            {
                allProducts.Add(ParseLineToProduct(line));
            }
            return allProducts;
        }
        public override ProductData LoadByNumber(int position)
        {
            try
            {
                string line = File.ReadLines(Path).ElementAt(position);
                return ParseLineToProduct(line);
            }
            catch(Exception ex)
            {
                throw new Exception("Обращение к несуществующей строке.");
            }
        }
        public override void SaveProduct(ProductData product)
        {
            using (var streamWriter = new StreamWriter(Path, append: true))
            {
                streamWriter.WriteLine(ParseProductToLine(product));
            }
        }
        public override void SaveAllProducts(List<ProductData> allProducts)
        {
            using (var streamWriter = new StreamWriter(Path))
            {
                foreach (var product in allProducts)
                {
                    streamWriter.WriteLine(ParseProductToLine(product), true);
                }
                
            }
        }
        //public override void DeleteProduct(string path, ProductData product) // можно сделать удаление по слову
        //{
        //    File.WriteAllLines(path, 
        //        File.ReadLines(path).Where(l => l != ParseProductToLine(product)).ToList());
        //}
        public override void DeleteProduct(int position)
        {
            List<string> dataList = File.ReadLines(Path).ToList();
            if (position < 1 || dataList.Count() < position)
            { throw new Exception("Выбранной для удаления строки нет в файле"); }
            File.WriteAllLines(Path,
                File.ReadLines(Path).Where((line, index) => index != position - 1).ToList());
        }

        public override void SaveOrUpdateProduct(ProductData product, int pos)
        {
            throw new NotImplementedException();
        }
    }
}
