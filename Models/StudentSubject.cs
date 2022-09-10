using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDbMigrations.Models;

[Table("student_subjects")]
public class StudentSubject {
    [Column("student_id")]
    [ForeignKey("Student")]
    public Guid StudentId { get; set; }

    [Column("subject_id")]
    [ForeignKey("Subject")]
    public Guid SubjectId { get; set; }
    
    [Column("mark")]
    public float Mark { get; set; }

    public Student? Student { get; set; }
    public Subject? Subject { get; set; }
    
}