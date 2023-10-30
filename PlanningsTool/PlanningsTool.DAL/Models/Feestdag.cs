using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningsTool.DAL.Models
{
    public class Feestdag
    {
        // Bron is van belgium.be
        private const int PINKSTEREN_DAGEN_NA_PASEN = 49; // 49 dagen na Pasen is Pinksteren
        private const int PINKSTERMAANDAG_DAGEN_NA_PINKSTEREN = 1; // Pinkstermaandag is de dag na Pinksteren
        private const int OLHHEMELVAART_DAGEN_NA_PASEN = 39; // 39 dagen na Pasen is O.L.H. Hemelvaart
        private const int PAASMAANDAG_DAGEN_NA_PASEN = 1; // Paasmaandag is de dag na Pasen

        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime Datum { get; set; }

        public static DateTime BerekenPasen(int jaar)
        {
            int a = jaar % 19;
            int b = jaar / 100;
            int c = jaar % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int maand = (h + l - 7 * m + 114) / 31;
            int dag = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(jaar, maand, dag);
        }

        public static DateTime BerekenPaasmaandag(int jaar)
        {
            // Paasmaandag is de dag na Pasen
            DateTime paasMaandag = BerekenPasen(jaar);
            return paasMaandag.AddDays(PAASMAANDAG_DAGEN_NA_PASEN);
        }

        public static DateTime BerekenPinksteren(int jaar)
        {
            // 49 dagen na Pasen is Pinksteren
            DateTime pasenDatum = BerekenPasen(jaar);
            return pasenDatum.AddDays(PINKSTEREN_DAGEN_NA_PASEN);
        }

        public static DateTime BerekenPinkstermaandag(int jaar)
        {
            // Pinkstermaandag is de dag na Pinksteren
            DateTime pasenDatum = BerekenPasen(jaar);
            DateTime pinksterenDatum = pasenDatum.AddDays(PINKSTEREN_DAGEN_NA_PASEN);
            return pinksterenDatum.AddDays(PINKSTERMAANDAG_DAGEN_NA_PINKSTEREN);
        }

        public static DateTime BerekenOLHHemelvaart(int jaar)
        {
            // 39 dagen na Pasen is O.L.H. Hemelvaart
            DateTime pasenDatum = BerekenPasen(jaar);
            return pasenDatum.AddDays(OLHHEMELVAART_DAGEN_NA_PASEN);
        }

        public static DateTime Nieuwjaar(int jaar)
        {
            // Nieuwjaarsdag is op 1 januari
            return new DateTime(jaar, 1, 1);
        }

        public static DateTime DagVdArbeid(int jaar)
        {
            // Dag van de arbeid is op 1 mei
            return new DateTime(jaar, 5, 1);
        }

        public static DateTime NationaleFeestdag(int jaar)
        {
            // Nationale feestdag is op 21 juli
            return new DateTime(jaar, 7, 21);
        }

        public static DateTime OLVHemelvaart(int jaar)
        {
            // Onze-Lieve-Vrouw Hemelvaart is op 15 augustus
            return new DateTime(jaar, 8, 15);
        }

        public static DateTime Allerheiligen(int jaar)
        {
            // Allerheiligen is op 1 november
            return new DateTime(jaar, 11, 1);
        }

        public static DateTime Wapenstilstand(int jaar)
        {
            // Wapenstilstand is op 11 november
            return new DateTime(jaar, 11, 11);
        }

        public static DateTime Kermis(int jaar)
        {
            // Kermis is op 25 december
            return new DateTime(jaar, 12, 25);
        }
    }
}