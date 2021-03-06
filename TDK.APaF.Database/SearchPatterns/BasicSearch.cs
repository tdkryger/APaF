﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.SearchPatterns
{
    /// <summary>
    /// Basic search class
    /// </summary>
    public class BasicSearch
    {
        #region Properties
        /// <summary>
        /// Latin Name
        /// </summary>
        int DatabaseId { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Basic constructor.
        /// Initialize DatabaseId to int.MinValue
        /// </summary>
        public BasicSearch()
        {
            DatabaseId = int.MinValue;
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Returns a string of fields and values for searching
        /// </summary>
        /// <returns>String for where part of sql</returns>
        public virtual string GetWhereClause()
        {
            return string.Format("WHERE id={0};", DatabaseId);
        }
        #endregion

    }
}
