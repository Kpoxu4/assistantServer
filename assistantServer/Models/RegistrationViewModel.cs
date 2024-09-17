using System.ComponentModel.DataAnnotations;

namespace assistantServer.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Обязательное поле.")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать.")]
        public required string ConfirmPassword { get; set; }

        [Required (ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"^\+?\d{10,12}$", ErrorMessage = "Некорректный формат номера телефона.")]
        public required string PhoneNumber {  get; set; }
    }
}
