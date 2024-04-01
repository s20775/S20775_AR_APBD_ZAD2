using S20775_AR_APBD_ZAD2.Exceptions;
using S20775_AR_APBD_ZAD2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{
    public class Container : IContainer
    {
        private static int serialNumberCounter = 1;

        public string SerialNumber { get; }
        public string ContainerType { get; }
        public double Depth { get; }
        public double Height { get; }
        public double Weight { get; }
        public double OwnWeight { get; }
        public double MaxCapacity { get; }

        public Container(string containerType, double depth, double height, double weight, double ownWeight, double maxCapacity)
        {
            SerialNumber = $"KON-{containerType}-{serialNumberCounter}";
            ContainerType = containerType;
            Depth = depth;
            Height = height;
            Weight = weight;
            OwnWeight = ownWeight;
            MaxCapacity = maxCapacity;
            serialNumberCounter++;
        }

        public void LoadCargo(double weight)
        {
            if (weight > MaxCapacity)
            {
                throw new OverfillException("Cargo weight exceeds container's max capacity.");
            }
            // Implementacja ładowania cargo
        }

        public void UnloadCargo()
        {
            // Implementacja opróżniania kontenera
        }

        public void LoadCargo()
        {
            throw new NotImplementedException();
        }
    }
}
