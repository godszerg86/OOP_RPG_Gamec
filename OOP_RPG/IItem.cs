﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public interface IItem
    {
        int OriginalValue { get; set; }
        int ResellValue { get; set; }
        string Name { get; set; }
        
    }
}
