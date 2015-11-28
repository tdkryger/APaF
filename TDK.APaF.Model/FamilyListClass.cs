using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// List of Family <see cref="FamilyClass"/>
    /// </summary>
    public class FamilyListClass : List<FamilyClass>
    {
        #region Public Methods
        /// <summary>
        /// Find the family object
        /// </summary>
        /// <param name="familyName">The scientific name of the family</param>
        /// <returns>Family object if found. Null otherwise</returns>
        public FamilyClass Find(string familyName)
        {
            foreach(FamilyClass fc in this)
            {
                FamilyClass fcTemp = recursiveFind(fc, familyName);
                if (fcTemp != null)
                    return fcTemp;
            }
            return null;
        }
        #endregion


        #region Private Methods
        private FamilyClass recursiveFind(FamilyClass fc, string familyName)
        {
            if (fc.Family == familyName)
            {
                return fc;
            }
            else
            {
                if (fc.SubFamily != null)
                {
                    return recursiveFind(fc.SubFamily, familyName);
                }
            }
            return null;
        }
        #endregion
    }
}
