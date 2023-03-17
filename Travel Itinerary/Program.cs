using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Itinerary
{
    internal class Program
    {
        public static Citys[] GetCities()
        {
            //объявление-добавление  данных городов 
            Citys[] cities = new Citys[] {

                    new Citys  (0, "Берлин", 399, 175, 1.13),
                    new Citys  (1, "Прага", 300, 270),
                    new Citys  (2, "Париж", 350, 220),
                    new Citys  (3, "Рига", 250, 170),
                    new Citys  (4, "Лондон", 390, 270),
                    new Citys (5, "Ватикан", 500, 350),
                    new Citys  (6, "Палермо", 230, 150),
                    new Citys  (7, "Варшава", 300, 190),
                    new Citys  (8, "Кишинев", 215, 110),
                    new Citys  (9, "Мадрид", 260, 190),
                    new Citys  (10, "Будапешт", 269, 230)
                };
            return cities;

        }

        public static Citys[] SelectCity(Citys[] cities, int countSelectedCity)
        {
            Citys[] select = new Citys[countSelectedCity];

            int temp = 0;
            bool isException;


            // в этом цикле происходит ввод городов для посещения-отправки и проверка на правельность введённых индексов
            for (int i = 1; i <= countSelectedCity; i++)
            {
                do
                {
                    Console.Write($"Введите номер {i} города: ");
                    try
                    {
                        temp = Convert.ToInt32(Console.ReadLine());
                        select[i-1] = cities[temp];
                        isException = false;
                    }
                    catch
                    {
                        Console.WriteLine("Введи правильный номер города");
                        isException = true;
                    }
                } while (isException);
            }
            return select;

        }

        static void Main(string[] args)
        {
            Citys[] cities = GetCities();

            Console.Write("Введите кол-во городов(до четырех городов) которые хотите посетить(*в кол-во входит город отправки): ");
            int countSelectedCity = Convert.ToInt32(Console.ReadLine());

            Citys[] arr = new Citys[countSelectedCity];

            Console.Write("Введите бюджет:  ");
            int budget = Convert.ToInt32(Console.ReadLine());

            PrintCity(cities); //Вызов метода, по выводу городов с индексами

            Citys[] selectCity = SelectCity(cities, countSelectedCity);

            double price = 0;


            //Цикл использующий выбранные города и методо CalcPrice для составления итоговой цены
            for (int i = 0; i < selectCity.Length - 1; i++)
            {
                int temp = selectCity.Length;
                if (temp == selectCity.Length)
                {
                    price += CalcPrice(price, cities, selectCity[i], selectCity[i + 1]);
                    if (selectCity[i].id == 3) price *= 1.5;
                }

            }

            Console.WriteLine($"Стоимость поездки: {price} $");
            //Условие, которое проверяет хватает вам денег на заданный маршрут или нет
            if (price > budget)
                Console.WriteLine("На данный маршрут, вашего бюджета не достаточно. В место этого вы можете слетать в сочи или добраться на поезде до замечательной Анапы или в Крым(самолетом на данный момент нельзя Z)");
            else
            { 
                Console.WriteLine("Вашего бюджета достаточно, можете переходить к покупке билета");
                Process.Start("https://www.aviasales.ru/?params=VOG1");//Спонсор данного приложения - АВИАСЕЙЛС.Легкий способ купить дешёвые билеты!
            }
            Console.ReadLine();
        }
        
        static double CalcPrice(double price, Citys[] cities, Citys firstCity, Citys secondCity) //Метод подщитывающий цены, транзит, и налоги 
        {
            price += secondCity.price;

            if (secondCity.id == 0)
            {
                price += cities[0].price * cities[0].tax - cities[0].price;
                price += cities[0].price * 1.04 - cities[0].price;
            }

            if (secondCity.id == 1)
                price += cities[1].price * 1.04 - cities[1].price;

            if (secondCity.id == 2)
                price += cities[2].price * 1.04 - cities[2].price;

            if (secondCity.id == 3)
            {
                price += cities[7].transit;
                if (firstCity.id == 2) price += cities[3].price * 1.09 - cities[3].price;
                price += cities[3].price * 1.04 - cities[3].price;
                if (firstCity.id == 6) price += cities[7].transit + cities[0].transit;
            }

            if (secondCity.id == 4)
                price += cities[2].price;


            if (secondCity.id == 6)
            {
                if (firstCity.id == 4) price += cities[6].price * 1.07 - cities[6].price;
                if (firstCity.id == 8) price += cities[6].price * 1.11 - cities[6].price;
                price += cities[6].price * 1.04 - cities[6].price;
                if (firstCity.id == 3) price += cities[7].transit + cities[0].transit;
            }

            if (secondCity.id == 7)
                price += cities[7].price * 1.04 - cities[7].price;

            if (secondCity.id == 8)
                price += cities[10].transit;

            if (secondCity.id == 9)
            {
                price += cities[2].transit;
                price += cities[9].price * 1.04 - cities[9].price;
            }

            if (secondCity.id == 10)
                price += cities[10].price * 1.04 - cities[10].price;



            return price;
        }


        // вывод городов, с их индексами 
        static void PrintCity(Citys[] cities)
        {
            for (int i = 0; i < cities.Length; i++)
                Console.WriteLine($"{i} - {cities[i].name}");

        }
    }
}
