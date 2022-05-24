namespace MiljoeFest.Server
{
    public class Assignment
    {
        public int assignmentId;
        public int CoordinatorId { get; set; }
        public string AssignmentName { get; set; }
        public string Department { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }




        public Assignment(int id, int cooId, string assignmentName, string department, DateTime start, DateTime end)
        {
            this.assignmentId = id;
            this.CoordinatorId = cooId;
            this.AssignmentName = assignmentName;
            this.Department = department;
            this.Start = start;
            this.End = end;

        }



    }


}
