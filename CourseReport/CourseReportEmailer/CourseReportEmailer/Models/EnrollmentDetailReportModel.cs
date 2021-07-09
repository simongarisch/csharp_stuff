
namespace CourseReportEmailer.Models
{
    class EnrollmentDetailReportModel
    {
        public int EnrollmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{EnrollmentId}: {FirstName} {LastName} enrolled in {CourseCode}: {Description}";
        }
    }
}
