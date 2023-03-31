using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aplikacja_towam.Pages
{
    public class wgraneModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostVIew()
        {
            return LocalRedirect($"/zawodnik/1");
        }
    }
}
