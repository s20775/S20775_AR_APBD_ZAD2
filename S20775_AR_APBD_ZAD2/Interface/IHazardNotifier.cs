using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2.Interface
{
    public interface IHazardNotifier
    {
        void NotifyHazard(string containerNumber);
    }
}
