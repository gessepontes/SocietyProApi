using SocietyProApi.Domain.Diversos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocietyProApi.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            Teams = new HashSet<Team>();
            PessoaPerfis = new HashSet<PessoaPerfil>();
        }

        public int ID { get; set; }


        string sNome;
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string NOME
        {
            get
            {
                if (string.IsNullOrEmpty(sNome))
                {
                    return sNome;
                }
                return Diverso.FirstCharToUpper(sNome);
            }
            set
            {
                sNome = value;
            }

        }

        [Display(Name = "Cpf")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public string CPF { get; set; }

        [Display(Name = "Rg")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public string RG { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        public DateTime DATANASCIMENTO { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        [StringLength(15)]
        public string TELEFONE { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "{0} é um campo obrigatório.")]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string EMAIL { get; set; }

        [Display(Name = "Foto")]
        public string FOTO { get; set; }

        string sSenha;

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string SENHA
        {
            get
            {
                if (string.IsNullOrEmpty(sSenha))
                {
                    return sSenha;
                }
                return Diverso.GenerateMD5(sSenha);
            }
            set
            {
                sSenha = value;
            }

        }

        [Display(Name = "Ativo")]
        public bool ATIVO { get; set; }

        [Display(Name = "Confirmação")]
        public bool CONFIRMACAO { get; set; }

        public string SECURITYSTAMP { get; set; }

        [Display(Name = "Status")]
        public bool STATUS { get; set; }

        public DateTime DATACADASTRO { get; set; }

        public string IDPUSH { get; set; }

        [NotMapped]
        public string token { get; set; }

        public ICollection<PessoaPerfil> PessoaPerfis { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Field> Field { get; set; }


    }
}