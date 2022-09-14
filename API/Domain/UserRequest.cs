using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Domain
{
  public class UserRequest
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserRole { get; set; }
    public bool UserActive { get; set; }
  }
}