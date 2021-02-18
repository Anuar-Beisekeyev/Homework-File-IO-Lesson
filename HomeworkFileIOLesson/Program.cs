using System;
using System.Collections.Generic;
using System.IO;

namespace HomeworkFileIOLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"G:\Академия step\С#\Числа Фибоначчи.txt";
            string[] words;
            List<int> values = new List<int>();

            using (StreamReader stream = new StreamReader(path))
            {
                string text = stream.ReadLine();
                words = text.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            }
            bool isInt = false;
            foreach (var item in words)
            {                
                isInt = int.TryParse(item, out int number);
                if (isInt)
                {
                    values.Add(number);
                }

            }
            if (IsFibanacci(values))
            {
                int size = values.Count;
                for (int i = size - 1; i < (size * 2) - 1; i++)
                {
                    values.Add(values[i - 1] + values[i]);
                }

                foreach (var item in values)
                {
                    Console.Write(item + "  ");
                }

                using(FileStream stream = new FileStream(path , FileMode.Create))
                {
                    string text = String.Join<int>(" ", values);
                    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
                    stream.Write(bytes, 0, bytes.Length);

                }
            }
            else
            {
                Console.WriteLine("Не является Фибоначчи!");
            }
            Console.ReadLine();

        }

        static bool IsFibanacci(List<int> numbers)
        {
            bool flag = false; 
            for (int i = 0; i < numbers.Count - 2; i++)
            {
                if (numbers[i] + numbers[i + 1] == numbers[i + 2])
                    flag = true;
                else
                    return false;
            }
            return flag;
        }

        
    }
}
