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
using System.Security.Cryptography;
using System.Text;
using System.Drawing;

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
            var login = Request.Form["log"];
            var passwd = Request.Form["passwd"];
            Console.WriteLine(HashPassword(passwd));
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=***;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"SELECT Id FROM Uzytkownik WHERE Username LIKE '{login}' AND PasswordHash LIKE '{HashPassword(passwd)}'", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.HasRows) // Sprawdź, czy czytnik zawiera dane
            {
                reader.Read(); // Przejdź do pierwszego rekordu

                int a = reader.GetInt32(0);
                

                reader.Close(); // Zamknij czytnik
                con.Close(); // Zamknij połączenie
                return LocalRedirect($"/zawodnik/{a}");
            }
            return null;
        }

        public IActionResult OnPost()
        {
            var fullName = Request.Form["fullName"];
            var login = Request.Form["login"];
            var password = Request.Form["passwd"];
            // Połączenie z bazą danych
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=***;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"INSERT INTO Uzytkownik (FullName, Username, PasswordHash) VALUES ('{fullName}', '{login}', '{HashPassword(password)}')", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            Random rand = new Random();
            int rnadom = rand.Next(4);
            return LocalRedirect($"/zawodnik/{getId(password,login)}");
        }

        // Metoda haszowania hasła (przykład - należy użyć odpowiedniej, bezpiecznej metody haszowania)
        public string HashPassword(string password)
        {
            // Tutaj można zastosować odpowiednią metodę haszowania hasła, na przykład bcrypt, PBKDF2, SCrypt, etc.
            // Przykładowo, zastosujmy prostą funkcję hashującą SHA256
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public int getId(string password,string login)
        {
            SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=***;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            con.Open();
            SqlCommand cm = new SqlCommand($"SELECT Id FROM Uzytkownik WHERE Username LIKE '{login}' AND PasswordHash LIKE '{HashPassword("admin")}'", con);
            cm.CommandType = CommandType.Text;
            SqlDataReader reader = cm.ExecuteReader();
            if (reader.HasRows) // Sprawdź, czy czytnik zawiera dane
            {
                reader.Read(); // Przejdź do pierwszego rekordu

                int a = reader.GetInt32(0);


                reader.Close(); // Zamknij czytnik
                con.Close(); // Zamknij połączenie
                return a;
            }
            return 0;
        }

    }
}
   