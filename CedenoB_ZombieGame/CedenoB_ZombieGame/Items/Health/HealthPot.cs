﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CedenoB_ZombieGame.Model
{
    [Serializable()]
    public class HealthPack
    {
        public int Price { get; set; }
        public int sellPrice { get; set; }

        public HealthPack()
        {

        }
    }
}
