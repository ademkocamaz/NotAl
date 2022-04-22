﻿using NotAl.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.Entities.Concrete
{
    public class Note : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}
