using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Classification. Contains 1 or more Orders
    /// </summary>
    public class ClassificationClass : IDisposable
    {
        #region Properties
        /// <summary>
        /// Unique id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Name of the classification. In latin or english
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The list of orders in the classification
        /// </summary>
        public List<OrderClass> OrderList { get; protected set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ClassificationClass()
        {
            OrderList = new List<OrderClass>();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Implementation of dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected Metods
        /// <summary>
        /// Clears and nulls OrderList if disposing is true
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                OrderList.Clear();
                OrderList = null;
            }
        }
        #endregion
    }
}
