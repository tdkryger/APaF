using System;
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

        #region Constructors
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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is CodeTextClass)
            {
                if ((obj as CodeTextClass).Code == this.Code)
                    return true;
                else
                    return false;
            }
            else
                return base.Equals(obj);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
