using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Scientific family
    /// </summary>
    public class FamilyClass : TextClass
    {
        #region Properties
        /// <summary>
        /// Id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Scientific name of the family
        /// </summary>
        public string Family { get; set; }
        /// <summary>
        /// Sub-familys
        /// </summary>
        public FamilyClass SubFamily { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Disposer
        /// </summary>
        public void Dispose()
        {
            if (SubFamily != null)
                SubFamily.Dispose();
            SubFamily = null;
        }

        /// <summary>
        /// overridden ToString
        /// </summary>
        /// <returns>The scientific family name</returns>
        public override string ToString()
        {

            return Family;
        }
        #endregion
    }
}
