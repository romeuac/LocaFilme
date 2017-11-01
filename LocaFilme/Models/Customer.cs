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
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}