using API_projekt.Services;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_projekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompany _company;
        
        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpPost("UpdateAppointment")]
        public async Task<IActionResult>UpdateAppointment(Appointment upDate)
        {
            try
            {
                var updatedAppointment = await _company.UpdateAppointment(upDate);
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

        [HttpDelete("{DeleteAppointment}")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            try
            {
                var deletedAppointment = await _company.DeleteAppointment(appointmentId);
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

        [HttpPost("AddAppointment")]
        public async Task<IActionResult> AddAppointment(Appointment newAppointment)
        {
            try
            {
                var addedAppointment = await _company.AddAppointment(newAppointment);
                return Ok(addedAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
