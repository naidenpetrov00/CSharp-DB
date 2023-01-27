namespace HospitalDatabase.Data.Models
{
    public class Medicament
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}
