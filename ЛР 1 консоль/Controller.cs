using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NetConnection;
using System.Linq;

namespace Server
{
    public class Controller
    {
        private static Controller? instance;
        public static Controller GetInstance(string modeltype)
        {
            instance ??= new Controller(modeltype);
            return instance;
        }
        private DataHandler dataHandler { get; set; } 
        public Controller(string modeltype)
        {
            switch(modeltype)
            {
                case "csv":
                    dataHandler = new CSVDataHandler(';');
                    break;
                case "sql":
                    dataHandler = new SQLDataHandler();
                    break;
            }
        }
        public bool SetAndCheckPath(string path)
        {
            if (File.Exists(path) && System.IO.Path.GetExtension(path) == ".csv")
            {
                dataHandler.SetPath(path);
                return true;
            }
            else return false;
        }
        public List<string> GetFullData()
        {
            var rawData = dataHandler.LoadAll();
            var printableData = new List<string>();
            foreach (var product in rawData)
            {
                printableData.Add(string.Join(';',product.GetPrintableStrings()));
            }
            return printableData;
        }
        public string GetLineByNumber(int pos)
        {
            ProductData rawData = dataHandler.LoadByNumber(pos);
            return string.Join(' ', rawData.GetPrintableStrings());
        }
        public void SaveNewData(List<string> productData)
        {
            int pos = int.Parse(productData.Last());
            productData.RemoveAt(productData.Count - 1);
            dataHandler.SaveOrUpdateProduct(ProductData.ParseFieldsToProduct(productData), pos);
        }
        public void DeleteData(int position)
        {
            dataHandler.DeleteProduct(position);
        }

    }
}
