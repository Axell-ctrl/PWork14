//***********************************************************************************************************************************************************************************************************
//*Практическая работа №14                                                                                                                                                                                  *
//*Сделал Егоров Н.Н, группа 2-ИСП                                                                                                                                                                          *
//*Задание: Написать структуру, которая описывает Автовокзал и выполняющую: ввод данных, состоящих из n структур; упорядоченный вывод по номерам маршрутов; вывод информации о наибольшем по длине маршруту *
//***********************************************************************************************************************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Практическая_работа__14
{
    internal class Program
    {
        static void HandleError(FormatException fex)//функция с сообщением об исключении FormatException (входная строка имела неправильный формат)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(OverflowException ofex)//функция с сообщением об исключении OverflowException (Значение было недопустимо малым или недопустимо большим для Int32)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Значение было недопустимо малым или недопустимо большим для Int32.
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(Exception ex)//функция с сообщением об исключении Exception (все ошибки в целом)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");//Вывод текста с помощью интерполяции: Что-то пошло не так! Ошибка: Входная строка имела неправильный формат. 
            Console.ForegroundColor = ConsoleColor.White;
        }
        struct Car
        {
            string departurePoint;
            string destinationPoint;
            uint numberOfTrip;
            uint routeLength;
            public Car(string departurePoint, string destinationPoint, uint numberOfTrip, uint routeLength)
            {
                this.departurePoint = departurePoint;
                this.destinationPoint = destinationPoint;
                this.numberOfTrip = numberOfTrip;
                this.routeLength = routeLength;
            }
            void PrintInfoObjStruct()
            {
                InfoAboutObjStruct();
                Console.WriteLine("---Информация о маршрутах Автовокзала---" +
                    $"\nПункт прибытия: {departurePoint}" +
                    $"\nПункт назначения: {destinationPoint}" +
                    $"\nНомер маршрута: {numberOfTrip}" +
                    $"\nДлина маршрута: {routeLength}");
            }
            void InfoAboutObjStruct()
            {
                Console.Write("Введите количество маршрутов для заполнения: ");
                uint countCars = UInt32.Parse(Console.ReadLine());

                Car[] cars = new Car[countCars];
                for (int i = 0; i < countCars; i++) 
                {
                    Console.Write("Введите пункт прибытия: ");
                    string departurePoint = Console.ReadLine();
                    Console.Write("Введите пункт назначения: ");
                    string destinationPoint = Console.ReadLine();
                    Console.Write("Введите номер маршрута: ");
                    uint numberOfTrip = UInt32.Parse(Console.ReadLine());
                    Console.Write("Введите длину маршрута в км: ");
                    uint routeLength = UInt32.Parse(Console.ReadLine());
                    cars[i] = new Car(departurePoint, destinationPoint, numberOfTrip, routeLength);
                }
            }
            public void EventsForCars()
            {
                PrintInfoObjStruct();
                Random rnd = new Random();
                int change = rnd.Next(6);
                int minutesChange = rnd.Next(1, 60);
                switch (change)
                {
                    case 0:
                        string[] delayReasons =
                        {
                            "Неблагоприятные погодные условия", "Технические неполадки", "Работы на дорогах", "Пробки на дорогах"
                        };
                        string reason = delayReasons[rnd.Next(delayReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Внимание! Автобус задержится по причине: {reason}." +
                            $"\nПрибудет позже на: {minutesChange} минут.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 1:
                        string[] speedReasons =
                        {
                            "Благоприятные погодные условия", "Нет пробок на дорогах", "Изменение маршрута на более короткий"
                        };
                        string speedReason = speedReasons[rnd.Next(speedReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Внимание! Автобус ускорился по причине: {speedReason}." +
                            $"\nПрибудет раньше на: {minutesChange} минут.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2:
                        string[] otherReasons =
                        {
                            "Изменение маршрута", "Проверка двигателя", "Смена автобуса"
                        };
                        string otherReason = otherReasons[rnd.Next(otherReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Внимание! Автобус остановился по причине: {otherReason}." +
                            $"\nАвтобус приедет по расписанию.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        int[] otherNumbersOfTrip = { 128, 130, 131, 104, 309, };
                        int otherNumberOfTrip = otherNumbersOfTrip[rnd.Next(otherNumbersOfTrip.Length)];
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Внимание! Автобус сломался по маршруту: " +
                            $"\nВместо него приедет автобус под номером: {otherNumberOfTrip}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    //case 4:
                    //    string[] stopReasons =
                    //    {
                    //        ""
                    //    };
                    //    break;
                    //case 5:
                    //    Console.WriteLine("Не доделано.");
                    //    break;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №14";
            Console.WriteLine("Здравствуйте!");
            bool exitProgram = false;

            while (true)
            {
                try
                {
                    Car car = new Car();
                    car.EventsForCars();
                }
                catch (FormatException fex)//обработка исключения FormatException
                {
                    HandleError(fex);//функция которая вызывает сообщение ошибки FormatException
                }
                catch (OverflowException ofex)//обработка исключения OverflowException
                {
                    HandleError(ofex);//функция которая вызывает сообщение ошибки OverflowException
                }
                catch (Exception ex)
                {
                    HandleError(ex);//функция которая вызывает сообщение ошибки Exception
                }
                while (true)//повторное выполнение цикла с вопросом: Хотите продолжить выполнение? (1-Да/0-Нет).
                {
                    try
                    {
                        Console.Write("Хотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)//если ответ пользователя меньше 0 или больше 1
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");//некорректное число, просит пользователя попробовать ещё раз ввести значение
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;//продолжает итерацию внутреннего цикла
                        }
                        else//иначе
                        {
                            if (answer == 0)//если ответ пользователя равен 0
                            {
                                exitProgram = true;//флаг выхода из программы становится истинным
                                Console.WriteLine("Завершение программы. Нажмите для продолжения...");//выводится сообщение: Завершение программы.
                            }
                            break;
                        }
                    }
                    catch (FormatException fex)//обработка исключения FormatException
                    {
                        HandleError(fex);//функция которая вызывает сообщение ошибки FormatException
                    }
                    catch (OverflowException ofex)//обработка исключения OverflowException
                    {
                        HandleError(ofex);//функция которая вызывает сообщение ошибки OverflowException
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);//функция которая вызывает сообщение ошибки Exception
                    }
                }
                if (exitProgram == true)//если выход из программы является истинным
                    break;//завершается внешний цикл
            }

            Console.ReadKey();
        }
    }
}
