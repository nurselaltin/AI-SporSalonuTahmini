using Microsoft.ML.Data;

namespace TitanicSurvivalPrediction.Entity
{
    public class TitanicData
    {
        [LoadColumn(0)]
        public float PassengerId { get; set; } //Yolcu kimlik numarası

        [LoadColumn(1)]
        public float Pclass { get; set; } //Yolcunun bilet sınıfı : Yolcu sosyoekonomik durumu belirler

        [LoadColumn(2)]
        public string Name { get; set; } //Yolcu ismi

        [LoadColumn(3)] 
        public string Sex { get; set; } //Yolcu cinsiyeti :  Hayatta kalmayı etkiler

        [LoadColumn(4)]
        public float Age { get; set; } //Yolcu yaşı :  Genellikle çocuk ve yaşlılar daha yüksek hayatta kalma oranlarına sahiptir

        [LoadColumn(5)]
        public float SibSp { get; set; } //Yolcuyla birlikte seyahat eden kardeş veya eş sayısı

        [LoadColumn(6)]
        public float Parch { get; set; } //Yolcunun biletle seyahat eden ebeveyn veya çocuk sayısı. Bu özellik de benzer şekilde ailenin büyüklüğünü ve potansiyel olarak hayatta kalma şansını etkileyebilir.

        [LoadColumn(7)]
        public string Ticket { get; set; } //Bilet numarası

        [LoadColumn(8)]
        public float Fare { get; set; } //Yolcunun ödediği bilet ücreti. Bu da sosyoekonomik durumu gösterebilir ve hayatta kalma oranlarıyla ilişkili olabilir.

        [LoadColumn(9)]
        public string Cabin { get; set; } //Yolcu kabin numarası

        [LoadColumn(10)]
        public string Embarked { get; set; } //Yolcunun gemiye bindiği liman (C = Cherbourg, Q = Queenstown, S = Southampton). Bu özellik, geminin farklı bölgelerindeki yolcuların hayatta kalma oranlarına dair bilgi verebilir

        [LoadColumn(11)]
        public bool Survived { get; set; } // Bu, hedef değişken (survived: hayatta kalma durumu)
    }

    public class TitanicPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Survived { get; set; }
    }

}

