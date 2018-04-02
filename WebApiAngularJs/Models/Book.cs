using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WebApiAngularJs.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }

    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
