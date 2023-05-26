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
            //SqlConnection con = new SqlConnection("Server=LAPTOP-9UMOVV12;Database=pilkarzyki;Trusted_Connection=True;");
            //con.Open();
            //SqlCommand cm = new SqlCommand("Select id from dbo.Uzytkownik where login like '(login)' AND password like '(passwd)'", con);
            //cm.CommandType = CommandType.Text;
            //SqlDataReader reader = cm.ExecuteReader();
            //if (reader != null)
            //{
            //    con.Close();
            //    return LocalRedirect($"/Stats/'(reader)'");
            //}
            //else
            //{
            //    string script = "alert('Nie prawidłowe dane.');";
            //    return Content("<script>" + script + "</script>");
            //}
            return LocalRedirect($"/Stats/");
        }

        public IActionResult OnPost()
        {
            var fullName = Request.Form["fullName"];
            var login = Request.Form["login"];
            var password = Request.Form["passwd"];
            // Połączenie z bazą danych
            using (SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();

                // Wstawianie danych do tabeli
                using (SqlCommand cm = new SqlCommand("INSERT INTO Uzytkownik (FullName, Username, PasswordHash) VALUES ('@FullName', '@Username', '@PasswordHash')", con))
                {
                    cm.Parameters.AddWithValue("@FullName", fullName);
                    cm.Parameters.AddWithValue("@Username", login);
                    cm.Parameters.AddWithValue("@PasswordHash", HashPassword(password));

                    cm.ExecuteNonQuery();
                }
            }
            int id = getId(HashPassword(password), login);
            return LocalRedirect($"/zawodnik/{id}");
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
            using (SqlConnection con = new SqlConnection("Data Source=kamilsplawinski.database.windows.net;Initial Catalog=pazig;User ID=pansplawik;Password=;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                con.Open();

                // Pobieranie ID użytkownika
                using (SqlCommand com = new SqlCommand($"SELECT Id FROM Uzytkownik WHERE FullName like '{login}' AND PasswordHash like '{password}'", con))
                {
                    SqlDataReader reader = com.ExecuteReader();
                    return reader.GetInt32(0);
                }
            }
        }

    }
}
   