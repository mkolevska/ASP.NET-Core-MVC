﻿namespace Exercise.Models
{
    public class UpdateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime BirthDay { get; set; }
        public string Department { get; set; }
    }
}
