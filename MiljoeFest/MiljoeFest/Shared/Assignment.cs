namespace MiljoeFest.Shared
{
    public class Assignment
    {
        public int assignmentId;
        public int UserId { get; set; }
        public string AssignmentName { get; set; }
        public string Department { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public Assignment()
        {

        }

        public Assignment(int id, int userId, string assignmentName, string department, DateTime start, DateTime end)
        {
            this.assignmentId = id;
            this.UserId = userId;
            this.AssignmentName = assignmentName;
            this.Department = department;
            this.Start = start;
            this.End = end;
        }



    }


}
