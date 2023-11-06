namespace PlanningsTool.DAL.Models
{
    public class Holiday
    {
        // Bron is van belgium.be
        private const int PINKSTEREN_DAYS_AFTER_EASTER = 49; // 49 dagen na Pasen is Pinksteren
        private const int PINKSTERMONDAY_DAYS_AFTER_PINKSTEREN = 1; // Pinkstermaandag is de dag na Pinksteren
        private const int OLHHEMELVAART_DAYS_AFTER_EASTER = 39; // 39 dagen na Pasen is O.L.H. Hemelvaart
        private const int EASTERMONDAY_DAYS_AFTER_EASTER = 1; // Paasmaandag is de dag na Pasen

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public static DateTime CalculateEaster(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31;
            int day = ((h + l - 7 * m + 114) % 31) + 1;

            return new DateTime(year, month, day);
        }

        public static DateTime CalculateEastermonday(int year)
        {
            // Paasmaandag is de dag na Pasen
            DateTime easterMonday = CalculateEaster(year);
            return easterMonday.AddDays(EASTERMONDAY_DAYS_AFTER_EASTER);
        }

        public static DateTime CalculatePinksteren(int year)
        {
            // 49 dagen na Pasen is Pinksteren
            DateTime easterDate = CalculateEaster(year);
            return easterDate.AddDays(PINKSTEREN_DAYS_AFTER_EASTER);
        }

        public static DateTime CalculatePinkstermonday(int year)
        {
            // Pinkstermaandag is de dag na Pinksteren
            DateTime easterDate = CalculateEaster(year);
            DateTime pinksterenDate = easterDate.AddDays(PINKSTEREN_DAYS_AFTER_EASTER);
            return pinksterenDate.AddDays(PINKSTERMONDAY_DAYS_AFTER_PINKSTEREN);
        }

        public static DateTime CalculateOLHHemelvaart(int year)
        {
            // 39 dagen na Pasen is O.L.H. Hemelvaart
            DateTime easterDate = CalculateEaster(year);
            return easterDate.AddDays(OLHHEMELVAART_DAYS_AFTER_EASTER);
        }

        public static DateTime Newyear(int year)
        {
            // Nieuwjaar is op 1 januari
            return new DateTime(year, 1, 1);
        }

        public static DateTime DagVdArbeid(int year)
        {
            // Dag van de arbeid is op 1 mei
            return new DateTime(year, 5, 1);
        }

        public static DateTime NationalHoliday(int year)
        {
            // Nationale feestdag is op 21 juli
            return new DateTime(year, 7, 21);
        }

        public static DateTime OLVHemelvaart(int year)
        {
            // Onze-Lieve-Vrouw Hemelvaart is op 15 augustus
            return new DateTime(year, 8, 15);
        }

        public static DateTime Allerheiligen(int year)
        {
            // Allerheiligen is op 1 november
            return new DateTime(year, 11, 1);
        }

        public static DateTime Wapenstilstand(int year)
        {
            // Wapenstilstand is op 11 november
            return new DateTime(year, 11, 11);
        }

        public static DateTime Christmas(int year)
        {
            // Kermis is op 25 december
            return new DateTime(year, 12, 25);
        }
    }
}