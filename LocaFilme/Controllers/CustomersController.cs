using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LocaFilme.Models;
using LocaFilme.ViewModels;

namespace LocaFilme.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            // Criei uma viewModel apenas para agrupar diferentes informacoes a serem enviadas a view... 
            // Para tanto foi necessario tb criar um novo ViewModel
            return View("CustomerForm", viewModel);
        }

        //Utiliza-se o Post para enviar dados para essa Action, nao o Get, para nao ficar aberto...
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            // Checando se os parametros passados sao validos
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            // New customer
            if (customer.Id == 0)
                _context.Customer.Add(customer);

            // Existing customer - Update
            else
            {
                // A excecao de nao encontrar o customer nao esta sendo tratada
                var customerInDB = _context.Customer.Single(c => c.Id == customer.Id);

                customerInDB.Name = customer.Name  ;
                customerInDB.Birthdate = customer.Birthdate  ;
                customerInDB.MembershipTypeId = customer.MembershipTypeId  ;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter  ;
            }

            // Para persistir as mudanças no DB
            _context.SaveChanges();

            // Entao se redireciona para a Actrion do Controller Customers/Index
            return RedirectToAction("Index", "Customers"); 
        }

        [Route("Customers/Index")]
        public ActionResult Index()
        {
            var customers = _context.Customer.Include(c => c.MembershipType).ToList();
            return View(customers);
        }


        [Route("Customers/Details/{id:regex(\\d{1}):range(1,9)}")]
        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                    return HttpNotFound();

            return View(customer);
            
        }

        public ActionResult Edit (int id)
        {
            // Se o dado customer existe no DB ele sera retornado, caso contrario recebera um null
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Retorna um erro padrao 404 
            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                // Passamos uma lista do Membership Types para o atributo MembershipTypes
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            // Colocando o "New" MVC vai procurar por uma View chamada New, Otherwise procuraria por uma chamada Edit
            return View("CustomerForm", viewModel);

        }

    
    }
}