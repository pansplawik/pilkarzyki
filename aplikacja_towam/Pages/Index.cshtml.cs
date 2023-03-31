using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using aplikacja_towam.Pages;
using Microsoft.AspNetCore.Routing;

namespace aplikacja_towam.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPostView()
        {
            var idd = Request.Form["index"];
            return LocalRedirect($"/Stats");
        }

        public IActionResult OnPost()
        {
            var idd = Request.Form["index"];
            var imie = Request.Form["imie"];
            var nazwisko = Request.Form["nazwisko"];
            SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
            //con.Open();
            ////SqlCommand cm = new SqlCommand("Select * from dbo.Uzytkownik", con);
            //SqlCommand cm = new SqlCommand($"INSERT INTO Uzytkownik(UzytkownikID, Imie, Nazwisko)\nVALUES({idd}, '{imie}', '{nazwisko}')", con);
            //cm.CommandType = CommandType.Text;
            //SqlDataReader reader = cm.ExecuteReader();
            //con.Close();
            //ViewData["cos"] = idd;
            return LocalRedirect($"/zawodnik/{idd}");
        }
    }
}
