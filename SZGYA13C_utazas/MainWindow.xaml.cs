using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Globalization;
using System.IO;

namespace SZGYA13C_utazas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Utazas> utazo = new List<Utazas>();

        public MainWindow()
        {
            InitializeComponent();

            utazo = Utazas.FromFile(@"..\..\..\src\utasadat.txt");

            //3.feladat
            harmadikF.Text = $"A buszra {utazo.Count.ToString()} utas akart felszállni.";

            //4.feladat
            int JegyNelkuli = 0;
            foreach (var i in utazo)
            {
                if (i.JegyBerletTipus == "JGY" && i.JegyBerletErvenyesseg == 0)
                {
                    JegyNelkuli++;
                }
            }

            int LejartBerlet = 0;
            foreach (var i in utazo)
            {
                if (i.JegyBerletErvenyesseg.ToString().Length == 8)
                {
                    DateTime berletErvenyesseg = DateTime.ParseExact(i.JegyBerletErvenyesseg.ToString(), "yyyyMMdd", null);
                    DateTime felszallasDatum = DateTime.ParseExact(i.FelszallasDatum.ToString("yyyyMMdd"), "yyyyMMdd", null);

                    if (berletErvenyesseg < felszallasDatum)
                    {
                        LejartBerlet++;
                    }
                }
            }

            negyedikF.Text = $"A buszra {(JegyNelkuli + LejartBerlet).ToString()} utas nem szállhatott fel.";

            //5.feladat
            var Megallok = utazo.GroupBy(m => m.Megallo)
            .OrderByDescending(g => g.Count())   
            .First();

            var x = Megallok.First();

            foreach (var i in Megallok)
            {
                ötödikF.Text = $"A legtöbb utas ({Megallok.Count()} fő) a {i.Megallo}. megállóban próbált felszállni.";
            }

            //6. feladat
            int kedvezmenyesU = 0;
            int ingyenesU = 0;

            foreach (var i in utazo)
            {
                if (i.JegyBerletErvenyesseg.ToString().Length == 8)
                {
                    DateTime berletErvenyesseg = DateTime.ParseExact(i.JegyBerletErvenyesseg.ToString(), "yyyyMMdd", null);
                    DateTime felszallasDatum = DateTime.ParseExact(i.FelszallasDatum.ToString("yyyyMMdd"), "yyyyMMdd", null);

                    if (berletErvenyesseg > felszallasDatum)
                    {
                        if (i.JegyBerletTipus == "TAB" || i.JegyBerletTipus == "NYB")
                        {
                            kedvezmenyesU++;
                        }
                        if (i.JegyBerletTipus == "NYP" || i.JegyBerletTipus == "GYK" || i.JegyBerletTipus == "RVS")
                        {
                            ingyenesU++;
                        }
                    }
                }
            }


            hatodikF.Text = $"Az ingyenesen utazók száma: {ingyenesU} fő \n" +
                $"A kedvezményesen utazók száma {kedvezmenyesU} fő";

            //7. feladat
            using StreamWriter sw = new StreamWriter(@"..\..\..\src\figyelmeztetes.txt");
            {
                foreach (var i in utazo)
                {
                    if (i.JegyBerletErvenyesseg.ToString().Length == 8)
                    {
                        DateTime berletErvenyesseg = DateTime.ParseExact(i.JegyBerletErvenyesseg.ToString(), "yyyyMMdd", null);
                        DateTime felszallasDatum = DateTime.ParseExact(i.FelszallasDatum.ToString("yyyyMMdd"), "yyyyMMdd", null);

                        if (berletErvenyesseg.Year == felszallasDatum.Year && 
                            berletErvenyesseg.Month == felszallasDatum.Month && 
                            (berletErvenyesseg.Day - felszallasDatum.Day) <= 3)
                        {
                            sw.WriteLine($"{i.EgyediAzonosito} {i.JegyBerletErvenyesseg}");
                        }
                    }
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
        }
    }
}