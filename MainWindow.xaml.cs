using System;
using System.Collections.Generic;
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
using _1PractPractika.DataSet1TableAdapters;


namespace _1PractPractika
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChurchTableAdapter church = new ChurchTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Church(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
        }

        private void ChurchService(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page3();
        }

        private void Priest(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
        }
    }
}
