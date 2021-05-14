using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoderBlog.UI.Models
{
    public class TestVM
    {
        [Required(ErrorMessage ="Boş Olamaz")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Olamaz")]
        [MinLength(5,ErrorMessage ="5 harfden küçük olamaz")]
        public string Ad { get; set; }
        public string Soyad { get; set; }

    }
}
