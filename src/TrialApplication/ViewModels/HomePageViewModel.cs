﻿using TrialApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrialApplication.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set;  }
        public IEnumerable<Restaurant> Restaurants { get; set; }

    }
}
