using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ThynkPCRProject.Pages.PCR
{
    public class IndexModel : PageModel
    {
        public List<UserBooking> userbooking = new List<UserBooking>();

        public void OnGet()
        {

        }
    }

    public class UserBooking
    {
        public String idcard;
    }

    public class BookingStatus
    {
        char code;
        String name;
    }
}
