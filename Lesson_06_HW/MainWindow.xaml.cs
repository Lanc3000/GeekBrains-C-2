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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Xml.Serialization;
using System.IO;

namespace Lesson_06_HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> brigades = new ObservableCollection<string>() { 
            "Бригада цифрознаковых индикаторов",
            "Бригада стабилитронов",
            "Бригада СВЧ-диодов",
            "Бригада кристаллов"
        };
        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();
            LoadXML("..\\..\\EmployeeList.xml");
            cbAddBrigade.SelectedIndex = 0;
            cbAddBrigade.ItemsSource = brigades;
            dgMainList.ItemsSource = employees;
            dataGridComboBox.ItemsSource = brigades;
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddBrigade_Click(object sender, RoutedEventArgs e)
        {

        }
        public void LoadXML(string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Employee>));
            try {
                using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    employees = (ObservableCollection<Employee>)formatter.Deserialize(fileStream);
                }
            }
            catch (Exception e) { Console.WriteLine($"Ошибка чтения с файла {e.Message}"); }
        }
    }
}
