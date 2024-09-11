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

            cmb1.Items.Add("Válasszon megállót!");
            cmb1.SelectedIndex = 0;

            var megallok = utazo.Select(m => m.Megallo).Distinct().ToList();
            foreach (var i in megallok)
            {
                cmb1.Items.Add(i);
            }
            
        }

        private void TB2_TextChanged(object sender, TextChangedEventArgs e)
        {
            TB2.MaxLength = 7;

            string kartyaszam = TB2.Text;
            TBl.Text = $"{kartyaszam.Length}db";
        }
    }
}
