using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemAlreadyExists : Exception
    {
        /// <summary>
        /// Initializes a new instance of the TDK.APaF.Database.Exceptions.CreatureAlreadyExists class.
        /// </summary>
        public ItemAlreadyExists() :base() { }

        /// <summary>
        /// Initializes a new instance of the TDK.APaF.Database.Exceptions.CreatureAlreadyExists class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ItemAlreadyExists(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the TDK.APaF.Database.Exceptions.CreatureAlreadyExists class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ItemAlreadyExists(string message, Exception innerException) : base(message, innerException) { }
    
    }
}
