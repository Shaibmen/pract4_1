using _1PractPractika.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
using System.Xml.Linq;

namespace _1PractPractika
{
    /// <summary>
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        ChurchServiceTableAdapter churchService = new ChurchServiceTableAdapter();
        ChurchTableAdapter church = new ChurchTableAdapter();
        PriestTableAdapter priest = new PriestTableAdapter();
        public List<String> Clerc = new List<String>();
        public List<String> Cerkov = new List<String>();
        public Page3()
        {
            InitializeComponent();
            thirdGrid.ItemsSource = churchService.GetData();
            Filter.ItemsSource = churchService.GetData();
            Filter.DisplayMemberPath = "churchServiceID";

            Rab.ItemsSource = priest.GetData();
            Rab.DisplayMemberPath = "first_name";
            Rab.SelectedIndex = 0;

            ierach.ItemsSource = church.GetData();
            ierach.DisplayMemberPath = "name";
            ierach.SelectedIndex = 0;
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {

            object idRab = (Rab.SelectedItem as DataRowView).Row[0];
            object idierach = (ierach.SelectedItem as DataRowView).Row[0];
            churchService.InsertQuery(Convert.ToDateTime(name.Text), Convert.ToInt32(idRab), Convert.ToInt32(idierach));
            thirdGrid.ItemsSource = churchService.GetData();
        } 

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            object Id = (thirdGrid.SelectedItem as DataRowView).Row[0];
            object idRab = (Rab.SelectedItem as DataRowView).Row[0];
            object idierach = (ierach.SelectedItem as DataRowView).Row[0];
            churchService.UpdateQuery(Convert.ToDateTime(name.Text), Convert.ToInt32(idRab), Convert.ToInt32(idierach), Convert.ToInt32(Id));
            thirdGrid.ItemsSource = churchService.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (thirdGrid.SelectedItem as DataRowView != null)
                {
                    object id = (thirdGrid.SelectedItem as DataRowView).Row[0];
                    churchService.DeleteQuery(Convert.ToInt32(id));
                    thirdGrid.ItemsSource = churchService.GetData();
                }
            }
            catch
            {
                MessageBox.Show("анлак");
            }
            
        }

        private void ierach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Rab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void thirdGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (thirdGrid.SelectedItem as DataRowView != null)
            {
                object namegrid = (thirdGrid.SelectedItem as DataRowView).Row[1];

                name.Text = namegrid.ToString();
            }
            else
            {
                MessageBox.Show("Незя на пустое тыкать");
            }

        }

        private void PoiskButton_Click(object sender, RoutedEventArgs e)
        {
            thirdGrid.ItemsSource = churchService.FilterByChurch(Convert.ToInt32(Poisk.Text));
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Filter.SelectedItem != null)
            {
                var id = (int)(Filter.SelectedItem as DataRowView).Row[0];
                thirdGrid.ItemsSource = churchService.FilterByChurchID(id);
            }
            
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            thirdGrid.ItemsSource = churchService.GetData();
        }
    }
}
