using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDbMigrations.Models;
[Table("students")]
public class Student : IEntity
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }

    public Student() {
        this.Subjects = new List<StudentSubject>();
    }
    
    public virtual ICollection<StudentSubject> Subjects { get; set; }
}