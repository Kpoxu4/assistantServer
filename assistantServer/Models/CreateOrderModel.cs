using System.ComponentModel.DataAnnotations;

namespace assistantServer.Models
{
    public class CreateOrderModel
    {
        [Required(ErrorMessage = "Обязательное поле.")]
        public string FirstLastName { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        [RegularExpression(@"^\+?\d{10,12}$", ErrorMessage = "Некорректный формат номера телефона.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int ProductPrice { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int AdvancePayment { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int ProductionTime { get; set; }

        [Required(ErrorMessage = "Обязательное поле.")]
        public int UserId { get; set; } 
    }
}
