using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S20775_AR_APBD_ZAD2
{
    public class SerialNumberGenerator
    {
        private static Dictionary<string, int> containerTypeCounts = new Dictionary<string, int>();

        public static string GenerateSerialNumber(string containerType)
        {
            if (!containerTypeCounts.ContainsKey(containerType))
            {
                containerTypeCounts[containerType] = 1;
            }
            else
            {
                containerTypeCounts[containerType]++;
            }

            int count = containerTypeCounts[containerType];
            return $"KON-{containerType}-{count}";
        }
    }
}
