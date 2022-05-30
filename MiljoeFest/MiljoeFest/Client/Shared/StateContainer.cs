namespace MiljoeFest.Client.Shared
{
    public class StateContainer
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
        public string? Name { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Skills { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool FirstAid { get; set; }
    }
}
