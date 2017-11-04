using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LocaFilme.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // com o Required a Coluna Name nao sera mais nullable e com StringLength limitado a 255
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        // Entity framework entende essa convencao e coloca a prop abaixo como a Chave
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        // Vou mudar o nome que será mostrado na View quando se busca o name dessa propriedade abaixo
        // Outra alternativa seria utilizar o <label></label> na View, porem teria que setar o Id para esse marcador
        // Caso o nome da propriedade abaixo mudasse, teria de ser mudado o Id tb
        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}