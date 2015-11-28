using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{

    /// <summary>
    /// Fish. Inherites from <see cref="Animal"/> animal
    /// </summary>
    public class FishClass : Animal
    {
        #region Properties
        /// <summary>
        /// Swimming position
        /// </summary>
        public CodeTextClass SwimmingPosition { get; set; }
        /// <summary>
        /// Aprox. minimum tank width
        /// </summary>
        public string TankWidth { get; set; }
        /// <summary>
        /// Id from Fishbase.org
        /// </summary>
        public string FishBaseId { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public FishClass() : base()
        {
            CreatureType = CreatureTypes.Fish;
        }
        #endregion

    }
}
