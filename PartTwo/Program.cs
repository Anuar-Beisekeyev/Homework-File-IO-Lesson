using System;
using System.Collections.Generic;
using System.IO;

namespace PartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"G:\Академия step\С#\";
            string[] words;
            List<int> values = new List<int>();

            using (StreamReader stream = new StreamReader(path + "INPUT.txt"))
            {
                string text = stream.ReadLine();
                words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            bool flag = false;
            foreach (var element in words)
            {
                flag = int.TryParse(element, out int number);
                if (flag)
                {
                    values.Add(number);
                }
            }
            int summaValue = values[0] + values[1];
            using (FileStream stream = new FileStream(path + "OUTPUT.txt", FileMode.Create))
            {
                string text = summaValue.ToString();
                byte[] bytes = System.Text.Encoding.Unicode.GetBytes(text);
                stream.Write(bytes, 0, bytes.Length);
            }

        }
    }
}
