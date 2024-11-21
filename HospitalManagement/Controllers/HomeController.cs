using HospitalManagement.Data;
using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HospitalManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		private readonly ApplicationDbContext _context;
		public HomeController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> AddAppointment(Appointment appointment)
		{
			appointment.CreatedOn = DateTime.Now;
			appointment.AppointmentStatus = "Pending";
			await _context.Appointments.AddAsync(appointment);
			await _context.SaveChangesAsync();

			//string sanitizedName = appointment.Name.Trim().Replace(" ", "").ToUpper();
			//appointment.PatientId = $"{sanitizedName}-{appointment.AppointmentId:D4}";
			appointment.PatientId = GeneratePatientId(appointment.Name, appointment.AppointmentId);
			_context.Appointments.Update(appointment);
			await _context.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		private string GeneratePatientId(string name, int id)
		{
			// Validate input
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Name cannot be null or empty.", nameof(name));

			if (id < 0)
				throw new ArgumentOutOfRangeException(nameof(id), "ID must be a non-negative number.");

			// Remove spaces, trim, convert to uppercase, and combine with ID
			string sanitizedName = name.Trim().Replace(" ", "").ToUpper();
			return $"{sanitizedName}-{id:D4}"; // Example: "JOHNDOE-0001"
		}
		public IActionResult FourZeroFour()
		{
			return View();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
