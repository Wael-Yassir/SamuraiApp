using System;
using System.Collections.Generic;
using System.Text;

namespace SamuraiApp.Domain
{
    /// <summary>
    /// This class is a joined class to be able to represent many to many 
    /// relationship on the database by enitty framework
    /// </summary>
    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public int BattleId { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
    }
}
