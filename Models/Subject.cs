using System.ComponentModel.DataAnnotations.Schema;

namespace DemoDbMigrations.Models;

[Table("subjects")]
public class Subject : IEntity
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }

}