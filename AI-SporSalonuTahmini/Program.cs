using AI_SporSalonuTahmini.DTO;
using Microsoft.ML;
using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        #region Verisetini oku
        // JSON dosyasını okuma
        string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataset.json");
        var jsonData = JsonConvert.DeserializeObject<List<Data>>(File.ReadAllText(jsonFilePath));
        #endregion

        #region Kategorik Verileri sayısal verilere çevir
        var mlContext = new MLContext();

        // Veriyi IDataView'e dönüştürme
        var trainingData = mlContext.Data.LoadFromEnumerable(jsonData);

        // Kategorik verileri sayısal verilere dönüştürme ve özellikleri birleştirme
        var pipeline = mlContext.Transforms.Concatenate("Features", "Age", "MembershipDuration", "WeeklyVisits", "PTUsage", "PreviouslyQuit")  // Özellikleri birleştir
            .Append(mlContext.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "IsContinuing", featureColumnName: "Features"));
        #endregion

        #region Modeli Eğit
        // Modeli eğitme
        var model = pipeline.Fit(trainingData);

        // Yeni verilerle tahmin yapmak için model kullanma
        var prediction = model.Transform(trainingData);
        var predictions = mlContext.Data.CreateEnumerable<PredictionResult>(prediction, reuseRowObject: false).ToList();
        #endregion

        #region Sonuçları yazdır
        // Sonuçları yazdırma
        foreach (var pred in predictions)
        {
            var tt = pred.PredictedLabel.ToString();
            string isContinue = pred.PredictedLabel == true ? "devam edecek." : "devam etmeyecek.";

            Console.WriteLine($"{pred.Name}, {isContinue}");
        }
        int count1 = predictions.Where(c => c.PredictedLabel == true).Count();
        int count2 = predictions.Where(c => c.PredictedLabel == false).Count();
        Console.WriteLine("--------------------------");
        Console.WriteLine($"Spor salonuna toplamda {count1} kişi devame edecek, {count2} kişi ise devam etmeyecek.");
        #endregion

        Console.ReadLine();
    }
}
