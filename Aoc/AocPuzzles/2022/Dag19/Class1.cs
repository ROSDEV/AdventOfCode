using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AocPuzzles._2022.Dag19;

internal class Class1
{

    /*
     * Geodes
     * geode-cracking robots
     * obsidian-collecting robots
     * clay-collecting robots
     * ore-collecting robots == 1
     * Collect 1 == min
     * blueprints === input
     */

    /* Maxmize opened geodes 24 min
     * Determine blueprint quality  == ID  * opend geodes
     * Sum of al blueprints qualties
     */


    public class BluePrint
    {
        private int Number { get; set; }
        private RobotConfig Ore { get; set; }
        private RobotConfig Clay { get; set; }
        private RobotConfig Obsidian { get; set; }
        private RobotConfig Geode { get; set; }
    }

    public class RobotConfig
    {
        public int Ore { get; set; }
        public int Clay { get; set; }
        public int Obsidian { get; set; }
    }

}
