namespace Project_Miljøfest.Server
{
    public class Shift : Assignment
    {
        public int shiftId;
        public bool IsBooked { get; set; }

        public Shift(int shiftId, string assignmentName, string loc, DateTime start, DateTime end) : base(assignmentName, loc, start, end)
        {
            this.shiftId = shiftId;
            this.IsBooked = false;
        }
    }
}
