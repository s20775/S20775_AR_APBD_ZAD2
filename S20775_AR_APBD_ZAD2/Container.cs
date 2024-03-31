using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{
    public class Container
    {
        public string SerialNumber { get; private set; }
        public string ContainerType { get; private set; }
        public double Depth { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public double OwnWeight { get; private set; }
        

        public Container(string containerType, double depth, double height, double weight, double ownWeight)
        {
            SerialNumber = SerialNumberGenerator.GenerateSerialNumber(containerType);
            ContainerType = containerType;
            Depth = depth;
            Height = height;
            Weight = weight;
            OwnWeight = ownWeight;
            
        }
    }
}
