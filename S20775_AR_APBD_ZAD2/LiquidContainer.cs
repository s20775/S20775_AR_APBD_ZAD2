using S20775_AR_APBD_ZAD2.Exceptions;
using S20775_AR_APBD_ZAD2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{

    public class LiquidContainer : Container, ILiquidContainer, IHazardNotifier
    {
        public double MaxLiquidCapacity { get; }

        public void NotifyHazard(string containerNumber)
        {
            Console.WriteLine($"Kontener {containerNumber} zawiera niebiezpieczny ładunek!");
        }

        public LiquidContainer(string containerType, double depth, double height, double weight, double ownWeight, double maxCapacity, double maxLiquidCapacity)
            : base(containerType, depth, height, weight, ownWeight, maxCapacity)
        {
            MaxLiquidCapacity = maxLiquidCapacity;
        }

        public void LoadLiquid(double weight)
        {
            bool isHazardous = CheckIfHazardousCargo();

            if (isHazardous && weight > MaxCapacity * 0.5)
            {
                NotifyHazard(SerialNumber);
                throw new InvalidOperationException("Niebezpieczny ładunek może być załadowany tylko do 50% pojemności kontenera");
            }
            else if (!isHazardous && weight > MaxCapacity * 0.9)
            {
                throw new InvalidOperationException("Zwykły ładunek może być załadowany tylko do 90% pojemności kontenera");
            }
            else
            {
                weight = weight + this.Weight;
            }
            
            // Implementacja ładowania cieczy
        }

        private bool CheckIfHazardousCargo()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);

            if (randomNumber <= 30)
                return false;
            else
                return true;
        }
    }
}
