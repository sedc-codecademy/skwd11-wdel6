using Sedc.Server.Interface.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryTwo.controllers
{
    internal class Calculator : IController
    {
        public Calculator() { }

        public int Add(int first, int second)
        {
            return first + second;
        }

    }
}
