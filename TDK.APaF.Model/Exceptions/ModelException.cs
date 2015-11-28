using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Exceptions
{
    /// <summary>
    /// Basic exception for TDK.APaF.Model
    /// </summary>
    [Serializable]
    public class ModelException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the TDK.APaF.Model.Exceptions.ModelException class.
        /// </summary>
        public ModelException() : base() { }
        /// <summary>
        /// Initializes a new instance of the TDK.APaF.Model.Exceptions.ModelException class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ModelException(string message) : base(message) { }
        /// <summary>
        /// Initializes a new instance of the TDK.APaF.Model.Exceptions.ModelException class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ModelException(string message, Exception innerException) : base(message, innerException) { }
    }
}
