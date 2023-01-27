namespace HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Comments { get; set; }

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
