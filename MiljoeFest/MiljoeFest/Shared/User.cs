namespace MiljoeFest.Shared
{
    public class User
    {
        // properties
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Skills { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool FirstAid { get; set; }

       


        public DateTime DateReg = DateTime.Now;
        public User()
        {

        }
        //construtor
        public User(int userId, int role, string department, string name, string email, string phone, string skills, DateTime birthDay, bool firstAid)
        {
            this.UserId = userId;
            this.RoleId = role;
            this.Department = department;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Skills = skills;
            this.BirthDay = birthDay;
            this.FirstAid = firstAid;
        }

        public User(int role, string department, string name, string email, string phone, string skills, DateTime birthDay, bool firstAid)
        {
            
            this.RoleId = role;
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
