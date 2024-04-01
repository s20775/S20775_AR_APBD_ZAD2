using S20775_AR_APBD_ZAD2.Exceptions;
using S20775_AR_APBD_ZAD2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{
    public class GasContainer : Container, IGasContainer
    {
        private double Pressure { get; }

        double IGasContainer.Pressure => throw new NotImplementedException();

        private double currentWeight = 0;

        public GasContainer(string containerType, double depth, double height, double weight, double ownWeight, double maxCapacity, double pressure)
            : base(containerType, depth, height, weight, ownWeight, maxCapacity)
        {
            Pressure = pressure;
        }

        public void LoadGas(double weight, double pressure)
        {
            if (currentWeight + weight > MaxCapacity)
            {
                throw new OverfillException("Gas weight exceeds container's max gas capacity.");
            }
            else currentWeight += weight;
        }
    }
}
