using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{
    public class Ship
    {
        private List<Container> containers = new List<Container>();

        public string Name { get; }
        public double MaxSpeed { get; }
        public int MaxContainers { get; }
        public double MaxWeight { get; }

        public Ship(string name, double maxSpeed, int maxContainers, double maxWeight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
        }

        public IReadOnlyList<Container> Containers => containers.AsReadOnly();

        public void AddContainer(Container container)
        {
            if (containers.Count < MaxContainers && GetTotalWeight() + container.Weight <= MaxWeight)
            {
                containers.Add(container);
            }
            else
            {
                throw new InvalidOperationException("Cannot load container. Ship capacity exceeded.");
            }
        }

        public void RemoveContainer(Container container)
        {
            containers.Remove(container);
        }

        private double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in containers)
            {
                totalWeight += container.Weight;
            }
            return totalWeight;
        }

        public void UnloadContainerFromShip(Container container, Ship ship)
        {
            ship.RemoveContainer(container);
        }

        public void ReplaceContainerOnShip(Container oldContainer, Container newContainer, Ship ship)
        {
            ship.RemoveContainer(oldContainer);
            ship.AddContainer(newContainer);
        }

        public void MoveContainerBetweenShips(Container container, Ship sourceShip, Ship destinationShip)
        {
            sourceShip.RemoveContainer(container);
            destinationShip.AddContainer(container);
        }
    }
}
