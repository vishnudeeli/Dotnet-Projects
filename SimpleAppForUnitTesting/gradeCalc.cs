using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAppForUnitTesting
{
    internal class gradeCalc
    {
        public string gradeCalcate(int percent)
        {
            if (percent > 90) return "A";
            else if (percent > 70) return "B";
            else if (percent > 40) return "C";
            else if (percent > 0) return "D";
            else return "Invalid";
        }
    }
}
