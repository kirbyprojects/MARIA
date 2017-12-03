using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public class MARIASqlServerQueryData
    {
        private Type DataType { get; set; }
        public object DataValue { get; private set; }
        public MARIASqlServerQueryData(object DataValue)
        {
            this.DataType = DataValue.GetType();
            this.DataValue = DataValue;
        }
    }
}
