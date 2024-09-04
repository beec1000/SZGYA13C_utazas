using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZGYA13C_utazas
{
    internal class Utazas
    {
        public int Megallo { get; set; }
        public DateTime FelszallasDatum { get; set; }
        public int EgyediAzonosito { get; set; }
        public string JegyBerletTipus { get; set; }
        public int JegyBertelErvenyesseg { get; set; }

        public Utazas (int megallo, DateTime felszallasDatum, int egyediAzonosito, string jegyBerletTipus, int jegyBertelErvenyesseg)
        {
            Megallo = megallo;
            FelszallasDatum = felszallasDatum;
            EgyediAzonosito = egyediAzonosito;
            JegyBerletTipus = jegyBerletTipus;
            JegyBertelErvenyesseg = jegyBertelErvenyesseg;
        }

        public static List<Utazas> FromFile(string path)
        {
            List<Utazas> utazas = new List<Utazas>();

            string[] line = File.ReadAllLines(path);

            foreach (var l in line)
            {
                string[] u = l.Split(" ");

                int Megallo = int.Parse(u[0]);
                DateTime Datum = DateTime.ParseExact(u[1], "yyyyMMdd-HHmm", null);
                int Azonosito = int.Parse(u[2]);
                string Tipus = u[3];
                int Ervenyesseg = int.Parse(u[4]);

                Utazas utazo = new Utazas(Megallo, Datum, Azonosito, Tipus, Ervenyesseg);
                utazas.Add( utazo );

            }
            return utazas;

        }

        public override string ToString()
        {
            return $"{Megallo} | {FelszallasDatum} | {EgyediAzonosito} | {JegyBerletTipus} | {JegyBertelErvenyesseg}";
        }
    }
}
