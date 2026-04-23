using System;
using System.Collections.Generic;

namespace Practice.Domain.Models;

public class Person
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public List<Contact> Contacts { get; set; } = [];
}