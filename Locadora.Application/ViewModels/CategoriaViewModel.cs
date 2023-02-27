using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Locadora.Application.ViewModels
{
    public class CategoriaViewModel : EntityBaseViewModel
    {
        [MaxLength(20, ErrorMessage = "Tamanho máximo de 20 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }
    }
}
