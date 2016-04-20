using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartKettle.Factory
{
    public class Factory
    {
        public static T CreateInstall<T, F>() where T : F
        {
            T result = System.Activator.CreateInstance<T>();
            return result;
        }
    }
}
