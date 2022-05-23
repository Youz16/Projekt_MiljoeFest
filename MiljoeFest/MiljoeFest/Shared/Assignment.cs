namespace MiljoeFest.Server
{
    public class Assignment
    {
        public int assignmentId;
        public int coordinatorId { get; set; }
        public string AssignmentName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }




        public Assignment(int id, int cooId, string assignmentName, DateTime start, DateTime end)
        {
            this.assignmentId = id;
            this.coordinatorId = cooId;
            this.AssignmentName = assignmentName;
            this.Start = start;
            this.End = end;

        }



    }


}
