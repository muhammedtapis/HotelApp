﻿using Hotel.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Core.DTOs
{
    public class RoomWithFloorDTO : RoomDTO
    {
        public Floor Floor { get; set; }
    }
}