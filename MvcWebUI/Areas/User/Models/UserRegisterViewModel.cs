using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Areas.User.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Girin")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Lütfen Resim Url Değerinizi Girin")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Girin")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Girin")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Girin")]
        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil")]
        public string ConfirmPassword { get; set; }

    }
}
