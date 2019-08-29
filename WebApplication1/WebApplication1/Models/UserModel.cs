using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Files;
using WebApplication1.Validation;

namespace WebApplication1.Models
{
    public class UserModel: EntityModel<User>
    {
        [Required]        
        [DisplayName("Полное имя")]
        public string FIO { get; set; }

        [Required]
        [Login]
        [DisplayName("Имя пользователя")]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
               
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтверждение")]
        public string ConfirmPassword { get; set; }

        public User CreationAutor { get; set; }

        [DataType(DataType.Upload)]
        public BinaryFileWrapper Avatar { get; set; }
    }
}