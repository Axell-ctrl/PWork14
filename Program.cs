//*****************************************************
//*Практическая работа №14                            *
//*Сделал Егоров Н.Н, группа 2-ИСП                    *
//*Задание: Описать структуру с именем "Автовокзал".  *
//*****************************************************
using System;

namespace Практическая_работа__14
{
    internal class Program
    {
        static void HandleError(FormatException fex)//обработка ошибки неверного формата ввода
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {fex.Message} Попробуйте ещё раз.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(OverflowException ofex)//обработка ошибки переполнения допустимого диапазона
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ofex.Message} Попробуйте ещё раз.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void HandleError(Exception ex)//обработка прочих непредвиденных ошибок
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Что-то пошло не так! Ошибка: {ex.Message} Попробуйте ещё раз.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        struct BusStation//структура для хранения данных о маршруте автовокзала
        {
            string departurePoint;
            string destinationPoint;
            uint numberOfTrip;
            uint routeLength;

            public BusStation(string departurePoint, string destinationPoint, uint numberOfTrip, uint routeLength)//конструктор для инициализации полей маршрута
            {
                this.departurePoint = departurePoint;
                this.destinationPoint = destinationPoint;
                this.numberOfTrip = numberOfTrip;
                this.routeLength = routeLength;
            }

            void PrintInfoObjStruct()//вывод информации об одном маршруте
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
                int randomIndex = rnd.Next(0, buses.Length);//выбор случайного маршрута для генерации события
                buses[randomIndex].EventsForCars(rnd);
            }

            static BusStation[] InfoAboutObjStruct()//ввод данных с клавиатуры с проверками и заполнение массива структур
            {
                uint countBuses;
                while (true)//проверка, что количество маршрутов больше нуля
                {
                    try
                    {
                        Console.Write("Введите количество маршрутов для заполнения: ");
                        countBuses = UInt32.Parse(Console.ReadLine());
                        if (countBuses > 0)
                            break;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Количество маршрутов должно быть больше нуля. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.White;
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

                BusStation[] buses = new BusStation[countBuses];
                for (int i = 0; i < countBuses; i++)
                {
                    Console.WriteLine($"\nЗаполнение маршрута №{i + 1}:");

                    string departurePoint;
                    while (true)//проверка пункта отправления на пустую строку
                    {
                        Console.Write("Введите пункт отправления: ");
                        departurePoint = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(departurePoint))
                        {
                            departurePoint = departurePoint.Trim();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пункт отправления не может быть пустым. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    string destinationPoint;
                    while (true)//проверка пункта назначения на пустую строку
                    {
                        Console.Write("Введите пункт назначения: ");
                        destinationPoint = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(destinationPoint))
                        {
                            destinationPoint = destinationPoint.Trim();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пункт назначения не может быть пустым. Попробуйте ещё раз.");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    uint numberOfTrip;
                    while (true)//проверка номера маршрута (должен быть больше нуля)
                    {
                        try
                        {
                            Console.Write("Введите номер маршрута: ");
                            numberOfTrip = UInt32.Parse(Console.ReadLine());
                            if (numberOfTrip > 0)
                                break;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Номер маршрута должен быть больше нуля. Попробуйте ещё раз.");
                            Console.ForegroundColor = ConsoleColor.White;
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

                    uint routeLength;
                    while (true)//проверка длины маршрута (должна быть больше нуля)
                    {
                        try
                        {
                            Console.Write("Введите длину маршрута в км: ");
                            routeLength = UInt32.Parse(Console.ReadLine());
                            if (routeLength > 0)
                                break;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Длина маршрута должна быть больше нуля. Попробуйте ещё раз.");
                            Console.ForegroundColor = ConsoleColor.White;
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

                    buses[i] = new BusStation(departurePoint, destinationPoint, numberOfTrip, routeLength);
                }
                return buses;
            }

            static void SortedObjStruct(BusStation[] buses)//сортировка маршрутов по возрастанию номера методом пузырька
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

            static void InfoAboutLengthOfTrip(BusStation[] buses)//поиск и вывод маршрутов с максимальной длиной
            {
                uint maxLength = buses[0].routeLength;
                for (int i = 1; i < buses.Length; i++)
                {
                    if (buses[i].routeLength > maxLength)
                    {
                        maxLength = buses[i].routeLength;
                    }
                }

                Console.WriteLine($"\n--- Наибольший по длине маршрут (маршруты) ---");
                for (int i = 0; i < buses.Length; i++)
                {
                    if (buses[i].routeLength == maxLength)
                    {
                        buses[i].PrintInfoObjStruct();
                    }
                }
            }

            void EventsForCars(Random rnd)//генерация случайного дорожного события для выбранного автобуса
            {
                int change = rnd.Next(5);
                string busInfo = $"[Маршрут №{numberOfTrip} ({departurePoint} -> {destinationPoint})]";
                switch (change)
                {
                    case 0://задержка рейса
                        string[] delayReasons =
                        {
                            "Неблагоприятные погодные условия", "Технические неполадки", "Работы на дорогах", "Пробки на дорогах"
                        };
                        string reason = delayReasons[rnd.Next(delayReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} задержится по причине: {reason}." +
                        $"\nПрибудет позже, несмотря на расписание.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 1://опережение расписания
                        string[] speedReasons =
                        {
                            "Благоприятные погодные условия", "Нет пробок на дорогах", "Изменение маршрута на более короткий"
                        };
                        string speedReason = speedReasons[rnd.Next(speedReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} ускорился по причине: {speedReason}." +
                        $"\nПриедет раньше, несмотря на расписание.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 2://временная остановка без изменения графика
                        string[] otherReasons =
                        {
                            "Изменение маршрута", "Проверка двигателя", "Смена автобуса"
                        };
                        string otherReason = otherReasons[rnd.Next(otherReasons.Length)];
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} остановился по причине: {otherReason}." +
                        "\nАвтобус приедет по расписанию.");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3://поломка с заменой автобуса
                        int[] otherNumbersOfTrip = { 128, 130, 131, 104, 309 };
                        int otherNumberOfTrip = otherNumbersOfTrip[rnd.Next(otherNumbersOfTrip.Length)];
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"\nВнимание! Автобус {busInfo} сломался." +
                        $"\nВместо него приедет автобус под номером: {otherNumberOfTrip}");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4://полная отмена рейса
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
            Console.WriteLine("Здравствуйте!");
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
                    continue;
                }
                catch (OverflowException ofex)
                {
                    HandleError(ofex);
                    continue;
                }
                catch (Exception ex)
                {
                    HandleError(ex);
                    continue;
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
