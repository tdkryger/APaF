using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// The group of Creatures and plants
    /// </summary>
    public class GroupClass : CodeTextClass
    {
        #region Properties
        /// <summary>
        /// Plant group
        /// </summary>
        public bool Plants { get; set; }
        /// <summary>
        /// Fish group
        /// </summary>
        public bool Fish { get; set; }
        /// <summary>
        /// Crustacean group
        /// </summary>
        public bool Crustacean { get; set; }
        /// <summary>
        /// Gastropoda group
        /// </summary>
        public bool Gastropoda { get; set; }
        #endregion
    }
}
