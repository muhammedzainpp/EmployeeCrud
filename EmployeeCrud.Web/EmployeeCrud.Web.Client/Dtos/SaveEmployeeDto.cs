﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeCrud.Web.Client.Dtos;

public class SaveEmployeeDto
{
    
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string Description { get; set; } = default!;
}
