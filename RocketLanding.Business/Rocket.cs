using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLanding.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class Rocket
    {
        /// <summary>
        /// Rocket Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Position X
        /// </summary>
        public Nullable<int> PositionX { get; set; }
        
        /// <summary>
        /// Position Y
        /// </summary>
        public Nullable<int> PositionY { get; set; }
    }
}