﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWWisky.inventory.core.serialization
{
    interface ISerializable
    {
        string Serialize();
        void Deserialize(string s);
    }
}
