using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;


namespace HospitalRecords
{
    public class Patient
    {
        public string patientID;
        public string patientName;
        public string checkInDate;
        public string assignPersonnel;

        public Patient(string patientID, string patientName, string checkInDate, string assignPersonnel)
        {
            this.patientID = patientID;
            this.patientName = patientName;
            this.checkInDate = checkInDate;
            this.assignPersonnel = assignPersonnel;
        }


    }
    public class Records
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();

            var CurrentDirectory = Directory.GetCurrentDirectory();
            string path = CurrentDirectory + @"\ListOfPatients.txt";               
            string[] oneRecord = new string[4];
            Patient pat;
            if (File.Exists(path))
            {
                using (StreamReader file = new StreamReader(path))
                {
                    int counter = 0;
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {
                        oneRecord = ln.Split(",");
                        pat = new Patient(oneRecord[0], oneRecord[1], oneRecord[2], oneRecord[3]);
                        patients.Add(pat);
                        counter++;
                    }                                       
                }
            }
            Console.WriteLine("**Patient records have been recorded successfully**");
            string choice = "";
            while (choice != "e" || choice != "E")
            {
                Console.WriteLine("Press S for search, press E for exit.");
                choice = Console.ReadLine();

                if (choice == "e" || choice == "E")
                {
                    System.Environment.Exit(0);
                }

                if (choice == "s" || choice == "S")
                {
                    Console.WriteLine("Enter patient ID for search:");
                    string search = Console.ReadLine();
                    int match = 0;

                    for (int i = 0; i < patients.Count; i++)
                    {
                        Patient x = patients[i];

                        if (x.patientID == search)
                        {
                            Console.WriteLine("PatientID: " + x.patientID);
                            Console.WriteLine("Name: " + x.patientName);
                            Console.WriteLine("Check in date: " + x.checkInDate);
                            Console.WriteLine("Assigned Medical Personnel: " + x.assignPersonnel);
                            match++;
                            Console.WriteLine("Would you like to remove the patient's record?");
                            Console.WriteLine("Y or N?");
                            string remove = Console.ReadLine();

                            if (remove == "Y" || remove == "y")
                            {
                                foreach (var y in patients)
                                {
                                    if (y.patientID == search)
                                    {
                                        patients.Remove(y);
                                        Console.WriteLine("Record removed successfully.");
                                        break;
                                    }
                                }
                            }

                            else if (remove == "N" || remove == "n")
                            {
                                break;
                            }
                        }  
                    }

                        if (match == 0)
                        {
                            Console.WriteLine("No match found.");
                        }
                }
            }
        }
    }
   
}

