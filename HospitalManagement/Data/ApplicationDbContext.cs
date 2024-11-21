using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        DbSet<User>users { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
	}
}
