using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        public string Path { get; set; }
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
        public bool SetAndCheckPath(string path) // спрятать для sql
        {
            if (File.Exists(path) && System.IO.Path.GetExtension(path) == ".csv")
            {
                Path = path;
                return true;
            }
            else return false;
        }
        public string GetString(List<string> fields, int pos = 1)
        {
            string result = pos.ToString() + " | ";
            foreach (string field in fields)
                result += field + " | ";
            return result;
        }
        public List<string> GetFullData()
        {
            var rawData = dataHandler.LoadAll(Path);
            var printableData = new List<string>();
            int pos = 1;
            foreach (var product in rawData)
            {
                printableData.Add(GetString(product.GetPrintableStrings(), pos));
                pos++;
            }
            return printableData;
        }
        public string GetLineByNumber(int pos)
        {
            var rawData = dataHandler.LoadByNumber(Path, pos);
            return GetString(rawData.GetPrintableStrings(), pos);
        }
        public void SaveNewData(List<string> productData)
        {
            dataHandler.SaveProduct(Path, dataHandler.ParseFieldsToProduct(productData));
        }
        public void DeleteData(int position)
        {
            dataHandler.DeleteProduct(Path, position);
        }

    }
}
