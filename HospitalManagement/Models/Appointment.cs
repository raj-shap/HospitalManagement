using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
	public class Appointment
	{
		public int AppointmentId { get; set; }
		public string? PatientId { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone {  get; set; }
		public int DepartmentId { get; set; }
		public int DoctorId { get; set; }
		[DataType(DataType.Date)]
		public DateTime AppointmentDate { get; set; }
		public string? PatientMessage { get; set; }
		public string? AppointmentStatus { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
