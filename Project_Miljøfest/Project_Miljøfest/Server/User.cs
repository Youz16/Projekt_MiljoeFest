namespace Project_Miljøfest.Server
{
    public abstract class User
    {
        // properties
        public int userId;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime DateReg = DateTime.Now;

        //construtor
        public User (int userId, string name, string email, string phone)
        {
            this.userId = userId;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }
    }
}
