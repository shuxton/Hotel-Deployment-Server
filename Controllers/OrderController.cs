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
        public List<Order> Get()
        {
            OrderApplication order = new OrderApplication(_datacontext);
            List<Order> list = new List<Order>();
            list = order.listOrders();
            return list;
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public dynamic Get(Guid id)
        {
            OrderApplication order = new OrderApplication(_datacontext);
            Order item = order.getOrder(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST api/<OrderController>
        [HttpPost]
        public string Post([FromBody] CreateOrderRequest value)
        {
            Order newOrder = _mapper.Map<Order>(value.OrderDto);

            OrderApplication order = new OrderApplication(_datacontext);
            
            bool status = order.createOrder(value.Ids,newOrder);

            if (status) return "Success";
            else return "Something went wrong";
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public string Put(Guid id,[FromBody] UpdateOrderRequest value)
        {
            OrderApplication order = new OrderApplication(_datacontext);

            bool status = order.updateOrder(id,value.Status,value.Paid);

            if (status) return "Success";
            else return "Something went wrong";
        }
    }
}
