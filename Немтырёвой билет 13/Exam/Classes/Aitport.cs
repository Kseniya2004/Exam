using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Classes
{
    public class Aitport
    {
        //поля
        private int number;
        private string tip;
        private int countMest;
        private double skorost;
        private double rasstoyanie;
        private string vylet;
        private string naznachenie;
        private int biletov;
        //свойства
        public int Number {get{ return number;}set{number = value ;} } 
        public string Tip { get { return tip; } set { tip = value; } }
        public int CountMest { get { return countMest; } set { countMest = value; } }
        public double Skorost { get { return skorost; } set { skorost = value; } }
        public double Rasstoyanie { get { return rasstoyanie; } set { rasstoyanie = value; } }
        public string Vylet { get { return vylet; } set { vylet = value; } }
        public string Naznachenie { get { return naznachenie; } set { naznachenie = value; } }
        public int Biletov { get { return biletov; } set { biletov = value; } }
        //конструкторны
        public Aitport()
        {
            number = 0;
            tip = "";
            countMest = 0;
            skorost = 0;
            rasstoyanie = 0;
            vylet  = "";
            naznachenie = "";
            biletov = 0;
        }
        public Aitport(int number,string tip, int countMest, double skorost, double rasstoyanie, string vylet, string naznachenie, int biletov)
        {
            Number = number;
            Tip = tip;
            CountMest = countMest;
            Skorost = skorost;
            Rasstoyanie = rasstoyanie;
            Vylet = vylet;
            Naznachenie = naznachenie;
            Biletov = biletov;
        }
    }
}
