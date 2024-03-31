using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{
    public class Ship
    {
        public List<Container> Containers { get; private set; }
        public double MaxSpeed { get; private set; }
        public int MaxContainers { get; private set; }
        public double MaxWeight { get; private set; }

        public Ship(double maxSpeed, int maxContainers, double maxWeight)
        {
            Containers = new List<Container>();
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
        }

        public void LoadContainer(Container container)
        {
            if (Containers.Count < MaxContainers && GetTotalWeight() + container.Weight <= MaxWeight)
            {
                Containers.Add(container);
            }
            else
            {
                throw new Exception("Cannot load container. Ship capacity exceeded.");
            }
        }

        public void UnloadContainer(Container container)
        {
            Containers.Remove(container);
        }

        private double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in Containers)
            {
                totalWeight += container.Weight;
            }
            return totalWeight;
        }
    }
}
