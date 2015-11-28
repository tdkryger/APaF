﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Multi-language class based on a code
    /// </summary>
    public abstract class CodeTextClass : TextClass
    {
        #region Properties
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the code. this is not unique
        /// </summary>
        public string Code { get; set; }
        #endregion

        #region Constructors1
        /// <summary>
        /// Construcotor
        /// </summary>
        public CodeTextClass()
        {
            Code = string.Empty;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Calls inherited ToString<seealso cref="TextClass"/>
        /// </summary>
        /// <returns>The relevant text, based on default language in Settings</returns>
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion
    }
}