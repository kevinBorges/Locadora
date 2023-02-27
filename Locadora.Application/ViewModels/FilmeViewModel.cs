using Locadora.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Application.ViewModels
{
    public class FilmeViewModel : EntityBase
    {
        [Display(Name ="Título")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [MaxLength(50,ErrorMessage ="Tamanho máximo de 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        public Categorias Categoria { get; set; }
    }
}
