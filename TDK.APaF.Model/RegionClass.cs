using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Regions
    /// </summary>
    public class RegionClass : TextClass
    {
        #region Properties
        /// <summary>
        /// Region Id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Sub-regions
        /// </summary>
        public List<RegionClass> SubRegions { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constuctor
        /// </summary>
        public RegionClass()
        {
            SubRegions = new List<RegionClass>();
        }
        #endregion

        #region Public Methods

        #endregion

    }
}
