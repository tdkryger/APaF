using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Scientific / latin name
    /// </summary>
    public class LatinNameClass
    {
        //TODO: Add family and so on?
        #region Properties
        /// <summary>
        /// The Id
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// Genus
        /// </summary>
        public virtual string Genus { get; set; }
        /// <summary>
        /// Species
        /// </summary>
        public virtual string Species { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Overriden ToString
        /// </summary>
        /// <returns>Returns [Genus] [Species]</returns>
        public override string ToString()
        {
            return string.Concat(Genus, " ", Species);
        }
        #endregion
    }
}
