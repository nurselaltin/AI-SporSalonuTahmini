namespace AI_SporSalonuTahmini.DTO
{
    public class Data
    {
        public string Name { get; set; }
        public float Age { get; set; }
        public float MembershipDuration { get; set; }
        public float WeeklyVisits { get; set; }
        public float PTUsage { get; set; }
        public float PreviouslyQuit { get; set; }
        public bool IsContinuing { get; set; }

    }
    // Tahmin sonuçlarını saklayacak sınıf
    public class PredictionResult
    {
        public string Name { get; set; }
        public bool PredictedLabel { get; set; }  // Modelin tahmin ettiği sınıf (Devam eder mi, etmez mi?)
    }
}
