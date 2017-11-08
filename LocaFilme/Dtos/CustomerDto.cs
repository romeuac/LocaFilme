using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LocaFilme.Models;

namespace LocaFilme.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        // foi comentado pois geraria uma excecao no uso da API com o obj de tipo CustomerDto.. existe uma validacao no Min18.. para tipo ser igual a Customer, e nao o CustomerDto..
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}