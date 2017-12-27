using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace MARIA
{
    public partial class MARIARandomizer
    {
        private Random Randomizer { get; set; }
        public MARIARandomizer()
        {
            this.Randomizer = new Random();
        }
        public int GetRandomInteger(int Min, int Max)
        {
            return Randomizer.Next(Min, Max);
        }
        public double GetRandomDouble(double Min, double Max)
        {
            return Randomizer.NextDouble() * (Max - Min) + Min;
        }
    }
}
