﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    // Part 3: Setting Up a Many-to-Many Relationship
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<CheeseMenu> CheeseMenus { get; set; }
    }
}