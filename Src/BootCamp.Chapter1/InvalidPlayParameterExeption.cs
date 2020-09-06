using System;
using System.Collections.Generic;
using System.Text;

namespace BootCamp1.Chapter
{
    public class InvalidPlayParameterExeption : Exception
    {
        public InvalidPlayParameterExeption(string reason, Exception innerExeption) : base(reason, innerExeption)
        {
            Console.WriteLine($"{reason}");
        }
    }
}
