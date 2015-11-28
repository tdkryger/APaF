using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Plants
    /// </summary>
    public class PlantClass : Creatures
    {
        #region Properties
        /// <summary>
        /// Minimum and maximum Height
        /// </summary>
        public DecimalClass Height { get; set; }
        /// <summary>
        /// Minimum and maximum width
        /// </summary>
        public DecimalClass Width { get; set; }
        /// <summary>
        /// Growth speed
        /// </summary>
        public CodeTextClass GrowthSpeed { get; set; }
        /// <summary>
        /// Bottom type
        /// </summary>
        public BottomTypeClass BottomType { get; set; }
        /// <summary>
        /// Planting zone
        /// TODO: Change to 
        /// </summary>
        public CodeTextClass Zone { get; set; }
        /// <summary>
        /// Flowering month
        /// </summary>
        public int Flowering { get; set; }
        /// <summary>
        /// Suggested water depth
        /// </summary>
        public string WaterDepth { get; set; }
        /// <summary>
        /// Winter hardy
        /// </summary>
        public bool Hardy { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public PlantClass() : base()
        {
            CreatureType = CreatureTypes.Plant;
        }
        #endregion

    }
}
