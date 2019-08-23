using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Validation;

namespace WebApplication1.Models
{
    public class UserModel: EntityModel<User>
    {
        [Required]
        [Login]
        [DisplayName("Полное имя")]
        public string FIO { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтверждение")]
        public string ConfirmPassword { get; set; }
    }
}