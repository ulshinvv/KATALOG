using KATALOG.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATALOG.viewModel
{
    internal class UserViewModel : INotifyPropertyChanged
    {
        public Product _product;
        public System.Windows.Input.ICommand ExitCommand { get; }
        public System.Windows.Input.ICommand NavigateCommand { get; }
        public System.Windows.Input.ICommand ChangeQuantityCommand { get; }

        public Product SelectedProduct { get; set; }

        public UserViewModel(Product product)
        {
            // ChangeQuantityCommand = new RelayCommand(ExecuteChangeQuantity, CanExecuteChangeQuantity);
            _product = product;
        }

        public UserViewModel()
        {
            LoadProducts();
            ExitCommand = new ICommand(ExecuteExit, CanExecuteExit);
            NavigateCommand = new ICommand(ExecuteNavigate, CanExecuteNavigate);

        }

        private int id_Продукты;
        public int ID_Продукты
        {
            get { return id_Продукты; }
            set { id_Продукты = value; }
        }

        private string имя;
        public string Имя
        {
            get { return имя; }
            set { имя = value; }
        }
        private string единица;
        public string Единица
        {
            get { return единица; }
            set { единица = value; }
        }
        private decimal расходы;
        public decimal Расходы
        {
            get { return расходы; }
            set { расходы = value; }
        }

        private int максимальная_сумма_скидки;
        public int Максимальная_сумма_скидки
        {
            get { return максимальная_сумма_скидки; }
            set { максимальная_сумма_скидки = value; }
        }

        private string производитель;
        public string Производитель
        {
            get { return производитель; }
            set { производитель = value; }
        }

        private string поставщик;
        public string Поставщик
        {
            get { return поставщик; }
            set { поставщик = value; }
        }

        private int категория;
        public int Категория
        {
            get { return категория; }
            set { категория = value; }
        }

        private int текущая_скидка;
        public int Текущая_скидка
        {
            get { return текущая_скидка; }
            set { текущая_скидка = value; }
        }

        private int количество_на_складе;
        public int Количество_на_складе
        {
            get { return количество_на_складе; }
            set { количество_на_складе = value; }
        }

        private string описание;
        public string Описание
        {
            get { return описание; }
            set { описание = value; }
        }

        private string фото;
        public string Фото
        {
            get { return фото; }
            set { фото = value; }
        }

        private ProductCategory fk_Product_Category;
        public ProductCategory FK_Product_Category
        {
            get { return fk_Product_Category; }
            set { fk_Product_Category = value; }
        }

        private void LoadProducts()
        {
            MyDbContext myDbContext = new MyDbContext();

            using (SqlConnection connection = new SqlConnection(myDbContext.connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Title, Price, Kollichestvo FROM Products";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> product_ = new List<Product>();

                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                Kollichestvo = reader.GetString(3)
                            };

                            product_.Add(product);
                        }
                        _LWProduct = product_;
                    }
                }
            }
        }

        private List<Product> _LWProduct;

        public List<Product> LWProduct
        {
            get { return _LWProduct; }
            set
            {
                _LWProduct = value;
                OnPropertyChanged(nameof(LWProduct));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ExecuteExit(object parameter)
        {
            //var mainWindow = new MainWindow();
            //var logControl = new LoginWindow();
            //mainWindow.Content = logControl;
            //mainWindow.Show();
        }

        private bool CanExecuteExit(object parameter)
        {
            return true;
        }


        private void ExecuteNavigate(object parameter)
        {
            //var mainWindow = new MainWindow();
            //var OrderControl = new ShowOrderForUser();
            //mainWindow.Content = OrderControl;
            //mainWindow.Show();

        }

        private bool CanExecuteNavigate(object parameter)
        {
            return true;
        }

    }
    public class ICommand : System.Windows.Input.ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public ICommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        //public static implicit operator ICommand(RelayCommand v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
