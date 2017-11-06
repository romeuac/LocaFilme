using LocaFilme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LocaFilme.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        public IEnumerable<Customer> GetCustomer()
        {
            return _context.Customer.ToList();
        }

        // Pegando somente um customer, o GET de 1 
        // GET /api/customers/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Faz parte da RestFul convention.. se o recurso nao foi encontrado retornar-se um status de not found
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // Retorna-se o recurso criado pois provavelmente o recurso terah ID criado pelo server
        // O atributo Customer estarah no Body e o ASP.NET API Framework irah inicializa-lo
        // POST /api/customers
        // se usarmos a convencao de iniciar o nome do methodo com "Post" nao precisamos colocar o [HttpPost] antes da assinatura do methodo
        [HttpPost]
        public Customer PostCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
                // Eh uma convencao mandar uma msg de erro
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customer.Add(customer);
            _context.SaveChanges();

            // O Id do customer serah criado no DB e retorna-se o objeto
            return customer;
        }

        // PUT  /api/customer/1
        [HttpPut]
        public void PutCustomer (int id, Customer customer)
        {
            if (!ModelState.IsValid)
                // Eh uma convencao mandar uma msg de erro
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Talvez o cliente enviou um ID invalido
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Updating the customer in DB
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate= customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();


            _context.SaveChanges();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Talvez o cliente enviou um ID invalido
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customer.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
