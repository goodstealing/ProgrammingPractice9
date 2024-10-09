using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3.Model.Task1
{
    public delegate double AreaCalculator();

    public abstract class Shape
    {
        public abstract double CalculateArea();
    }
}
