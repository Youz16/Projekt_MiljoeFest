﻿namespace MiljoeFest.Shared
{
    public class User
    {
        // properties
        public int userId;
        public int Role { get; set; }
       
        public string Department { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Skills { get; set; }
        public DateTime BirthDay { get; set; }
        public bool FirstAid { get; set; }


        public DateTime DateReg = DateTime.Now;

        //construtor
        public User(int role, string department, string name, string email, string phone, string skills, DateTime birthDay, bool firstAid)
        {
            this.Role = role;
            this.Department = department;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Skills = skills;
            this.BirthDay = birthDay;
            this.FirstAid = firstAid;
        }
    }
}
