namespace Project_Miljøfest.Server
{
    public class Department
    {
        public int assignmentId;
        public string AssignmentName { get; set; }
        public int NoShifts { get; set; }
        public bool IsFull { get; set; }
        public string? Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public Department(int id, string assignmentName, int shifts, string loc, DateTime start, DateTime end)
        {
            this.assignmentId = id;
            this.AssignmentName = assignmentName;
            this.NoShifts = shifts;
            this.IsFull = false;
            this.Location = loc;
            this.Start = start; 
            this.End = end;
        }

        public Department(string assignmentName, string loc, DateTime start, DateTime end)
        {
            this.AssignmentName = assignmentName;
            this.Location = loc;
            this.Start = start;
            this.End = end;

        }

    }

    
}
