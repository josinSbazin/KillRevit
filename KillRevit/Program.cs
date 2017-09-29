using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace KillRevit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var processes = Process.GetProcessesByName("Revit");
                if (processes.Length == 0)
                {
                    Console.WriteLine("Процессов с именем \"Revit\" - не найдено!");
                }
                foreach (var process in processes)
                {
                    try
                    {
                        process.Kill();
                        Console.WriteLine($"{process.ProcessName} ({process.Id}) - was killed!");
                    }
                    catch
                    {
                        Console.WriteLine($"Warning! {process.ProcessName} ({process.Id}) - kill attempt failed!");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Для завершения нажмите любую клавишу");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: \n{ex.Message}", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}