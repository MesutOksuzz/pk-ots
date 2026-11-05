using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Ots.Api.Controllers;

    public class EmployeeAgeAtrreibute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (Employee)validationContext.ObjectInstance;
            if (employee.DateOfBirth == DateTime.MinValue)
            {
                return new ValidationResult("Date of Birth is required");
            }
            var age = DateTime.Today.Year - employee.DateOfBirth.Year;
            if (age < 18 || age > 60)
            {
                return new ValidationResult("Age must be between 18 and 60");
            }

            if (employee.DateOfBirth >= DateTime.Today)
            {
                return new ValidationResult("Date of Birth can not be greater than today");
            }

            if (employee.Age != age)
            {
                return new ValidationResult("Age must be equel to the calculated age");
            }
            return ValidationResult.Success;
        }
    }
    public class Employee
    {
        [Required]
        [StringLength( maximumLength : 10 , MinimumLength = 3 , ErrorMessage = "Name must be between 3 and 10 characters")]
        public string Name {get; set;}
        [Required]
        [StringLength(maximumLength:10 , MinimumLength= 3,ErrorMessage = "Surname must be between 3 and 10 characters")]
        public string Surname {get; set;}
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address. Please enter a valid email adress")]
        public string Email { get; set; }
        [Required]
        [Phone(ErrorMessage = "Invalid Phone number. Please enter a valid phone number")]
        public string Phone { get; set; }
        [Required]
        [StringLength( maximumLength : 10 , MinimumLength = 3 , ErrorMessage = "Name must be between 3 and 10 characters")]
        public string Adress { get; set; }
        
        public int Age { get; set; }
        
        [Required]
        [EmployeeAgeAtrreibute]
        public DateTime DateOfBirth { get; set; }
    }
    
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        [HttpGet("GetAll")]
        public IEnumerable<Employee> Get()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Name = "Mahmut",
                    Surname = "due",
                    Email = "hodl@example.com",
                    Phone = "5454874844",
                    Adress = "123 main 5st"
                },
                new Employee
                {
                    Name = "Mert",
                    Surname = "desire",
                    Email = "hodl@example.com",
                    Phone = "5484996484",
                    Adress = "123 main"
                }
            };
        }

        [HttpGet("GetById/{id}")]
        public Employee Get([FromRoute] int id)
        {
            return new Employee()
            {
                Name = "Mert",
                Surname = "desire",
                Email = "hodl@example.com",
                Phone = "5484996484",
                Adress = "123 main"
                
            };
        }

        [HttpPost]
        public Employee Post([FromBody] Employee employee)
        {
            return employee;
        }

        [HttpPut("{id}")]
        public Employee Put([FromRoute] int id, [FromBody] Employee employee)
        {
            return employee;
        }

        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id)
        {
        }
    }
