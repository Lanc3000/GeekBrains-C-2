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
using Microsoft.Win32;

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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML файл|*.XML|All files|*.*";
            if(dialog.ShowDialog()== true)
            {
                LoadXML(dialog.FileName);
                dgMainList.ItemsSource = employees;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML файл|*.XML|All files|*.*";
            if(dialog.ShowDialog() == true)
            {
                SaveXML(dialog.FileName);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            dgMainList.IsReadOnly = !dgMainList.IsReadOnly;
            if (dgMainList.IsReadOnly)
            {
                Edit.Content = "Разрешить редактирование";
            }
            else
            {
                Edit.Content = "Запретить редактирование";
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddFIO.Text == "ФИО" || tbAddFIO.Text == "")
            {
                MessageBox.Show("Введите ФИО", "Ошибка ввода", MessageBoxButton.OK);
            }
            else
            {
                employees.Add(new Employee() { 
                    FIO = tbAddFIO.Text,
                    GetBrigadeName = cbAddBrigade.SelectedItem.ToString()
                });
                MessageBox.Show($"Сотрудник {tbAddFIO.Text} добавлен в {cbAddBrigade.SelectedItem}.");
                tbAddFIO.Foreground = Brushes.Gray;
                tbAddFIO.Text = "ФИО";
                cbAddBrigade.SelectedIndex = 0;
            }
        }

        private void btnAddBrigade_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddNewBrigade.Text == "Название бригады" || tbAddNewBrigade.Text == "") {
                MessageBox.Show("Введите название бригады", "Ошибка ввода", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show($"Бригада {tbAddNewBrigade.Text} добавлена");
                brigades.Add(tbAddNewBrigade.Text);
                tbAddNewBrigade.Foreground = Brushes.Gray;
                tbAddNewBrigade.Text = "Название бригады";
            }
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
            catch { }
        }
        public void SaveXML(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Employee>));
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(fileStream, employees);
                }
            }
            catch { }
        }
    }
}
