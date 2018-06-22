using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
        }

        private void showEmployeeGrid_DpiChanged(object sender, DpiChangedEventArgs e)
        {
           
        }
        private void employeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //using (MyDbContext db = new MyDbContext())
            //{
            //    foreach (Employee item in db.Employees)
            //    {
            //        employeeGrid.Items.Add(item);
            //    }
            //}
        }

        private void showEmployeeGrid_Click(object sender, RoutedEventArgs e)
        {
            using (MyDbContext db = new MyDbContext())
            {
                foreach (var item in db.Employees)
                {
                   employeeGrid.CurrentColumn.Ad
                }
            }
        }
    }
}
