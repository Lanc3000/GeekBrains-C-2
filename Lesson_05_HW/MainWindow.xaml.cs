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
using Lesson_05_HW;

namespace Lesson_05_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Doubler doubler;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void wndMain_Loaded(object sender, RoutedEventArgs e)
        {
            doubler = new Doubler(10, 100);
            tbFinish.Text = doubler.Finish.ToString();
            tbCurrent.Text = doubler.Current.ToString();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            doubler.Plus();
            tbCurrent.Text = doubler.ToString();
        }

        private void btnMulti_Click(object sender, RoutedEventArgs e)
        {
            doubler.Multi();
            tbCurrent.Text = doubler.ToString();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            doubler.Reset();
            tbCurrent.Text = doubler.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            doubler.Back();
            tbCurrent.Text = doubler.ToString();
        }
    }
}
