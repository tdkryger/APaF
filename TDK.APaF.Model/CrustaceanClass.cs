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

    }
}
