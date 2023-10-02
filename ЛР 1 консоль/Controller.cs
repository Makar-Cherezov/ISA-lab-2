using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Server
{
    public class Controller
    {
        private static Controller? instance;
        public static Controller GetInstance()
        {
            instance ??= new Controller(';');
            return instance;
        }
        public string Path { get; set; }
        private CSVDataHandler dataHandler { get; set; } //public
        public Controller(char delimeter)
        {
            dataHandler = new CSVDataHandler(delimeter);
        }

        public bool SetAndCheckPath(string path)
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
            dataHandler.SaveProduct(Path, dataHandler.ParseTextToProduct(productData));
        }
        public void DeleteData(int position)
        {
            dataHandler.DeleteProduct(Path, position);
        }

    }
}
