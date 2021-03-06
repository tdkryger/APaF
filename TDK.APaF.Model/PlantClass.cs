﻿using System;
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
        public GrowthSpeedClass GrowthSpeed { get; set; }
        /// <summary>
        /// Bottom type
        /// </summary>
        public BottomTypeClass BottomType { get; set; }
        /// <summary>
        /// Planting zone
        /// TODO: Change to 
        /// </summary>
        public PlantZone Zone { get; set; }
        /// <summary>
        /// Flowering month
        /// </summary>
        public string Flowering { get; set; }
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

        #region Public methods
        /// <summary>
        /// Checks if the required properties on the object is filled
        /// </summary>
        /// <returns>True if valid, false otherwise</returns>
        public override bool Valid()
        {
            throw new NotImplementedException();
            //TODO: Implement PlantClass.Valid()
        }
        #endregion

    }
}
