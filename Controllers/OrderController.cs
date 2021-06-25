using AutoMapper;
using Hotel.Application;
using Hotel.DTOs;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DataContext _datacontext;
        public OrderController(DataContext dataContext, IMapper mapper)
        {
            _datacontext = dataContext;
            _mapper = mapper;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public dynamic Get()
        {
            OrderApplication order = new OrderApplication(_datacontext);
            List<Order> list = new List<Order>();
            list = order.listItem();
            if (list == null || list.Count == 0) return NotFound();
            return list;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public string Post([FromBody] Request value)
        {
            OrderApplication order = new OrderApplication(_datacontext);
            
            bool status = order.addItem(value.id);

            if (status) return "Success";
            else return "Something went wrong";
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
