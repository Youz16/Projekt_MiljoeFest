namespace MiljoeFest.Shared
{
    public class Shift
    {
        public int? ShiftId { get; set; }
        public int? AssignmentId { get; set; }
        public int? UserId { get; set; }
        public string? Location { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? BookedBy { get; set; }
        public bool IsBooked { get; set; }

        public Shift(int shiftId, int assignmentId, int userId, string loc, DateTime start, DateTime end)
        {
            this.ShiftId = shiftId;
            this.AssignmentId = assignmentId;
            this.UserId = userId;
            this.Location = loc;
            this.Start = start;
            this.End = end;
            this.IsBooked = false;
        }

        public Shift() 
        {

        }

    }



}

