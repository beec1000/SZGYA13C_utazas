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

namespace SZGYA13C_utazas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private List<Utazas> utazo = new List<Utazas>();

        public Window1()
        {
            InitializeComponent();

            utazo = Utazas.FromFile(@"..\..\..\src\utasadat.txt");

            string alapCMB = "Válasszon megállót!";

            CMB1.Items.Add(alapCMB);
            CMB1.SelectedIndex = 0;

            var megallok = utazo.Select(m => m.Megallo).Distinct().ToList();
            foreach (var i in megallok) CMB1.Items.Add(i);


            CMB2.Items.Add(alapCMB);
            CMB2.SelectedIndex = 0;

            var berletTipusok = utazo.Select(t => t.JegyBerletTipus).Distinct().Where(t => t != "JGY").ToList();
            foreach(var i in berletTipusok) CMB2.Items.Add(i);

            DP1.SelectedDate = DateTime.Today;
            DP2.SelectedDate = DateTime.Today;

        }

        private void TB2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TB2.MaxLength = 7;

            string kartyaszam = TB2.Text;
            TBl.Text = $"{kartyaszam.Length}db";
        }

        private void S1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int sliderV = (int)Sli1.Value;
            TB3.Text = $"{sliderV}db";
        }

        private void RBb_Checked(object sender, RoutedEventArgs e)
        {
            GBb.Visibility = Visibility.Visible;
            GBj.Visibility = Visibility.Collapsed;
        }

        private void RBj_Checked(object sender, RoutedEventArgs e)
        {
            GBb.Visibility = Visibility.Collapsed;
            GBj.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CMB1.SelectedIndex == 0)
            {
                MessageBox.Show("Nem választott megállót!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //nincs értelme, de itt van
            //if (DP1.SelectedDate == DP1.SelectedDate)
            //{
            //    MessageBox.Show("Nem adott dátumot!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}

            if (TB2.Text.Length != 7)
            {
                MessageBox.Show("A kártya azonosítója nem 7 karakter hosszú!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TB2.Text != string.Empty && int.Parse(TB2.Text) < 0)
            {
                MessageBox.Show("A kártya azonosítója nem lehet negatív szám!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            if (CMB2.SelectedIndex == 0)
            {
                MessageBox.Show("Nem választott bérlet típust!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (DP2.SelectedDate == DateTime.Today)
            {
                MessageBox.Show("Nem adta meg a bérlet érvényességi idejét!", "Configuration", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
