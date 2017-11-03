using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LocaFilme.Models;

namespace LocaFilme.ViewModels
{
    public class NewCustomerViewModel
    {
        //public List<MembershipType> MembershipTypes { get; set; }
        // Como iremos utilizar as informacoes numa View, nao precisamos das propriedades de Add, Remove... da List
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        // Em um projeto maior seria interessante CRIAR OUTRA ENTIDADE DE CUSTOMER APENAS PARA A VIEW para nao mesclar
        // propriedades da View com as do Domain na mesma entidade
        public Customer Customer { get; set; }
    }
}