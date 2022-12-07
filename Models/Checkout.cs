using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace HotelApp.Models
{
    public class Checkout
    {
        [BindNever]
        public int Id { get; set; }
        [BindRequired]
        public string? FullName { get; set; }
        public string? PreferredName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }
        public string? VerificaitonID { get; set; }


        public Checkout()
        {

        }
        
    }
}
