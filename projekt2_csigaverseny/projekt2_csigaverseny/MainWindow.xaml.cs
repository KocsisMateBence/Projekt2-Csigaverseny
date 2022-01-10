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
using System.Windows.Threading;

namespace projekt2_csigaverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        double celVonal;
        int szamlalo;

        public MainWindow()
        {
            InitializeComponent();
            celVonal = cel.Margin.Left;
            timer.Interval = TimeSpan.FromSeconds(0.3);
            timer.Tick += new EventHandler(Mozgas);
            ujFutam.IsEnabled = false;
            ujBajnoksag.IsEnabled = false;
        }

        private void Mozgas(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ++szamlalo;
            rossi.Margin = new Thickness(szamlalo += rnd.Next(10,20), -350, 650, 0);
            hyundai.Margin = new Thickness(szamlalo += rnd.Next(10, 20), 231, 0, 0);
            subaru.Margin = new Thickness(szamlalo += rnd.Next(10, 20), 332, 0, 0);

            if (rossi.Margin.Right == celVonal)
            {
                timer.Stop();

                palya1.Fill = Brushes.Gold;
            }
            else if (hyundai.Margin.Right == celVonal)
            {
                timer.Stop();
                palya2.Fill = Brushes.Silver;
            } 

            if (hyundai.Margin.Right == celVonal)
            {
                timer.Stop();

                palya2.Fill = Brushes.Gold;
            }
            else if (subaru.Margin.Right == celVonal)
            {
                timer.Stop();
                palya3.Fill = Brushes.Silver;
            }

            if (subaru.Margin.Right == celVonal)
            {
                timer.Stop();

                palya3.Fill = Brushes.Gold;
            }
            else if (hyundai.Margin.Right == celVonal)
            {
                timer.Stop();
                palya2.Fill = Brushes.Silver;
            }


        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            ujFutam.IsEnabled = false;
            ujBajnoksag.IsEnabled = false;
            start.IsEnabled = false;
        }

        private void ujFutam_Click(object sender, RoutedEventArgs e)
        {
            rossi.Margin = new Thickness(137, 100, 724, 450);
            hyundai.Margin = new Thickness(21, 235, 0, 0);
            subaru.Margin = new Thickness(24, 332, 0, 0);
        }
        private class Versenyzo
        {
             string nev;
             int pont;
            int[] pontok = new int[4] { 0, 25, 18, 15 };
            int[] helyezes;
             

            public Versenyzo(string nev)
            {
               this.nev = nev;
                this.helyezes = new int[4];
            }

            public int Pont => this.helyezes[1] * this.pontok[1] + this.helyezes[2] * this.pontok[2] + this.helyezes[3] * this.pontok[3];

            public string Nev
            {
                get => this.nev;
               
            }

            public int[] Helyezes
            {
                get => this.helyezes;
                
            }
        }
    }
}
