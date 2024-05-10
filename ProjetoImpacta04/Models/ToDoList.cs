using System.ComponentModel.DataAnnotations;

namespace ProjetoImpacta04.Models
{
    public class ToDoList
    {
        public int ToDoListId { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string? Content { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public string? Category { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateStart { get; set; } = DateTime.Now;
        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateExpiration { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Selecione um status!")]
        public string? Status { get; set; }
        public bool Atrasado => Status == "A Fazer" && DateExpiration < DateTime.Today;
       
    }
}
