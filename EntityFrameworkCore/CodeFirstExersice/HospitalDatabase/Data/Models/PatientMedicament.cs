namespace HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        public int MedicamentId { get; set; }

        public Medicament Medication { get; set; }
    }
}
