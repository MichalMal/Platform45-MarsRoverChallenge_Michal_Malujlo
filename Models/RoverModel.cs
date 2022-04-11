using Platform45_MarsRoverChallenge_Michal_Malujlo.Enums;
using System;
using System.Collections.Generic;
namespace Platform45_MarsRoverChallenge_Michal_Malujlo.Models
{
    public class RoverModel
    {
        public int ID { get; set; }
        public string RoverName { get; set; }
        public BearingEnum Bearing { get; set; }
        public int Y_Position { get; set; }
        public int X_Position { get; set; }

    }
}
