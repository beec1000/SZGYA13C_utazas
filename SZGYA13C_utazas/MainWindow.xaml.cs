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

            //1.feladat
            harmadikF.Text = $"A buszra {utazo.Count.ToString()} utas akart felszállni.";

            //2.feladat
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

            //3.feladat
            foreach (var i in utazo)
            {

            }

        }
    }
}