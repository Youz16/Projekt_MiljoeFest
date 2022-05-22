namespace Project_Miljøfest.Server
{
    public class Assignment
    {
        public int assignmentId;
        public int coordinatorId {get;set;}
        public string AssignmentName { get; set; }
        public int NoShifts { get; set; }
        public bool IsFull { get; set; }
        
       

        public Assignment(int id, int cooId, string assignmentName, int shifts)
        {
            this.assignmentId = id;
            this.coordinatorId = cooId;
            this.AssignmentName = assignmentName;
            this.NoShifts = shifts;
            this.IsFull = false;
            
        }

        public Assignment(string assignmentName, string loc, DateTime start, DateTime end)
        {
            this.AssignmentName = assignmentName;
            this.Location = loc;
            this.Start = start;
            this.End = end;

        }

    }

    
}
