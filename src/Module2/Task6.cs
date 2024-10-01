using System;

namespace Module2
{
    internal class Task6
    {
        public static void Execute()
        {
            Car myCar = new("Toyota", "Supra", 1995, 300000);

            myCar.DisplayInfo();

            // Цена со скидкой 10%
            double priceWithDiscount = myCar.GetPriceWithDiscount(10);
            Console.WriteLine($"Цена со скидкой 10%: {priceWithDiscount:C}");

            // Цена с НДС 18%
            double priceWithTax = myCar.GetPriceWithTax(18);
            Console.WriteLine($"Цена с НДС 18%: {priceWithTax:C}");
        }
    }

    public class Car
    {
        public string Make { get; set; }       // Марка автомобиля
        public string Model { get; set; }      // Модель автомобиля
        public int Year { get; set; }          // Год выпуска
        public double Price { get; set; }      // Цена автомобиля

        // Конструктор для инициализации объекта
        public Car(string make, string model, int year, double price)
        {
            Make = make;
            Model = model;
            Year = year;
            Price = price;
        }

        // Метод для расчета стоимости со скидкой
        public double GetPriceWithDiscount(double discountPercentage)
        {
            double discountAmount = Price * (discountPercentage / 100);
            return Price - discountAmount;
        }

        // Метод для расчета стоимости с налогом (НДС)
        public double GetPriceWithTax(double taxPercentage)
        {
            double taxAmount = Price * (taxPercentage / 100);
            return Price + taxAmount;
        }

        // Метод для вывода информации об автомобиле
        public void DisplayInfo()
        {
            Console.WriteLine($"Марка: {Make}, Модель: {Model}, Год выпуска: {Year}, Цена: {Price:C}");
        }
    }
}
