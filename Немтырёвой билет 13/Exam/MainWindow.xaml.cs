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
using Exam.Classes;
using Microsoft.Win32;

namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MiOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                ConnectHelper.fileName = openFileDialog.FileName;
                ConnectHelper.ReadFromFile(ConnectHelper.fileName);
            }
            else
                return;
            dtgListAirport.ItemsSource = ConnectHelper.aitports.ToList();
        }

        private void MiSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if ((bool)saveFileDialog.ShowDialog())
            {
                string file = saveFileDialog.FileName;
                ConnectHelper.SaveForFile(file);
            }
        }

        private void MiExit_Click(object sender, RoutedEventArgs e) =>
        Close();

        private void MiList_Click(object sender, RoutedEventArgs e)
        {
            dtgListAirport.ItemsSource = ConnectHelper.aitports.ToList();
            dtgListAirport.SelectedIndex = -1;

            TxbCount.Text = ConnectHelper.aitports.Count().ToString();
        }

        private void MiAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPlan windowAddPlan = new WindowAddPlan();
            windowAddPlan.ShowDialog();
        }

        private void MiClear_Click(object sender, RoutedEventArgs e)
        {
            dtgListAirport.ItemsSource = null;
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            dtgListAirport.ItemsSource = ConnectHelper.aitports.Where(x =>
            x.Vylet.ToLower().Contains(TxbSearch.Text.ToLower())).ToList();
        }

        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            dtgListAirport.ItemsSource = ConnectHelper.aitports.OrderBy(x =>
            x.Number).ToList();
        }

        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            dtgListAirport.ItemsSource = ConnectHelper.aitports.OrderByDescending(x =>
            x.Number).ToList();
        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(CmbFiltr.SelectedIndex == 0)
            {
                dtgListAirport.ItemsSource = ConnectHelper.aitports.Where(x =>
                x.Rasstoyanie < 50).ToList();
                MessageBox.Show("Расстояние рейса меньше 50!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (CmbFiltr.SelectedIndex == 1)
            {
                dtgListAirport.ItemsSource = ConnectHelper.aitports.Where(x =>
                x.Rasstoyanie >= 50 && x.Rasstoyanie < 100).ToList();
                MessageBox.Show("Расстояние рейса от 50 до 100!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else 
            {
                dtgListAirport.ItemsSource = ConnectHelper.aitports.Where(x =>
                x.Rasstoyanie >= 100).ToList();
                MessageBox.Show("Расстояние рейса больше 100!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPlan windowAddPlan = new WindowAddPlan((sender as Button).DataContext as Aitport);
            windowAddPlan.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var mesasge = MessageBox.Show("Вы точно хотите удалить запись!", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(mesasge == MessageBoxResult.Yes)
            {
                int ind = dtgListAirport.SelectedIndex;
                ConnectHelper.aitports.RemoveAt(ind);

                dtgListAirport.ItemsSource = ConnectHelper.aitports.ToList();
                ConnectHelper.SaveForFile(ConnectHelper.fileName);
            }
        }

        private void MiKursiv_Checked(object sender, RoutedEventArgs e)
        {
            TxbSearch.FontStyle = FontStyles.Italic;
        }

        private void MiKursiv_Unchecked(object sender, RoutedEventArgs e)
        {
            TxbSearch.FontStyle = FontStyles.Normal;
        }
    }
}
