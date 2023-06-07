using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aplikacja_towam.models;
using Newtonsoft.Json;
using System.Globalization;

namespace aplikacja_towam.Pages
{
    public class zawodnikModel : PageModel
    {
        public List<Strzaly> strzaly { get; set; }
        public List<Podania> podania { get; set; }
        public List<Cooper> cooper { get; set; }
        public List<Oddechy> oddechy { get; set; }
        public int ID { get; set; }
        public void OnGet(int id)
        {
            cooper=GenerujDystans();
            podania=GenerujPodania();
            strzaly=GenerujStrzaly();
            oddechy=GenerujOddechy();
            ViewData["aktualna"] = DateTime.Now;
        }
        public List<Strzaly> GenerujStrzaly()
        {
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"select DataAktywnosci,Wartosc from Wynik where Typ='Strzaly' and Id=43 order by DataAktywnosci", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            List<Strzaly> s = new List<Strzaly>();
            int i = 1;
            foreach (var item in reader)
            {
                int myString = reader.GetInt32(1);
                DateTime date = (DateTime)reader.GetDateTime(0);
                Strzaly strzaly = new Strzaly(i, myString, date);
                s.Add(strzaly);
                i++;
            }
            int max = 0;
            int ile = 0;
            int ilosc = 0;
            double srednia = 0.0;
            if (s.Count>0)
            {
            max = s.Max(x => x.wartosc);
            ile = s.Count(x => x.wartosc == max);
            ilosc = s.Count(x => x.wartosc > s.Average(y => y.wartosc));
            srednia = s.Average(x => x.wartosc);
            }
            ViewData["StrzalyStatystyki"] = $"Wartoœæ maksymalna: {ile}% wystêuje 1 razy.\nWartoœæ œrednia wynosi {srednia}%. {ilosc} wartoœci s¹ powy¿ej œredniej wartoœci.";
            return s;
        
        }
        public List<Podania> GenerujPodania()
        {
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"select DataAktywnosci,Wartosc from Wynik where Typ='podania' and Id=43 order by DataAktywnosci", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            List<Podania> s = new List<Podania>();
            int i = 1;
            foreach (var item in reader)
            {
                int myString = reader.GetInt32(1);
                DateTime date = (DateTime)reader.GetDateTime(0);
                Podania podania = new Podania(i, myString, date);
                s.Add(podania);
                i++;
            }
            int max = 0; 
                int ile = 0;
            double srednia = 0;
            if (s.Count>0)
            {
            max = s.Max(x => x.wartosc);
            ile = s.Count(x => x.wartosc == max);
            srednia = s.Average(x => x.wartosc);
            }
            
            ViewData["PodaniaStatystyki"] = $"Wartoœæ maksymalna: {max}% wystêuje {ile} razy\nWartoœæ œrednia wynosi {srednia}%";
            return s;
        }
        public List<Cooper> GenerujDystans()
        {
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"select DataAktywnosci,Wartosc from Wynik where Typ='Dystans' and Id=43 order by DataAktywnosci ", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            List<Cooper> s = new List<Cooper>();
            int i = 1;
            foreach (var item in reader)
            {
                int myString = reader.GetInt32(1);
                DateTime date = (DateTime)reader.GetDateTime(0);
                Cooper c = new Cooper(i, myString, date);
                s.Add(c);
                i++;
            }
            int max = 0;
            int ile = 0;
            double srednia = 0;
            if (s.Count>0)
            {
            max = s.Max(x => x.wartosc);
            ile = s.Count(x => x.wartosc == max);
             srednia = s.Average(x => x.wartosc);
            }
            
            ViewData["CooperStatystyki"] = $"Wartoœæ maksymalna: {max}% wystêuje {ile} razy\nWartoœæ œrednia wynosi {srednia}%";
            return s;
        }
        public List<Oddechy> GenerujOddechy()
        {
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"select DataAktywnosci,Wartosc from Wynik where Typ='Oddechy' and Id=43 order by DataAktywnosci", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            List<Oddechy> s = new List<Oddechy>();
            int i = 1;
            foreach (var item in reader)
            {
                int myString = reader.GetInt32(1);
                DateTime date = (DateTime)reader.GetDateTime(0);
                Oddechy c = new Oddechy(i, myString, date);
                s.Add(c);
                i++;
            }
            int max = 0;
            int ile = 0;
            double srednia = 0;
            if (s.Count > 0)
            {
                max = s.Max(x => x.wartosc);
            ile = s.Count(x => x.wartosc == max);
            srednia = s.Average(x => x.wartosc);
            }
            
            ViewData["OddechyStatystyki"] = $"Wartoœæ maksymalna: {max}% wystêuje {ile} razy\nWartoœæ œrednia wynosi {srednia}%";
            return s;
        }

        public IActionResult OnPostCooper()
        {
            int value = int.Parse(Request.Form["value"]);
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"insert into Wynik(Typ,DataAktywnosci,Wartosc,Id)values('Dystans','{data}',{value},43)", con);
            cm.CommandType = CommandType.Text;
            cm.ExecuteReader();
            return RedirectToPage();
        }
        public IActionResult OnPostPodania()
        {
            int value = int.Parse(Request.Form["podania"]);
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"insert into Wynik(Typ,DataAktywnosci,Wartosc,Id)values('Podania','{data}',{value},43)", con);
            cm.CommandType = CommandType.Text;
            cm.ExecuteReader();
            return RedirectToPage();
        }
        public IActionResult OnPostStrzaly()
        {
            int value = int.Parse(Request.Form["procentstrzalow"]);
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"insert into Wynik(Typ,DataAktywnosci,Wartosc,Id)values('Strzaly','{data}',{value},43)", con);
            cm.CommandType = CommandType.Text;
            cm.ExecuteReader();
            return RedirectToPage();
        }
        public IActionResult OnPostOddechy()
        {
            int value = int.Parse(Request.Form["ile"]);
            string data = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=Splawikop1.;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"insert into Wynik(Typ,DataAktywnosci,Wartosc,Id)values('Oddechy','{data}',{value},43)", con);
            cm.CommandType = CommandType.Text;
            cm.ExecuteReader();
            return RedirectToPage();
        }
    }
}
