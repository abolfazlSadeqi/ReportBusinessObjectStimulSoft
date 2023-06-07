using System.ComponentModel.DataAnnotations;

namespace Models;

public class EmployeeDto
{


    [Key]
    public int Id { set; get; }
    public string FirstName { set; get; }
    public string LastName { set; get; }
    public string Position { set; get; }


}
