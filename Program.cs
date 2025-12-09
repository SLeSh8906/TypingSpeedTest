using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json; 

class Program
{
    static string jsonFile = "leaderboard.json";

    static void Main(string[] args)
    {
        string targetText = "The quick brown fox jumps over the lazy dog";
        
        Console.WriteLine("\n--- ТЕСТ ШВИДКОСТІ ДРУКУ ---");
        Console.WriteLine($"Введіть: {targetText}");
        Console.WriteLine("Натисніть ENTER...");
        Console.ReadLine();

        Stopwatch timer = Stopwatch.StartNew();
        Console.Write("> ");
        string userText = Console.ReadLine() ?? "";
        timer.Stop();

        int wpm = CalculateWPM(userText, timer.Elapsed.TotalSeconds);
        
        Console.WriteLine($"\nРезультат: {wpm} WPM | Час: {timer.Elapsed.TotalSeconds:F2}с");

        SaveResult(wpm);
        ShowLeaderboard();
    }

    static int CalculateWPM(string text, double seconds)
    {
        int wordCount = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        double minutes = seconds / 60.0;
        return minutes > 0 ? (int)(wordCount / minutes) : 0;
    }

    static void SaveResult(int wpm)
    {
        List<Score> scores = new List<Score>();

        if (File.Exists(jsonFile))
        {
            string existingJson = File.ReadAllText(jsonFile);
            try {
                scores = JsonSerializer.Deserialize<List<Score>>(existingJson) ?? new List<Score>();
            } catch { /* ігноруємо помилки читання */ }
        }

        scores.Add(new Score { Wpm = wpm, Date = DateTime.Now });

        scores = scores.OrderByDescending(s => s.Wpm).Take(5).ToList();

        string newJson = JsonSerializer.Serialize(scores, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonFile, newJson);
    }

    static void ShowLeaderboard()
    {
        if (!File.Exists(jsonFile)) return;
        Console.WriteLine("\n=== ЛІДЕРБОРД (ТОП 5) ===");
        string json = File.ReadAllText(jsonFile);
        var scores = JsonSerializer.Deserialize<List<Score>>(json);
        
        int i = 1;
        foreach (var s in scores)
        {
            Console.WriteLine($"{i}. {s.Wpm} WPM - {s.Date}");
            i++;
        }
    }
}

class Score
{
    public int Wpm { get; set; }
    public DateTime Date { get; set; }
}