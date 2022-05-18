namespace Project_Miljøfest.Server
{
    public class Volunteer : User
    {
        public string Skills { get; set; }
        public Volunteer(string skills, int userId, string name, string email, string phone):base(userId, name, email, phone)
        {
            this.Skills = skills;
        }

    }
}
