using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Exam.Classes
{
    class ConnectHelper
    {
        public static List<Aitport> aitports = new List<Aitport>();
        public static string fileName;
        public static void ReadFromFile(string FileName)
        {
            aitports.Clear();
            try
            {
                StreamReader streamReader = new StreamReader(FileName, Encoding.UTF8);
                while(!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] items = line.Split(';');
                    Aitport aitport = new Aitport()
                    {
                        Number = int.Parse(items[0].Trim()),
                        Tip = items[1].Trim(),
                        CountMest = int.Parse(items[2].Trim()),
                        Skorost = double.Parse(items[3].Trim()),
                        Rasstoyanie = double.Parse(items[4].Trim()),
                        Vylet = items[5].Trim(),
                        Naznachenie = items[6].Trim(),
                        Biletov = int.Parse(items[7].Trim())
                    };
                    ConnectHelper.aitports.Add(aitport);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Неверный формат файла!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public static void SaveForFile(string filename)
        {           
            try
            {
                StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
                foreach(Aitport c in aitports)
                {
                    streamWriter.WriteLine($"{c.Number};{c.Tip};{c.CountMest};{c.Skorost};{c.Rasstoyanie};{c.Vylet};{c.Naznachenie};{c.Biletov}");                                           
                }
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Файл не выбран", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

    }
}
