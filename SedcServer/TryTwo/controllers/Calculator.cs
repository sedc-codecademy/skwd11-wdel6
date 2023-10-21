using Sedc.Server.Interface.Attributes;
using Sedc.Server.Interface.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryTwo.Controllers
{
    internal class Calculator : object, IController
    {
        public Calculator() { }

        [HttpGet]
        public int Add(int first, int second)
        {
            return first + second;
        }

        [HttpGet]
        public int Multiply(int first, int second)
        {
            return first * second;
        }

    }
}
