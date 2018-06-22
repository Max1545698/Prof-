using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridAddRows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Employees = new ObservableCollection<Employee>()
            {
                new Employee{Name = "Anton", Age = 19},
                new Employee{Name = "Danil", Age = 21},
                new Employee{Name = "Victor", Age = 24},
                new Employee{Name = "Vlad", Age = 22}
            };
            Employees.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Categories_CollectionChanged);
            this.DataContext = Employees;
        }

        public void Categories_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
           if(e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                MessageBox.Show("New Row Added");
            }
        }

        public ObservableCollection<Employee> Employees { get; set; }


        private void dataGrid1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Employees.Add(new Employee());
        }
    }

    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Employee()
        {
            Id = Guid.NewGuid();
        }
    }
}
