using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// crabs, lobsters, crayfish, shrimp, krill and barnacles.
    /// </summary>
    public class CrustaceanClass : Animal
    {
        //TODO: Extras



        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public CrustaceanClass() : base()
        {
            CreatureType = CreatureTypes.Crustacean;
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
