using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Desafio.Models
{
    public class ProdutoViewModel
    {
        [DisplayName("Nome")]
        [MaxLength(100, ErrorMessage = "Tamanho máximo do nome do produto é de 100 caracteres.")]
        [Required(ErrorMessage = "Informe o nome do produto", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [DisplayName("Código")]
        [MaxLength(10, ErrorMessage = "Tamanho máximo do código do produto é de 10 caracteres.")]
        [Required(ErrorMessage = "Informe o código do produto", AllowEmptyStrings = false)]
        public string Code { get; set; }

        [DisplayName("Descrição")]
        [MaxLength(500, ErrorMessage = "Tamanho máximo da descrição do produto é de 500 caracteres.")]
        [Required(ErrorMessage = "Informe a descrição do produto", AllowEmptyStrings = false)]
        public string Description { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "Informe o preço do produto", AllowEmptyStrings = false)]
        public int Price { get; set; }

        public long? Id { get; set; }
        
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
    }
}
