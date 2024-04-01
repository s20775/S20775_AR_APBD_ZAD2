using S20775_AR_APBD_ZAD2.Exceptions;
using S20775_AR_APBD_ZAD2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace S20775_AR_APBD_ZAD2
{
    public class RefrigeratedContainer : Container, IRefrigeratedContainer
    {
        public double Temperature { get; }
        public bool IsDangerous => Temperature < 0;

        public RefrigeratedContainer(string containerType, double depth, double height, double weight, double ownWeight, double maxCapacity, double temperature)
            : base(containerType, depth, height, weight, ownWeight, maxCapacity)
        {
            Temperature = temperature;
        }

        public void LoadCargo(double weight, double temperature)
        {
            
            // Implementacja ładowania cargo
        }
    }
}
