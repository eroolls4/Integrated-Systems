using EShop.Domain.Domain;
using EShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return _orderService.GetAllOrders();
        }

        [HttpGet("[action]")]
        public String test()
        {
            return "Hello from TESTTTTTTTT";
        }





        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return _orderService.GetDetailsForOrder(id);
        }



    }
}
