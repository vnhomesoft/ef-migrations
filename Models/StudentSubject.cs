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

    [Column("created_date", TypeName = "timestamp")]
    public DateTime CreatedDate { get; set; }

    [Column("last_modified_date", TypeName = "timestamp")]
    public DateTime LastModifiedDate { get; set; }

    public Student? Student { get; set; }
    public Subject? Subject { get; set; }
    
}