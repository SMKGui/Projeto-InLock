using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "O campo senha precisa de no mínimo e no máximo 20 caracteres")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Senha { get; set; }

        public TiposUsuarioDomain TiposUsuario { get; set; }
    }
}
