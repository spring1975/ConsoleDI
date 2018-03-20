using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using EFLogicService.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class WidgetController : Controller
    {
        private WidgetService _widgetService;

        public WidgetController(WidgetService widgetService)
        {
            _widgetService = widgetService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<WidgetDTO> Get()
        {
            return _widgetService.GetWidgets();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
