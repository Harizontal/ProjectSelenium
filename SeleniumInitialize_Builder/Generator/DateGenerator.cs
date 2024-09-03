using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumInitialize_Builder.Generator
{
    public class DateGenerator
    {
        public static string GetRandomWord()
        {
            var cyrillicLetters = "абвгдеёжзийклмнопрстуфхцчшщьъыэюя";
            var length = 5;
            return new string(Enumerable.Repeat(cyrillicLetters, length)
                .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }

        public static string GetRandomBirthday(int minAge = 18)
        {
            var minDate = new DateTime(1982, 2, 1);
            var maxDate = DateTime.Today.AddYears(-18);
            return minDate.AddDays(new Random().Next((maxDate - minDate).Days)).ToString("d.MM.yyyy");
        }

        public static string GetRandomPhoneNumber()
        {
            return $"{new Random().Next(900, 999)}-{new Random().Next(100, 999)}-{new Random().Next(10, 99)}-{new Random().Next(10, 99)}";
        }
        public static string GenerateRandomCitizenship()
        {
            var citizenships = new[] { "РФ", "Не РФ" };
            return citizenships[new Random().Next(citizenships.Length)];
        }
        public static string GenerateRandomEmployment()
        {
            var employment = new[] { "Есть", "Нет" };
            return employment[new Random().Next(employment.Length)];
        }
        public static bool RandomBoolean()
        {
            return new Random().Next(2) == 0;
        }
    }
}
