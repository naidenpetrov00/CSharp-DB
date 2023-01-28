using HospitalDatabase.Data;
using HospitalDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalDatabase
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            using var db = new HospitalDbContext();

            //db.Database.Migrate();

            //Patients
            var patientNaiden = PatientCreater(db, "Naiden", "Petrov", "Samara", true);
            db.SaveChanges();

            //Diagnoses
            var diagnoseForNaiden = DiagnoseCreater(db, "Covid", "Beginner state", patientNaiden.Id);
            db.SaveChanges();

            //Visitations
            var visitationForNaiden = VisitationCreater(db, DateTime.UtcNow, "Feeling Better", patientNaiden.Id);
            db.SaveChanges();

            //Medicines
            var paracetamol = MedicamentOrder(db, "Paracetamol");
            var vitaminC = MedicamentOrder(db, "VitaminC");
            db.SaveChanges();

            //Prescriptions
            var prescriptionForNaiden = WritePrescription(db, patientNaiden.Id, paracetamol.Id);

            db.SaveChanges();
        }

        public static Patient PatientCreater(HospitalDbContext db, string firstName, string lastName, string address, bool hasInsurance)
        {
            var patient = new Patient
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                HasInsurance = hasInsurance
            };

            db.Patients.Add(patient);

            return patient;
        }

        public static Diagnose DiagnoseCreater(HospitalDbContext db, string name, string comment, int patientId)
        {
            var diagnose = new Diagnose
            {
                Name = name,
                Comments = comment,
                PatientId = patientId
            };

            db.Diagnoses.Add(diagnose);

            return diagnose;
        }

        public static Visitation VisitationCreater(HospitalDbContext db, DateTime dateOfVisitation, string comments, int patientId)
        {
            var visitation = new Visitation
            {
                Date = dateOfVisitation,
                Comments = comments,
                PatientId = patientId
            };

            db.Visitations.Add(visitation);

            return visitation;
        }

        public static Medicament MedicamentOrder(HospitalDbContext db, string name)
        {
            var medicament = new Medicament
            {
                Name = name,
            };

            db.Medicaments.Add(medicament);

            return medicament;
        }

        public static PatientMedicament WritePrescription(HospitalDbContext db, int patientId, int medicamentId)
        {
            var prescription = new PatientMedicament
            {
                PatientId = patientId,
                MedicamentId = medicamentId
            };

            db.PatientMedicaments.Add(prescription);

            return prescription;
        }
    }
}