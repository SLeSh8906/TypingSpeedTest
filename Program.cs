using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        string targetText = "The quick brown fox jumps over the lazy dog";
        
        Console.WriteLine("\n--- ТЕСТ ШВИДКОСТІ ДРУКУ ---");
        Console.WriteLine($"Введіть цей текст: {targetText}");
        Console.WriteLine("\nНатисніть ENTER щоб почати...");
        Console.ReadLine();

        Stopwatch timer = new Stopwatch();
        timer.Start();

        Console.Write("> ");
        string userText = Console.ReadLine() ?? ""; // ?? "" захищає від null

        timer.Stop();
        
        // --- ЗМІНИ ТУТ ---
        int wpm = CalculateWPM(userText, timer.Elapsed.TotalSeconds);
        
        Console.WriteLine($"\nЧас: {timer.Elapsed.TotalSeconds:F2} сек.");
        Console.WriteLine($"Швидкість: {wpm} WPM (слів за хвилину)");
    }

    // Доданий метод
    static int CalculateWPM(string text, double seconds)
    {
        // Розбиваємо текст на слова по пробілах
        int wordCount = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        double minutes = seconds / 60.0;
        
        if (minutes <= 0) return 0;
        return (int)(wordCount / minutes);
    }
}