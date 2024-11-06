using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaTest.Data;
using PizzaTest.Logik;
using PizzaTest.Models;
using System.Net;


namespace PizzaTest.Controllers

{
    [ApiController]
    [Route("[controller]")]

    public class MainController : ControllerBase
    {
        private LogikOrderPizza _logik;
        public MainController(LogikOrderPizza logik)
        {
            this._logik = logik;
        }
        [HttpPost]
        public  async Task<string> AddOrder(OrderPizza pizza)
        {
         var result = await _logik.Add(pizza);
         return result;
           
        }
        [HttpDelete("ById")]
        public async Task<Response> DeleteOrder(int id)
        {    
            var result = await _logik.DeleteOrderAsunc(id);
            return  result;
                       
        }
        [HttpGet("GetAll")]
        public  IQueryable<OrderPizza> GetAllOrders()
        {
            return _logik.GetOrders();
        }



        //public async Task<IActionResult> GetProductById(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest(new ResponseServer
        //        {
        //            StatusCode = HttpStatusCode.BadRequest,
        //            IsSuccess = false,
        //            ErrorMessages = { "Неверный id" }
        //        });
        //    }
    }
}
