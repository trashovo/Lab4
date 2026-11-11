using System;

namespace LAB
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Checked check = new Checked();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Задание 1 (Определить количество различных элементов списка)");
                Console.WriteLine(
                    "2. Задание 2 (Если у элемента со значением E соседи не равны, заменить их на элемент F.)");
                Console.WriteLine("3. Задание 3 (Матричное выражение 7*A - (B^T - 3*C))");
                Console.WriteLine("4. Задание 4 (Бинарные файлы: произведения соседних)");
                Console.WriteLine("5. Задание 5 (XML-сериализация: игрушки)");
                Console.WriteLine("6. Задание 6 (Текстовый файл: числа + 1)");
                Console.WriteLine("7. Задание 7 (Текстовый файл: сумма первого и min)");
                Console.WriteLine("8. Задание 8 (Текстовый файл: строки на букву 'б')");
                Console.WriteLine("0. Выход");

                int choice = check.ReadCount("Введите номер задания (от 0 до 8): ", 0, 8);
                if (choice == 0)
                {
                    Console.WriteLine("\nЗавершение работы программы.");
                    break;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                    {
                        List<string> myList = new List<string>();

                        Console.WriteLine("\nВведите элементы списка (пустая строка - завершение ввода)");
                        while (true)
                        {
                            Console.Write($"Элемент {myList.Count + 1}: ");
                            string? line = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(line))
                            {
                                if (myList.Count == 0)
                                {
                                    Console.WriteLine("Список пуст");
                                    continue;
                                }
                                break;
                            }

                            myList.Add(line.Trim());
                        }
                        int uniqueCount = ListTasks.CountDistinct(myList);
                        Console.WriteLine($"\nВведенный список: {string.Join(", ", myList)}");
                        Console.WriteLine($"Количество различных элементов: {uniqueCount}");
                        
                        Console.WriteLine("\nНажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        break;
                    }
                    case 2:
                    {
                        LinkedList<string> myList = new LinkedList<string>();
                        
                        Console.WriteLine("\nВведите элементы списка (пустая строка - завершение ввода)");
                        while (true)
                        {
                            Console.Write($"Элемент {myList.Count + 1}: ");
                            string? line = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(line))
                            {
                                if (myList.Count < 3)
                                {
                                    Console.WriteLine("Введите хотя бы 3 элемента");
                                    continue;
                                }
                                break;
                            }

                            myList.AddLast(line.Trim());
                        }
                        Console.WriteLine($"\nИсходный список: {string.Join(", ", myList)}");

                        Console.Write("\nВведите значение элемента E: ");
                        string E = (Console.ReadLine() ?? "").Trim();

                        Console.Write("Введите заменяющее значение F: ");
                        string F = (Console.ReadLine() ?? "").Trim();
                        
                        ListTasks.ReplaceUnequalNeighbors(myList, E, F);

                        Console.WriteLine($"\nСписок после замены: {string.Join(", ", myList)}");
                        
                        Console.WriteLine("\nНажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        break;
                    }
                    case 3:
                    {
                        List<List<string>> cooperatives = new List<List<string>>();
                        
                        int n = check.ReadCount("Введите количество кооперативов N (минимум 1):", 1, 0);

                        Console.WriteLine("\nВведите культуры для каждого кооператива через пробел:");
                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Кооператив #{i + 1}: ");
                            string input = Console.ReadLine() ?? "";
                            
                            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
                            List<string> coopCrops = new List<string>();
                            foreach (string crop in parts)
                            {
                                string cleanCrop = crop.Trim();
                                if (!coopCrops.Contains(cleanCrop))
                                { 
                                    coopCrops.Add(crop.Trim());   
                                }
                            }
                            cooperatives.Add(coopCrops);
                        }
                        var (inAll, inSome, inOne) = ListTasks.AnalyzeCrops(cooperatives);
                        
                        Console.WriteLine("\n------------------- РЕЗУЛЬТАТЫ -------------------");
                        Console.WriteLine("1. Возделываемые во ВСЕХ кооперативах: " + 
                                          (inAll.Count > 0 ? string.Join(", ", inAll) : "нет"));

                        Console.WriteLine("2. Возделываемые только в НЕКОТОРЫХ кооперативах: " + 
                                          (inSome.Count > 0 ? string.Join(", ", inSome) : "нет"));

                        Console.WriteLine("3. Возделываемые РОВНО В ОДНОМ кооперативе: " + 
                                          (inOne.Count > 0 ? string.Join(", ", inOne) : "нет"));
                        
                        Console.WriteLine("\nНажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("\nВведите текст на русском языке:");
                        
                        string text = Console.ReadLine() ?? "";
                        
                        List<char> commonChars = ListTasks.FindCommonChars(text);
                        
                        if (commonChars.Count > 0)
                        {
                            Console.WriteLine("Символы, присутствующие в каждом слове: " + string.Join(", ", commonChars));
                        }
                        else
                        {
                            Console.WriteLine("Символов, которые есть абсолютно во всех словах, не найдено.");
                        }
                        Console.WriteLine("\nНажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("\nВвод первой суммы:");
                        uint r1 = (uint)check.NewReadInt("Введите рубли (целое положительное число): ");
                        byte k1 = (byte)check.ReadCount("Введите копейки (0-255): ",0, 255);
                        Money m1 = new Money(r1, k1);
                        Console.WriteLine($"Сумма 1: {m1.ToString()}");
                        
                        Console.WriteLine("\nВвод второй суммы:");
                        uint r2 = (uint)check.NewReadInt("Введите рубли (целое положительное число): ");
                        byte k2 = (byte)check.ReadCount("Введите копейки (0-255): ",0, 255);
                        Money m2 = new Money(r2, k2);
                        Console.WriteLine($"Сумма 2: {m2.ToString()}");
                        
                        Console.WriteLine("\nСравнение сумм");
                        bool areEqual = m1.IsEqual(m2);
                        Console.WriteLine($"Сумма 1 = Сумме 2? {areEqual}");

                        Console.WriteLine("\nУнарные операции");
                        
                        Console.WriteLine("Сумма 1");
                        m1++;
                        Console.WriteLine($"Добавили копейку: {m1.ToString()}");
                        try 
                        {
                            m1--;
                            Console.WriteLine($"Вычли копейку: {m1.ToString()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при -- : {ex.Message}");
                        }
                        
                        Console.WriteLine("Сумма 2");
                        m2++;
                        Console.WriteLine($"После ++ (добавили копейку): {m2.ToString()}");
                        try 
                        {
                            m2--;
                            Console.WriteLine($"Вычли копейку: {m2.ToString()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при -- : {ex.Message}");
                        }
                        
                        Console.WriteLine("\nПриведение типов");
                        
                        Console.WriteLine("Сумма 1");
                        uint justRubles = m1;
                        Console.WriteLine($"Неявное приведение: {justRubles}");
                        double justKopeks = (double)m1;
                        Console.WriteLine($"Явное приведение: {justKopeks}");
                        
                        Console.WriteLine("Сумма 2");
                        uint justRubles2 = m2;
                        Console.WriteLine($"Неявное приведение: {justRubles2}");
                        double justKopeks2 = (double)m2;
                        Console.WriteLine($"Явное приведение: {justKopeks2}");
                        
                        Console.WriteLine("\nБинарные операции (вычитание копеек)");
                        int subtractAmount = check.ReadInt("Введите число: ");
                        try
                        {
                            Money res1 = m1 - subtractAmount;
                            Console.WriteLine($"{m1.ToString()} - {subtractAmount} коп. (Money - int) = {res1.ToString()}");

                            Money res2 = subtractAmount - m1;
                            Console.WriteLine($"{subtractAmount} коп. - {m1.ToString()} (int - Money) = {res2.ToString()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при вычитании: {ex.Message}");
                        }
                        
                        try
                        {
                            Money res3 = m2 - subtractAmount;
                            Console.WriteLine($"{m2.ToString()} - {subtractAmount} коп. (Money - int) = {res3.ToString()}");

                            Money res4 = subtractAmount - m2;
                            Console.WriteLine($"{subtractAmount} коп. - {m2.ToString()} (int - Money) = {res4.ToString()}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка при вычитании: {ex.Message}");
                        }
                        
                        Console.WriteLine("\nНажмите любую клавишу для выхода...");
                        Console.ReadKey();
                        break;
                    }
                }   
            }
        }
    }
}
                                