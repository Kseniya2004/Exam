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
using System.Windows.Shapes;
using Exam.Classes;
using Microsoft.Win32;


namespace Exam
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPlan.xaml
    /// </summary>
    public partial class WindowAddPlan : Window
    {
        int mode;
        public WindowAddPlan()
        {
            InitializeComponent();
            mode = 0;
        }
        public WindowAddPlan(Aitport aitport)
        {
            InitializeComponent();
            mode = 1;
            txbNumber.Text = aitport.Number.ToString();
            txbTip.Text = aitport.Tip;
            txbCountMest.Text = aitport.CountMest.ToString();
            txbSkorost.Text = aitport.Skorost.ToString();
            txbRas.Text = aitport.Rasstoyanie.ToString();
            txbVylet.Text = aitport.Vylet;
            txbNaznach.Text = aitport.Naznachenie; ;
            txbBiletov.Text = aitport.Biletov.ToString();

            btnAddPlan.Content = "Сохранить";
        }

        private void btnAddPlan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(int.Parse(txbNumber.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbNumber.Clear();
                    txbNumber.Focus();
                    return;
                }
                if (int.Parse(txbCountMest.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbCountMest.Clear();
                    txbCountMest.Focus();
                    return;
                }
                if (double.Parse(txbSkorost.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbSkorost.Clear();
                    txbSkorost.Focus();
                    return;
                }
                if (double.Parse(txbRas.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbRas.Clear();
                    txbRas.Focus();
                    return;
                }
                if (int.Parse(txbBiletov.Text) < 0)
                {
                    MessageBox.Show("Значение не может быть отрицательным!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbBiletov.Clear();
                    txbBiletov.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {                
                    MessageBox.Show("Проверьте исходные данные!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);                  
            }
            if(mode == 0)
            {
                try
                {
                    Aitport aitport = new Aitport()
                    {
                        Number = int.Parse(txbNumber.Text),
                        Tip = txbTip.Text,
                        CountMest = int.Parse(txbCountMest.Text),
                        Skorost = double.Parse(txbSkorost.Text),
                        Rasstoyanie = double.Parse(txbRas.Text),
                        Vylet = txbVylet.Text,
                        Naznachenie = txbNaznach.Text,
                        Biletov = int.Parse(txbBiletov.Text)
                    };
                    ConnectHelper.aitports.Add(aitport);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проверьте исходные данные!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                try
                {
                    for(int i = 0; i < ConnectHelper.aitports.Count; i++)
                    { 
                        if(ConnectHelper.aitports[i].Number == int.Parse(txbNumber.Text))
                        {
                            ConnectHelper.aitports[i].Tip = txbTip.Text;
                            ConnectHelper.aitports[i].CountMest = int.Parse(txbCountMest.Text);
                            ConnectHelper.aitports[i].Skorost = double.Parse(txbSkorost.Text);
                            ConnectHelper.aitports[i].Rasstoyanie = double.Parse(txbRas.Text);
                            ConnectHelper.aitports[i].Vylet = txbVylet.Text;
                            ConnectHelper.aitports[i].Naznachenie = txbNaznach.Text;
                            ConnectHelper.aitports[i].Biletov = int.Parse(txbBiletov.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Проверьте исходные данные!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            ConnectHelper.SaveForFile(ConnectHelper.fileName);
            this.Close();
        }
        
    }
}
