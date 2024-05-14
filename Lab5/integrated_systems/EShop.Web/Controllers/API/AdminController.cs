using EShop.Domain.Domain;
using EShop.Domain.DTO;

using EShop.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Movie_App.Service.Interface;


namespace EShop.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
      

        private readonly IConcertService _concertService;

        public AdminController(IOrderService orderService,  IConcertService concertService)
        {
            _orderService = orderService;
         
            this._concertService = concertService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity id)
        {
            return this._orderService.GetDetailsForOrder(id);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ImportAllConcerts([FromBody] List<ConcertRegistrationDTO> model)
        {
            if (model == null || model.Count == 0)
            {
                return BadRequest("Concert list is empty or null.");
            }

            bool status = true;
            foreach (var concertDto in model)
            {
                try
                {
                    var concertCheck = _concertService.GetConcertByName(concertDto.ConcertName);
                    if (concertCheck == null)
                    {
                        var newConcert = new Concert
                        {
                            ConcertName = concertDto.ConcertName,
                            ConcertDescription = concertDto.ConcertDescription,
                            ConcertImage = concertDto.ConcertImage,
                            Rating = concertDto.Rating,
                            Tickets = new List<Ticket>()
                        };
                        _concertService.CreateNewConcert(newConcert);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while importing concert '{concertDto.ConcertName}': {ex.Message}");
                    status = false;
                }
            }
            return Ok(status);
        }

    }
}
