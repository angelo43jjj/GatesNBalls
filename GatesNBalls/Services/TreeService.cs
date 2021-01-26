using GatesNBalls.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    
namespace GatesNBalls.Services
{
    public class TreeService : ITreeService
    {

        public Tree FormTree(string sDepth, string sGates)
        {
            var tree = new Tree();

            int depth;

            if (!int.TryParse(sDepth, out depth))
            {
                tree.Error = true;
                tree.ErrorMessage = "The depth is not a number.";
                return tree;
            }

            string[] gates = sGates.Split(',');

            foreach (var gate in gates)
            {
                if (gate.ToLower() != "l" && gate.ToLower() != "r")
                {
                    tree.Error = true;
                    tree.ErrorMessage = "Gate status value/s not set correctly.";
                    return tree;
                }
            }

            double noGates = Math.Pow(2, depth) - 1;

            if (gates.Length != noGates)
            {
                tree.Error = true;
                tree.ErrorMessage += "Gates do not match depth.";
                return tree;
            }

         

            tree.Depth = depth;
            tree.Gates = gates;

            return tree;
        }

        public int WhichOneEmpty(int depth, string[] gates)
        {
            double numberOfGates = Math.Pow(2, depth) - 1;

            bool[] buckets = new bool[(int)Math.Pow(2, depth)];

            Dictionary<int, string> gateStatus = new Dictionary<int, string>();

            for (int i = 1; i <= numberOfGates; i++)
            {
                gateStatus.Add(i, gates[i - 1]);
            };

            int bottomStart = (int)Math.Pow(2, depth);

            // buckets.Length is one more that number of balls
            for (int i = 1; i < buckets.Length; i++)
            {
                int currentGate = 1;
                for (int gate = 1; gate <= depth; gate++)
                {
                    if (gateStatus[currentGate] == "L")
                    {
                        gateStatus[currentGate] = "R";
                        currentGate = currentGate * 2;
                    }
                    else
                    {
                        gateStatus[currentGate] = "L";
                        currentGate = currentGate * 2 + 1;
                    }
                }
                buckets[currentGate - bottomStart] = true;
            }

            return Array.IndexOf(buckets, false) + 1;

        }

        public int PredictEmpty(int depth, string[] gates)
        {
            //prediction is based on the intitials status where along path to the container all the gates are closed

            double numberOfGates = Math.Pow(2, depth) - 1;

            Dictionary<int, string> gateStatus = new Dictionary<int, string>();

            for (int i = 1; i <= numberOfGates; i++)
            {
                gateStatus.Add(i, gates[i - 1]);
            };

            int bottomStart = (int)Math.Pow(2, depth);


            int currentGate = 1;
            for (int gate = 1; gate <= depth; gate++)
            {
                if (gateStatus[currentGate] == "L")
                {
                    // go to the closed side so we can travel the closed gates path
                    currentGate = currentGate * 2 + 1;
                }
                else
                {
                    currentGate = currentGate * 2;
                }
            }

            return currentGate - bottomStart + 1;
        }
    }
}
