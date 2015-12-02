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

        #region Public methods
        /// <summary>
        /// Checks if the required properties on the object is filled
        /// </summary>
        /// <returns>True if valid, false otherwise</returns>
        public override bool Valid()
        {
            return base.Valid();
        }
        #endregion
    }
}
