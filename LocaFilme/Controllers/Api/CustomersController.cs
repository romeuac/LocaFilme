using LocaFilme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using LocaFilme.Dtos;
using AutoMapper;

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
        public IEnumerable<CustomerDto> GetCustomer()
        {
            // O Mapper.Map estah sendo utilizado como um delegate e nao sendo executado, O delegate foi possivel pelo uso do System.Linq
            return _context.Customer.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }

        // Pegando somente um customer, o GET de 1 
        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Faz parte da RestFul convention.. se o recurso nao foi encontrado retornar-se um status de not found
            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            // Aqui o Mapper.Map estah sendo executado
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // Retorna-se o recurso criado pois provavelmente o recurso terah ID criado pelo server
        // O atributo Customer estarah no Body e o ASP.NET API Framework irah inicializa-lo
        // POST /api/customers
        // se usarmos a convencao de iniciar o nome do methodo com "Post" nao precisamos colocar o [HttpPost] antes da assinatura do methodo
        [HttpPost]
        // Vou retornar o IHttpActionResult pois poderei controlar melhor os codigos de erro ou acerto para seguir a convencao Restful
        //public CustomerDto PostCustomer (CustomerDto customerDto)
        public IHttpActionResult PostCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                // Eh uma convencao mandar uma msg de erro
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customer.Add(customer);
            _context.SaveChanges();

            // O Id do customer serah criado no DB e deve ser retornado no objeto
            customerDto.Id = customer.Id;

            //return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
            return Created(new Uri(Request.RequestUri + customer.Id.ToString()), customerDto);
            //return customerDto;
        }

        // PUT  /api/customer/1
        [HttpPut]
        public void PutCustomer (int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                // Eh uma convencao mandar uma msg de erro
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customer.SingleOrDefault(c => c.Id == id);

            // Talvez o cliente enviou um ID invalido
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Updating the customer in DB
            Mapper.Map(customerDto, customerInDb);
            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.Birthdate= customerDto.Birthdate;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
            //customerInDb.MembershipTypeId = customerDto.MembershipTypeId;

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
