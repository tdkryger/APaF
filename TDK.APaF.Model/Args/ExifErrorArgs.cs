using ExifLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Args
{
    /// <summary>
    ///  contain event data, and provides a value to use for events that do not include event data.
    /// </summary>
    public class ExifErrorArgs : EventArgs
    {
        #region enums
        /// <summary>
        /// Exif error types
        /// </summary>
        public enum ExifErrorTypes
        {
            /// <summary>
            /// Unknown error
            /// </summary>
            Unknown,
            /// <summary>
            /// Missing Exif data. Not an error 
            /// </summary>
            MissingExif,

        }

        #endregion

        #region Properties
        /// <summary>
        /// Error type <see cref="ExifErrorTypes"/>
        /// </summary>
        public ExifErrorTypes ErrorType { get; protected set; }
        /// <summary>
        /// The exception from the Exif lib
        /// </summary>
        public ExifLibException ExifException { get; protected set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="errorType"></param>
        /// <param name="exifException"></param>
        public  ExifErrorArgs(ExifErrorTypes errorType, ExifLibException exifException)
        {
            this.ErrorType = errorType;
            this.ExifException = exifException;
        }
        #endregion
    }
}
