﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    internal interface IClient
    {
        void SendRequest(string[] args);
    }
}
