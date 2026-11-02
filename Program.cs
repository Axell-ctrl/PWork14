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

        struct BusStation
        {
            string departurePoint;
            string destinationPoint;
            uint numberOfTrip;
            uint routeLength;

            public BusStation(string departurePoint, string destinationPoint, uint numberOfTrip, uint routeLength)
            {
                this.departurePoint = departurePoint;
                this.destinationPoint = destinationPoint;
                this.numberOfTrip = numberOfTrip;
                this.routeLength = routeLength;
            }

            void PrintInfoObjStruct()
            {
                Console.WriteLine($"\nПункт отправления: {departurePoint}" +
                    $"\nПункт назначения: {destinationPoint}" +
                    $"\nНомер маршрута: {numberOfTrip}" +
                    $"\nДлина маршрута: {routeLength} км");
            }

            public static void ProcessAutovokzal()
            {
                BusStation[] buses = InfoAboutObjStruct();

                SortedObjStruct(buses);

                Console.WriteLine("\n--- Информация о маршрутах Автовокзала (отсортировано по номерам) ---");
                for (int i = 0; i < buses.Length; i++)
                {
                    buses[i].PrintInfoObjStruct();
                }

                InfoAboutLengthOfTrip(buses);

                Random rnd = new Random();

                int randomIndex = rnd.Next(0, buses.Length);

                BusStation randomBus = buses[randomIndex];
                randomBus.EventsForCars();
            }


            static BusStation[] InfoAboutObjStruct()
            {
                Console.Write("Введите количество маршрутов для заполнения: ");
                uint countBuses = UInt32.Parse(Console.ReadLine());

                BusStation[] buses = new BusStation[countBuses];
                for (int i = 0; i < countBuses; i++)
                {
                    Console.WriteLine($"\nЗаполнение маршрута №{i + 1}:");
                    Console.Write("Введите пункт отправления: ");
                    string departurePoint = Console.ReadLine();
                    Console.Write("Введите пункт назначения: ");
                    string destinationPoint = Console.ReadLine();
                    Console.Write("Введите номер маршрута: ");
                    uint numberOfTrip = UInt32.Parse(Console.ReadLine());
                    Console.Write("Введите длину маршрута в км: ");
                    uint routeLength = UInt32.Parse(Console.ReadLine());
                    buses[i] = new BusStation(departurePoint, destinationPoint, numberOfTrip, routeLength);
                }
                return buses;
            }

            static void SortedObjStruct(BusStation[] buses)
            {
                for (int i = 0; i < buses.Length - 1; i++)
                {
                    for (int j = 0; j < buses.Length - i - 1; j++)
                    {
                        if (buses[j].numberOfTrip > buses[j + 1].numberOfTrip)
                        {
                            BusStation temp = buses[j];
                            buses[j] = buses[j + 1];
                            buses[j + 1] = temp;
                        }
                    }
                }
            }

            static void InfoAboutLengthOfTrip(BusStation[] buses)
            {
                uint maxLength = buses[0].routeLength;
                for (int i = 1; i < buses.Length; i++)
                {
                    if (buses[i].routeLength > maxLength)
                    {
                        maxLength = buses[i].routeLength;
                    }
                }

                Console.WriteLine($"\n--- Наибольший по длине маршрут ({maxLength} км) ---");
                for (int i = 0; i < buses.Length; i++)
                {
                    if (buses[i].routeLength == maxLength)
                    {
                        buses[i].PrintInfoObjStruct();
                    }
                }
            }

            void EventsForCars()
            {
                Random rnd = new Random();
                int change = rnd.Next(5);
                int minutesChange = rnd.Next(1, 60);

                string busInfo = $"[Маршрут №{numberOfTrip} ({departurePoint} -> {destinationPoint})]";

                switch (change)
                {
                    case 0:
                        string[] delayReasons =
                        {
                            "Неблагоприятные погодные условия", "Технические неполадки", "Работы на дорогах", "Пробки на дорогах"
                        };
                        string reason = delayReasons[rnd.Next(delayReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} задержится по причине: {reason}." +
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
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} ускорился по причине: {speedReason}." +
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
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} остановился по причине: {otherReason}." +
                            $"\nАвтобус приедет по расписанию.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        int[] otherNumbersOfTrip = { 128, 130, 131, 104, 309 };
                        int otherNumberOfTrip = otherNumbersOfTrip[rnd.Next(otherNumbersOfTrip.Length)];
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} сломался." +
                            $"\nВместо него приедет автобус под номером: {otherNumberOfTrip}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        string[] stopReasons =
                        {
                            "Автобус сломался. Замены нет.", "Аварийная ситуация", "У водителя закончилась смена. Подмены нет."
                        };
                        string stopReason = stopReasons[rnd.Next(stopReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nВнимание! Рейс {busInfo} отменён по причине: {stopReason}" +
                            "\nОжидайте следующий автобус по маршруту.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.Title = "Практическая работа №14";
            Console.WriteLine("Вас приветствует справочная система 'Автоколонны 1378'.");
            bool exitProgram = false;

            while (true)
            {
                try
                {
                    BusStation.ProcessAutovokzal();
                }
                catch (FormatException fex)
                {
                    HandleError(fex);
                }
                catch (OverflowException ofex)
                {
                    HandleError(ofex);
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                }
                while (true)
                {
                    try
                    {
                        Console.Write("\nХотите продолжить выполнение? (1-Да/0-Нет): ");
                        int answer = Int32.Parse(Console.ReadLine());
                        if (answer < 0 || answer > 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы ввели некорректное число. Попробуйте ещё раз.");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                        else
                        {
                            if (answer == 0)
                            {
                                exitProgram = true;
                                Console.WriteLine("Завершение программы. Нажмите для продолжения...");
                            }
                            break;
                        }
                    }
                    catch (FormatException fex)
                    {
                        HandleError(fex);
                    }
                    catch (OverflowException ofex)
                    {
                        HandleError(ofex);
                    }
                    catch (Exception ex)
                    {
                        HandleError(ex);
                    }
                }
                if (exitProgram == true)
                    break;
            }
            Console.ReadKey();
        }
    }
}
