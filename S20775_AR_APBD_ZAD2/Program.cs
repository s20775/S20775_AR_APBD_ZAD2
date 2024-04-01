using System.ComponentModel;

namespace S20775_AR_APBD_ZAD2
{
    class Program
    {
        static List<Ship> ships = new List<Ship>();
        static List<Container> containers = new List<Container>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nLista kontenerowców:\n");
                if (ships.Count == 0)
                    Console.WriteLine("Brak\n");
                else
                {
                    foreach (var ship in ships)
                    {
                        Console.WriteLine($"{ship.Name} (speed={ship.MaxSpeed}, maxContainerNum={ship.MaxContainers}, maxWeight={ship.MaxWeight})");
                    }
                }

                Console.WriteLine("\nLista kontenerów:\n");
                if (containers.Count == 0)
                    Console.WriteLine("Brak\n");
                else
                {
                    foreach (var container in containers)
                    {
                        Console.WriteLine($"{container.SerialNumber} ({container.ContainerType}, depth={container.Depth}, height={container.Height}, weight={container.Weight}, ownWeight={container.OwnWeight})");
                    }
                }

                Console.WriteLine("\nMożliwe akcje:\n");
                Console.WriteLine("1. Dodaj kontenerowiec (Komenda: add_ship)");
                if (ships.Count > 0)
                {
                    Console.WriteLine("2. Usuń kontenerowiec (Komenda: remove_ship)");
                    Console.WriteLine("3. Dodaj kontener (Komenda: add_container)\n");
                }

                if (ships.Count > 0 && containers.Count > 0)
                {
                    Console.WriteLine("Operacje na kontenerach:\n");
                    Console.WriteLine("4. Załaduj kontener: (Komenda: load_cargo)");
                    Console.WriteLine("5. Opróżnij kontener: (Komenda: remove_cargo)");
                    Console.WriteLine("6. Umieść kontener na statku:");
                    Console.WriteLine("7. Zdejmij kontener ze statku:");
                }

                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    Environment.Exit(0);
                else if (input.ToLower() == "add_container")
                {
                    AddContainer();
                }
                else if (input.ToLower() == "add_ship")
                {
                    AddShip();
                }
                else if (input.ToLower() == "remove_ship")
                {
                    RemoveShip();
                }
                else if (input.ToLower() == "load_cargo")
                {
                    Console.WriteLine("\n\n\tLista dostępnych kontenerów:");
                    foreach (var container in containers)
                    {
                        int i = 1;
                        Console.WriteLine("\t" + i + " " + container.SerialNumber);
                        i++;
                    }
                    Console.WriteLine("\nPodaj numer seryjny kontenera, który chcesz załadować:");
                    string serialNumberToLoad = Console.ReadLine();

                    // Znajdź kontener w liście na podstawie numeru seryjnego
                    Container containerToLoad = containers.Find(container => container.SerialNumber == serialNumberToLoad);

                    // Sprawdź czy kontener został znaleziony
                    if (containerToLoad != null)
                    {
                        if (containerToLoad is GasContainer)
                        {
                            double weight;
                            Console.WriteLine("Podaj wagę gazu, jaką chcesz załadować do kontenera: ");
                            string waga = Console.ReadLine();
                            double.TryParse(waga, out weight);
                            double pressure = (weight / 100);
                            GasContainer gasContainer = containerToLoad as GasContainer;
                            gasContainer.LoadGas(weight, pressure);
                        }
                        // Dodaj kontener na statek
                        //selectedShip.AddContainer(containerToLoad);
                        //Console.WriteLine($"Kontener o numerze seryjnym {serialNumberToLoad} został pomyślnie załadowany na statek.");
                    }
                    else
                    {
                        Console.WriteLine("Nie znaleziono kontenera o podanym numerze seryjnym.");
                    }
                }
            }
        }

        static void AddShip()
        {

            try
            {
                Console.WriteLine("\nPodaj nazwę kontenerowca:\n");
                string name = Console.ReadLine();

                Console.WriteLine("\nPodaj prędkość maksymalną kontenerowca:\n");
                int maxSpeed = int.Parse(Console.ReadLine());

                Console.WriteLine("\nPodaj maksymalną liczbę kontenerów, które może przewieźć kontenerowiec:\n");
                int maxContainers = int.Parse(Console.ReadLine());

                Console.WriteLine("\nPodaj maksymalną wagę wszystkich kontenerów, jakie może przewieźć kontenerowiec:\n");
                int maxWeight = int.Parse(Console.ReadLine());


                ships.Add(new Ship(name, maxSpeed, maxContainers, maxWeight));
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Wystąpił wyjątek: {ex.Message}");
            }
        }

        static void RemoveShip()
        {
            if (ships.Count == 0)
            {
                Console.WriteLine("\nBrak kontenerowców do usunięcia.\n");
                return;
            }

            Console.WriteLine("\nWybierz kontenerowiec do usunięcia:\n");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i].Name}");
            }

            int index = int.Parse(Console.ReadLine()) - 1;
            ships.RemoveAt(index);
        }

        static void AddContainer()
        {
            try
            {
                Console.WriteLine("\nPodaj typ kontenera (L - płyn, G - gaz, C - chłodniczy):\n");
                string containerType = Console.ReadLine().ToUpper();

                Console.WriteLine("\nPodaj głębokość kontenera:\n");
                double depth = double.Parse(Console.ReadLine());

                Console.WriteLine("\nPodaj wysokość kontenera:\n");
                double height = double.Parse(Console.ReadLine());

                Console.WriteLine("\nPodaj wagę własną kontenera:\n");
                double ownWeight = double.Parse(Console.ReadLine());

                Console.WriteLine("\nPodaj obecną wagę kontenera:\n");
                double weight = double.Parse(Console.ReadLine() + ownWeight);

                Console.WriteLine("\nPodaj maksymalną pojemność kontenera:\n");
                double maxCapacity = double.Parse(Console.ReadLine());

                containers.Add(new Container(containerType, depth, height, weight, ownWeight, maxCapacity));
                //selectedShip.AddContainer(containers[containers.Count - 1]); // Add the last added container to the selected ship
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił wyjątek: {ex.Message}");
            }
        }
        static void LoadContainerOntoShip()
        {
            if (ships.Count == 0)
            {
                Console.WriteLine("Brak kontenerowców. Najpierw dodaj kontenerowiec.");
                return;
            }

            if (containers.Count == 0)
            {
                Console.WriteLine("Brak dostępnych kontenerów. Najpierw dodaj kontener.");
                return;
            }

            Console.WriteLine("Lista dostępnych kontenerów:");
            for (int i = 0; i < containers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Serial: {containers[i].SerialNumber}, Typ: {containers[i].ContainerType}");
            }

            Console.WriteLine("Wybierz numer kontenera, który chcesz załadować:");
            int containerIndex = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Wybierz numer kontenerowca, na który chcesz załadować kontener:");
            for (int i = 0; i < ships.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ships[i].Name}");
            }

            int shipIndex = int.Parse(Console.ReadLine()) - 1;
            Ship selectedShip = ships[shipIndex];

            try
            {
                selectedShip.AddContainer(containers[containerIndex]);
                Console.WriteLine("Kontener został załadowany na statek.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }
    }
}
