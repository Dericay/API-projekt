using API_projekt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdmin _admin;

        public AdminController(IAdmin admin)
        {
            _admin = admin;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _admin.GetAllCustomers());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database......");
            }
        }

        [HttpGet("GetSingel")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            try
            {
                var result = await _admin.GetSingelCustomer(id);
                if(result != null)
                {
                    return Ok(result);
                }
                return NotFound($"Customer with id {id} not found");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database......");
            }
        }

        [HttpGet("CustomersAppointmentCurrenWeek")]
        public async Task<IActionResult> GetCustomersCurrentWeek()
        {
            try
            {
                var customersWithAppointments = await _admin.AllCustomersCurrentWeek();
                return Ok(customersWithAppointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }



        [HttpGet("BookingsForWeek/{customerId}/{year}/{weekNumber}")]
        public async Task<IActionResult> BookingsForWeek(int customerId, int year, int weekNumber)
        {
            try
            {
                var bookings = await _admin.BookingsForWeek(customerId, weekNumber, year);
                var appointmentsList = bookings.ToList();

                return Ok(appointmentsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error getting data from database...");
            }
        }

        [HttpGet("filtered-sorted-customers")]
        public async Task<IActionResult> GetFilteredSortedCustomers(string sortBy, bool sortDescending)
        {
            var result = await _admin.GetFilteredSortedCustomers(sortBy, sortDescending);
            return Ok(result);
        }

        [HttpGet("HistoryRecord")]
        public async Task<IActionResult> GetAllAppointmentAudits()
        {
            var audits = await _admin.GetAllAppointmentAudits();
            return Ok(audits);
        }
    }
}

