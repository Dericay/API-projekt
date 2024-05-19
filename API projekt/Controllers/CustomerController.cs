using API_projekt.Data;
using API_projekt.Services;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomer _customer;
        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpDelete("DeleteAppointment")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            try
            {
                var deletedAppointment = await _customer.DeleteAppointment(appointmentId);
                if (deletedAppointment != null)
                {
                    return Ok(deletedAppointment);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("UpdateAppointment")]
        public async Task<IActionResult> UpdateAppointment(int id, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                var updatedAppointment = await _customer.UpdateAppointment(id, StartTime, EndTime);
                if (updatedAppointment != null)
                {
                    return Ok(updatedAppointment);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment(int custId, int compId, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                var addedAppointment = await _customer.AddAppointment(custId, compId, StartTime, EndTime);
                return Ok(addedAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
