﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Domain.Models
{

    public class BikeStation
    {
        public int number { get; set; }
        public string contract_name { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        public int bike_stands { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
        public string status { get; set; }
        public long last_update { get; set; }
    }
    public class BikeStationDTO
    {
        public int BikeStationId { get; set; }
        public string contract_name { get; set; }
        public string name { get; set; }
        public string address { get; set; }
       
        public int bike_stands { get; set; }
        public int available_bike_stands { get; set; }
        public int available_bikes { get; set; }
      
    }
    public class Position
    {
        public float lat { get; set; }
        public float lng { get; set; }
    }

}
