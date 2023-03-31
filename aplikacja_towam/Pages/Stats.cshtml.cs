using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using aplikacja_towam.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aplikacja_towam.Pages
{
    public class StatsModel : PageModel
    {
        public List<Strzaly> strzaly { get; set; }
        public List<Podania> podania { get; set; }
        public List<Cooper> cooper { get; set; }
        public List<WyciskanieMax> wyciskanieMax { get; set; }
        public List<WyciskanieMaxIlosc> wyciskanieMaxIlosc { get; set; }
        public int ddd { get; set; }
        public void OnGet()
        {
            //GenerujCooper();
            //GenerujPodania();
            //GenerujStrzaly();
            //GenerujWyciskanieMax();
            //ViewData["aktualna"] = DateTime.Now;
        }

        public List<WyciskanieMaxIlosc> GenerujWyciskanieMaxIlosc()
        {
            SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
            con.Open();
            SqlCommand cm = new SqlCommand("Select * from dbo.WyciskanieMaxKilka order by DataAktywnosci", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader readera = cm.ExecuteReader();
            List<WyciskanieMaxIlosc> s = new List<WyciskanieMaxIlosc>();
            int i = 1;
            foreach (var item in readera)
            {
                Console.WriteLine(item);
                int myString = readera.GetInt32(1);
                int ile = readera.GetInt32(0);
                DateTime date = (DateTime)readera.GetDateTime(3);
                WyciskanieMaxIlosc wyciskanieMaxIlosc = new WyciskanieMaxIlosc(i, myString, ile, date);
                s.Add(wyciskanieMaxIlosc);
                i++;
            }

            return s;
        }
        // git
        //public void GenerujWyciskanieMax()
        //{
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    SqlCommand cm = new SqlCommand("Select max(kilogramy),DataAktywnosci from WyciskanieMax group by DataAktywnosci", con);
        //    cm.CommandType = CommandType.Text;
        //    SqlDataReader reader = cm.ExecuteReader();
        //    List<WyciskanieMax> s = new List<WyciskanieMax>();
        //    int i = 1;
        //    foreach (var item in reader)
        //    {
        //        int myString = reader.GetInt32(0);
        //        DateTime data = (DateTime)reader.GetDateTime(1);
        //        WyciskanieMax wyciskanieMax = new WyciskanieMax(i, myString, data);
        //        s.Add(wyciskanieMax);
        //        i++;
        //    }
        //    int max = s.Max(x => x.wartosc);
        //    int ile = s.Count(x => x.wartosc == max);
        //    int ilosc = s.Count(x => x.wartosc > s.Average(y => y.wartosc));
        //    double srednia = s.Average(x => x.wartosc);
        //    ViewData["SztangaStatystyki"] = $"Wartoœæ maksymalna: 98 kg " +
        //     $"wystêuje 2 razy. Wartoœæ œrednia wynosi 78kg. 9 wartoœci s¹ powy¿ej œredniej wartoœci.";

        //}
        //// git
        //public void GenerujCooper()
        //{
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    SqlCommand cm = new SqlCommand("Select max(Wartosc),DataAktywnosci from Cooper group by DataAktywnosci", con);
        //    cm.CommandType = CommandType.Text;
        //    SqlDataReader reader = cm.ExecuteReader();
        //    List<Cooper> s = new List<Cooper>();
        //    int i = 1;
        //    foreach (var item in reader)
        //    {
        //        decimal myString = reader.GetDecimal(0);
        //        DateTime data = (DateTime)reader.GetDateTime(1);
        //        Cooper cooper = new Cooper(i, myString, data);
        //        s.Add(cooper);
        //        i++;
        //    }
        //    decimal max = s.Max(x => x.wartosc);
        //    int ile = s.Count(x => x.wartosc == max);
        //    int ilosc = s.Count(x => x.wartosc > s.Average(y => y.wartosc));
        //    decimal srednia = s.Average(x => x.wartosc);
        //    ViewData["CooperStatystyki"] = $"Wartoœæ maksymalna: 9.5km wystêuje 1 razy.  Wartoœæ œrednia wynosi 7.9km. 6 wartoœci s¹ powy¿ej œredniej wartoœci.";
        //}
        //// git
        //public void GenerujStrzaly()
        //{
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    SqlCommand cm = new SqlCommand("Select max(StrzalyProcentowo),DataAktywnosci from Strzaly group by DataAktywnosci", con);
        //    cm.CommandType = CommandType.Text;
        //    SqlDataReader reader = cm.ExecuteReader();
        //    List<Strzaly> s = new List<Strzaly>();
        //    int i = 1;
        //    foreach (var item in reader)
        //    {
        //        int myString = reader.GetInt32(0);
        //        DateTime date = (DateTime)reader.GetDateTime(1);
        //        Strzaly strzaly = new Strzaly(i, myString, date);
        //        s.Add(strzaly);
        //        i++;
        //    }
        //    int max = s.Max(x => x.wartosc);
        //    int ile = s.Count(x => x.wartosc == max);
        //    int ilosc = s.Count(x => x.wartosc > s.Average(y => y.wartosc));
        //    double srednia = s.Average(x => x.wartosc);
        //    ViewData["StrzalyStatystyki"] = $"Wartoœæ maksymalna: 96% wystêuje 1 razy.\nWartoœæ œrednia wynosi 86%. 4 wartoœci s¹ powy¿ej œredniej wartoœci.";
        //}
        //// git
        //public void GenerujPodania()
        //{
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    SqlCommand cm = new SqlCommand("Select max(PodaniaProcentowo),DataAktywnosci from Podania group by DataAktywnosci", con);
        //    cm.CommandType = CommandType.Text;
        //    SqlDataReader reader = cm.ExecuteReader();
        //    List<Podania> s = new List<Podania>();
        //    int i = 1;
        //    foreach (var item in reader)
        //    {
        //        int myString = reader.GetInt32(0);
        //        DateTime date = (DateTime)reader.GetDateTime(1);
        //        Podania podania = new Podania(i, myString, date);
        //        s.Add(podania);
        //        i++;
        //    }
        //    int max = s.Max(x => x.wartosc);
        //    int ile = s.Count(x => x.wartosc == max);
        //    double srednia = s.Average(x => x.wartosc);
        //    ViewData["PodaniaStatystyki"] = $"Wartoœæ maksymalna: 93% wystêuje 1 razy\nWartoœæ œrednia wynosi 76%"; 
        //}

        //public IActionResult OnPostCooper()
        //{
        //    var data = Request.Form["trip-start"];
        //    var dystans = Request.Form["dystanscooper"];
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    //SqlCommand cm = new SqlCommand("Select * from dbo.Uzytkownik", con);
        //    SqlCommand cmm = new SqlCommand($"INSERT INTO Cooper(UzytkownikID,Wartosc,DataAktywnosci) VALUES ({ddd},{dystans},'{data}');", con);
        //    cmm.CommandType = CommandType.Text;
        //    SqlDataReader readerrr = cmm.ExecuteReader();
        //    con.Close();
        //    return LocalRedirect($"/wgrane");
        //}
        //public IActionResult OnPostSztangamax()
        //{
        //    var data = Request.Form["trip-start"];
        //    var maxkssztanga = Request.Form["maxkg"];
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    //SqlCommand cm = new SqlCommand("Select * from dbo.Uzytkownik", con);
        //    SqlCommand cmm = new SqlCommand($"Insert INTO WyciskanieMax(UzytkownikID,kilogramy,DataAktywnosci) Values ({ddd},{maxkssztanga},'{data}') ", con);
        //    cmm.CommandType = CommandType.Text;
        //    SqlDataReader readerrr = cmm.ExecuteReader();
        //    con.Close();
        //    return LocalRedirect($"/wgrane");
        //}
        //public IActionResult OnPostSztangamaxile()
        //{
        //    var data = Request.Form["trip-start"];
        //    var maxilekg = Request.Form["maxilekg"];
        //    var maxwagakg = Request.Form["maxwagakg"];
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    //SqlCommand cm = new SqlCommand("Select * from dbo.Uzytkownik", con);
        //    SqlCommand cmm = new SqlCommand($"Insert INTO WyciskanieMaxKilka(UzytkownikID,kilogramyWyciskane,ilosc,DataAktywnosci) Values ({ddd},{maxwagakg},{maxilekg},'{data}')", con);
        //    cmm.CommandType = CommandType.Text;
        //    SqlDataReader readerrr = cmm.ExecuteReader();
        //    con.Close();
        //    return LocalRedirect($"/wgrane");
        //}
        //public IActionResult OnPostStrzaly()
        //{
        //    var data = Request.Form["trip-start"];
        //    var strzaly = Request.Form["procentstrzalow"];
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    //SqlCommand cm = new SqlCommand("Select * from dbo.Uzytkownik", con);
        //    SqlCommand cmm = new SqlCommand($"Insert INTO Strzaly(UzytkownikID,StrzalyProcentowo,DataAktywnosci) Values ({ddd},{strzaly},'{data}')", con);
        //    cmm.CommandType = CommandType.Text;
        //    SqlDataReader readerrr = cmm.ExecuteReader();
        //    con.Close();
        //    return LocalRedirect($"/wgrane");
        //}
        //public IActionResult OnPostPodania()
        //{
        //    var data = Request.Form["trip-start"];
        //    var podania = Request.Form["procentpodan"];
        //    SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
        //    con.Open();
        //    //SqlCommand cm = new SqlCommand("Select * from dbo.Uzytkownik", con);
        //    SqlCommand cmm = new SqlCommand($"INSERT INTO Podania(UzytkownikID,PodaniaProcentowo,DataAktywnosci) VALUES ({ddd},{podania},'{data}');", con);
        //    cmm.CommandType = CommandType.Text;
        //    SqlDataReader readerrr = cmm.ExecuteReader();
        //    con.Close();
        //    return LocalRedirect($"/wgrane");
        //}

    }
}
