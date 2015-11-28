using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// snails and slugs
    /// </summary>
    public class GastropodaClass : Animal
    {
        //TODO: Extras
        #region Properties
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public GastropodaClass() : base()
        {
            CreatureType = CreatureTypes.Gastropoda;
        }
        #endregion

    }
}
