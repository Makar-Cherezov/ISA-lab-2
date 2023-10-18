using ClientWPFApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NetConnection;
using System.Collections.ObjectModel;
using Client;
using System.Security.Policy;

namespace WindowView
{
    class WindowController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


        private RequestController requestController;

        private ObservableCollection<ProductData> products;
        public ObservableCollection<ProductData> Products
        {
            get
            {
                return this.products;
            }
            set
            {
                this.products = value;
                OnPropertyChanged();
            }
        }
        private int dataGridIndex;
        public int DataGridIndex
        {
            get
            {
                return this.dataGridIndex;
            }
            set
            {
                this.dataGridIndex = value;
                OnPropertyChanged();
            }
        }
        private ProductData dataGridItem;
        public ProductData DataGridItem
        {
            get
            {
                return this.dataGridItem;
            }
            set
            {
                this.dataGridItem = value;
                OnPropertyChanged();
            }
        }
        
        public WindowController()
        {
            products = new();
            dataGridIndex = -1;
            try
            {
                requestController = new RequestController("127.0.0.1", 8080);
                requestController.SetModelType("sql"); // добавить радиобаттон
            }
            catch (Exception ex) { };
        }


        private Command? loadALLCommand;
        public Command LoadALLCommand
        {
            get => loadALLCommand ??= new Command(obj =>
            {
                Products.Clear();
                Products = requestController.GetFullData();
                
            });
        }
        private Command? deleteCommand;
        public Command DeleteCommand
        {
            get => deleteCommand ??= new Command(obj =>
            {
                if (DataGridIndex == Products.Count() - 1)
                    Products.RemoveAt(DataGridIndex);
                else if (requestController.DeleteData(dataGridIndex))
                {
                    Products.RemoveAt(DataGridIndex); ;
                    DataGridIndex = 1;
                }
                
                else MessageBox.Show("Ошибка удаления строки");
            });
        }
        private Command? addItemCommand;
        public Command AddItemCommand
        {
            get => addItemCommand ??= new Command(obj =>
            {
                Products.Add(new ProductData("","","", 0, true, DateTime.Now));
            });
        }
        private Command? updateCommand;
        public Command UpdateCommand
        {
            get => updateCommand ??= new Command(obj =>
            {
                List<String> fields = DataGridItem.GetPrintableStrings();
                if (fields.Contains(""))
                    MessageBox.Show("Заполните все поля!");
                else {
                    requestController.SaveNewData(fields, DataGridIndex);
                    MessageBox.Show("Изменения сохранены в базе данных"); }
            });
        }
    }

}
