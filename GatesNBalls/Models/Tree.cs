using System;
using System.Collections.Generic;
using System.Text;

namespace GatesNBalls.Models
{
    public class Tree
    {
        public int Depth { get; set; }
        public string[] Gates { get; set; } 
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
