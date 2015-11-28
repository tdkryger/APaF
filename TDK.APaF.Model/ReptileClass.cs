using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Reptiles
    /// </summary>
    public class ReptileClass : Animal
    {

        #region Properties
        #endregion


        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public ReptileClass() : base()
        {
            CreatureType = CreatureTypes.Reptile;
        }
        #endregion

    }
}
