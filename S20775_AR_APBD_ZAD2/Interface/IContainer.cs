using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2.Interface
{
    public interface IContainer
    {
        string SerialNumber { get; }
        string ContainerType { get; }
        double Depth { get; }
        double Height { get; }
        double Weight { get; }
        double OwnWeight { get; }
        double MaxCapacity { get; }

        void LoadCargo();
        void UnloadCargo();
    }
}
