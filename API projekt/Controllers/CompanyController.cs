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

        [HttpDelete("DeleteAppointment")]
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
        public async Task<IActionResult> AddAppointment(int custId, int compId, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                var addedAppointment = await _company.AddAppointment(custId, compId, StartTime, EndTime);
                return Ok(addedAppointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> GetAppointment(int id, DateTime StartTime, DateTime EndTime)
        {
            try
            {
                var appointments = await _company.Search(id, StartTime, EndTime);
                return Ok(appointments);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("filtered-sorted-appointments")]
        public async Task<IActionResult> GetFilteredSortedAppointments(int companyId, DateTime? startTime, DateTime? endTime, string sortBy, bool sortDescending)
        {
            try
            {
                var result = await _company.GetFilteredSortedAppointments(companyId, startTime, endTime, sortBy, sortDescending);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
            
        }

    }
}
