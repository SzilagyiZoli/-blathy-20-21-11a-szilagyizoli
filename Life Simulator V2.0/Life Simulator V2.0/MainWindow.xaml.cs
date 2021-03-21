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

namespace Life_Simulator_V2._0
{
    public class Player
    {
        public string name;
        public int age = 18;
        public int balance = 10000;
        public int lvl =0;
        public float education = 0;
        public string current_house = "Hajléktalan";
        public int healt = 100;
        public int credit_card_pin =0000;
        public int bank_balance =0;
        public int hungry = 0;
        public string workplpace = "Hajléktalan";


        public Player()
        {
            this.name = "Tibor";

        }
        public Player(string name)
        {
            this.name = name;
            
        }
        public void Work(string work_place, int hours)
        {
            switch (work_place)
            {
                case "Hajléktalan":
                    this.healt =this.healt- 1*hours ;
                    this.bank_balance = this.bank_balance+10*hours;
                    
                    break;
                case "Takarító":
                    break;
                case "Futár":
                    break;
                case "Kasszás":
                    break;
                case "Tanár":
                    break;
                case "Könyvelő":
                    break;
                case "Programozó":
                    break;
                default:
                    Console.WriteLine("Nincs munkahelyed");
                    break;
            }
        }
        public void sleep()// dátumot át kell állítani
        {
            this.healt = 100;
            


        }
        public void eat()
        {
            if (this.healt < 100)
            {
                this.healt += 20;
                this.balance -= 200;
                if (this.healt > 100)
                {
                    this.healt = 100;
                }
            }
        }
        public void heal()
        {
            int damage = 100 - this.healt;
            this.balance = this.balance - (damage * 20);
            this.healt = 100;
        }
        public void learn()
        {
            this.education+= 0.1F;
            this.balance -= 1000;
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public DateTime date = new DateTime(2000, 1, 1);
        public Player player1 = new Player();
        public MainWindow()
        {
            InitializeComponent();
            game_start(false);
        }

        private void game_start(bool load)
        {
            if (!load)
            {
                                
                data_write_out(player1);
            }
            else
            {
                //KÜLSŐ FÁJBÓL BETÖLTÉS
            }
        }
        private string dateToString()
        {
            string year = date.Year+".";
            string month;
            string day;
            if (date.Month<10)
            {
                month = "0"+date.Month + ".";
            }
            else
            {
                month = date.Month+".";
            }if (date.Day<10)
            {
                day = "0"+date.Day + ".";
            }
            else
            {
                day = date.Day+".";
            }
            return year + " " + month + " " + day;
        }
        private void data_write_out(Player player)
        {
            LB_age.Content ="Kor: "+ player.age.ToString();
            LB_balance.Content ="Készpénzed: "+ player.balance.ToString();
            LB_bank_balance.Content ="Banki egyenleg:" +player.bank_balance.ToString();
            LB_house.Content ="Házad: "+ player.current_house;
            LB_hungry.Content ="Éhség: " + player.hungry.ToString();
            LB_date.Content = "Dátum: " + dateToString() ;
            LB_level.Content = player.lvl;
            LB_nextlevel.Content = player.lvl+1;
            PG_healt.Value = player.healt;
        }

        private void BTN_work_Click(object sender, RoutedEventArgs e)
        {
            player1.Work(player1.workplpace, 1);
            data_write_out(player1);
        }
        private void BTN_sleep_Click(object sender, RoutedEventArgs e)
        {
            player1.sleep();
            data_write_out(player1);
        }

        private void BTN_eat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_bank_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_hospital_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTN_learn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
