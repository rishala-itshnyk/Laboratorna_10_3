using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть ім'я файлу для роботи зі списком студентів:");
        string fileName = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Переглянути список");
            Console.WriteLine("2. Поповнити список");
            Console.WriteLine("3. Вийти");

            int choice = GetMenuChoice();

            switch (choice)
            {
                case 1:
                    View(fileName);
                    break;
                case 2:
                    Add(fileName);
                    break;
                case 3:
                    return;
            }
        }
    }

    static int GetMenuChoice()
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Некоректний ввід. Будь ласка, введіть число від 1 до 3.");
        }
        return choice;
    }
    
    public static void View(string fileName)
    {
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                Console.WriteLine("\nСписок студентів:");

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    public static void Add(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                Console.WriteLine("\nДодавання нового студента:");

                Console.Write("Прізвище: ");
                string lastName = Console.ReadLine();

                Console.Write("Екзамен 1: ");
                int exam1 = int.Parse(Console.ReadLine());

                Console.Write("Екзамен 2: ");
                int exam2 = int.Parse(Console.ReadLine());

                Console.Write("Екзамен 3: ");
                int exam3 = int.Parse(Console.ReadLine());

                writer.WriteLine($"{lastName} {exam1} {exam2} {exam3}");
                Console.WriteLine("Студент доданий до списку.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
