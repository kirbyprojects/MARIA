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
        public int? IntValue { get; private set; }
        public string StringValue { get; private set; }
        public float? FloatValue { get; private set; }
        public double? DoubleValue { get; private set; }
        public decimal? DecimalValue { get; private set; }
        public long? LongIntValue { get; private set; }
        public MARIASqlServerQueryData(object DataValue)
        {
            this.DataType = DataValue.GetType();
            this.DataValue = DataValue;
        }
        public int? GetInt()
        {
            return IntValue;
        }
        public string GetString()
        {
            return StringValue;
        }
        public float? GetFloat()
        {
            return FloatValue;
        }
        public double? GetDouble()
        {
            return DoubleValue;
        }
    }
}
