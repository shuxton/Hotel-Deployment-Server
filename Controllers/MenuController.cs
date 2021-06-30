using AutoMapper;
using Hotel.DTOs;
using Hotel.Models;
using Hotel.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DataContext _datacontext;
        public MenuController(DataContext dataContext, IMapper mapper)
        {
            _datacontext = dataContext;
            _mapper = mapper;
           
        }

        // GET: api/<MenuController>
        [HttpGet]
        public List<Item> Get()
        {
            //todo clean up seeding
            var count = _datacontext.AdminMaster.Where(t => true).Count();
            System.Diagnostics.Debug.WriteLine(count);
            if (count == 0)
            {

                _datacontext.AdminMaster.Add(new AdminMaster
                {
                    GSTNo = "19GACSE057",
                    RateCGST = 6,
                    RateSGST = 6
                });

                _datacontext.Categories.Add(new Category
                {
                    Name = "Chinese"
                });
                _datacontext.Categories.Add(new Category
                {
                    Name = "North Indian"
                });
                _datacontext.SaveChanges();
            }
            MenuApplication menu = new MenuApplication(_datacontext);
            List<Item> list = new List<Item>();
            list = menu.listItems();
            return list;

        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public dynamic Get(Guid id)
        {
            MenuApplication menu = new MenuApplication(_datacontext);
            Item item = menu.getItem(id);
            if (item == null) return NotFound();
            return item;
        }

        // POST api/<MenuController>
        [HttpPost]
        public string Post([FromBody] ItemDto value)
        {
            Item item =  _mapper.Map<Item>(value);

            MenuApplication menu = new MenuApplication(_datacontext);
            bool status = menu.createItem(item);

            if (status) return "Success";
            else return "Something went wrong";     
        }

        // PUT api/<MenuController>/5
        [HttpPut("{id}")]
        public string Put(Guid id, [FromBody] ItemDto value)
        {
            Item item = _mapper.Map<Item>(value);

            MenuApplication menu = new MenuApplication(_datacontext);
            bool status = menu.updateItem(id,item);

            if (status) return "Success";
            else return "Something went wrong";
        }

        // DELETE api/<MenuController>/5
        [HttpDelete("{id}")]
        public string Delete(Guid id)
        {

            MenuApplication menu = new MenuApplication(_datacontext);
            bool status = menu.deleteItem(id);

            if (status) return "Success";
            else return "Something went wrong";
        }
    }
}
