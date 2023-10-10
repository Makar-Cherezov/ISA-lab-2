using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using ЛР_1_консоль;

namespace Server
{
    public class CSVDataHandler : DataHandler
    {
        char Delimeter { get; set; }
        public CSVDataHandler(char delimeter)
        {
            Delimeter = delimeter;
        }
        public override ProductData ParseLineToProduct(string line)
        {
            string[] fields = line.Split(Delimeter);
            return new ProductData(fields[0], 
                fields[1], fields[2],
                            float.Parse(fields[3]), bool.Parse(fields[4]), 
                            DateTime.Parse(fields[5]));
        }
        public override ProductData ParseFieldsToProduct(List<string> fields)
        {
            return new ProductData(fields[0],
                fields[1], fields[2],
                            float.Parse(fields[3]), bool.Parse(fields[4]), 
                            DateTime.Parse(fields[5]));
        }
        public override string ParseProductToLine(ProductData product)
        {
            string line = product.ProductName + Delimeter +
                product.SellerName + Delimeter +
                product.ProductDescription + Delimeter +
                product.Price.ToString() + Delimeter +
                product.IsAvailable.ToString() + Delimeter +
                product.DateOfUpdating.ToString();
            return line;
        }

        public override dynamic LoadAll(string path)
        {
            List<ProductData> allProducts = new List<ProductData>();
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                allProducts.Add(ParseLineToProduct(line));
            }
            return allProducts;
        }
        public override ProductData LoadByNumber(string path, int position)
        {
            try
            {
                string line = File.ReadLines(path).ElementAt(position);
                return ParseLineToProduct(line);
            }
            catch(Exception ex)
            {
                throw new Exception("Обращение к несуществующей строке.");
            }
        }
        public override void SaveProduct(string path, ProductData product)
        {
            using (var streamWriter = new StreamWriter(path, append: true))
            {
                streamWriter.WriteLine(ParseProductToLine(product));
            }
        }
        public override void SaveAllProducts(string path, List<ProductData> allProducts)
        {
            using (var streamWriter = new StreamWriter(path))
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
        public override void DeleteProduct(string path, int position)
        {
            List<string> dataList = File.ReadLines(path).ToList();
            if (position < 1 || dataList.Count() < position)
            { throw new Exception("Выбранной для удаления строки нет в файле"); }
            File.WriteAllLines(path,
                File.ReadLines(path).Where((line, index) => index != position - 1).ToList());
        }

    }
}
