using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Basic Creature identification.
    /// </summary>
    public class CreatureIdentification
    {
        #region Properties
        /// <summary>
        /// ID of the create
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The type of creature <see cref="CreatureTypes"/>
        /// </summary>
        public CreatureTypes CreatureType { get; protected set; }
        /// <summary>
        /// Description in multiple languages
        /// </summary>
        public TextClass Description { get; set; }
        /// <summary>
        /// Latin/Scientific name in multiple languages
        /// </summary>
        public LatinNameClass ScientificName { get; set; }
        /// <summary>
        /// Tradenames in multiple languages
        /// </summary>
        public TextClass Tradenames { get; set; }
        /// <summary>
        /// Version Information 
        /// </summary>
        public decimal CurrentVersion { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Basic constructor
        /// </summary>
        public CreatureIdentification()
        {
            CreatureType = CreatureTypes.Unknwon;
            ScientificName = null;
            CurrentVersion = 0;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Checks if the required properties on the object is filled
        /// </summary>
        /// <returns>True if valid, false otherwise</returns>
        public virtual bool Valid()
        {
            if (CreatureType != CreatureTypes.Unknwon && ScientificName != null)
                return true;
            else
                return false;
        }
        #endregion
    }
}
