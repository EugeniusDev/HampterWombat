using HampterWombat.Domain;
using System.Text.Json;

namespace HampterWombat.Common
{
    public static class JsonManipulator
    {
        private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory
            , "hampterWombatData.json");

        public static DovbocoinData TryRetrieveDovbocoinData()
        {
            if (!File.Exists(filePath))
            {
                return new DovbocoinData();
            }

            string jsonString = File.ReadAllText(filePath);
            try
            {
                var nullableData = JsonSerializer.Deserialize<DovbocoinData>(jsonString);
                return nullableData ?? new DovbocoinData();
            }
            catch
            {
                return new DovbocoinData();
            }
        }

        public static void SaveDovbocoinData(DovbocoinData data)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data);
                File.WriteAllText(filePath, jsonString);
            }
            catch
            {
                // Not critical for app work
            }
        }
    }
}
