using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// The scientific order 
    /// </summary>
    public class OrderClass : IDisposable
    {

        #region Properties
        /// <summary>
        /// The ID of the order
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of the order
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// List of scientific familys under the order
        /// </summary>
        public FamilyListClass FamilyList { get; protected set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public OrderClass()
        {
            FamilyList = new FamilyListClass();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing">If true, clears the class properties</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                FamilyList.Clear();
                FamilyList = null;
            }
        }
        #endregion
    }
}
