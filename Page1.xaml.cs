using _1PractPractika.DataSet1TableAdapters;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

namespace _1PractPractika
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        ChurchTableAdapter church = new ChurchTableAdapter();

        public Page1()
        {
            InitializeComponent();
            FirstGrid.ItemsSource = church.GetData();
            Filter.ItemsSource = church.GetData();
            Filter.DisplayMemberPath = "name";
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            church.InsertQuery(name.Text, address.Text, established_date.Text);
            FirstGrid.ItemsSource = church.GetData();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object Id = (FirstGrid.SelectedItem as DataRowView).Row[0];

            church.UpdateQuery(name.Text, address.Text, established_date.Text, Convert.ToInt32(Id));
            FirstGrid.ItemsSource = church.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FirstGrid.SelectedItem as DataRowView != null)
                {
                    object id = (FirstGrid.SelectedItem as DataRowView).Row[0];
                    church.DeleteQuery(Convert.ToInt32(id));
                    FirstGrid.ItemsSource = church.GetData();

                }
            }
            catch
            {
                MessageBox.Show("анлак");
            }


            
        }

        private void FirstGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstGrid.SelectedItem as DataRowView != null)
            {
                object name1 = (FirstGrid.SelectedItem as DataRowView).Row[1];
                object address2 = (FirstGrid.SelectedItem as DataRowView).Row[2];
                object data = (FirstGrid.SelectedItem as DataRowView).Row[3];
                name.Text = name1.ToString();
                address.Text = address2.ToString();
                established_date.Text = data.ToString();
            }
            else
            {
                MessageBox.Show("Незя на пустое тыкать");
            }
        }

        private void PoiskButton_Click(object sender, RoutedEventArgs e)
        {
            FirstGrid.ItemsSource = church.SearchByName(Poisk.Text);
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            FirstGrid.ItemsSource = church.GetData();
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = (int)(Filter.SelectedItem as DataRowView).Row[0];
            FirstGrid.ItemsSource = church.FilterByaddress(id);
        }
    }
}
