﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCenter
{
    public interface IWork
    {
        void DoSomething(string token,string param);
        void DoMorething(string token, string param);
    }
}
