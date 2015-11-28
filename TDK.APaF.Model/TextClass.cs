using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Abstract class for holding and returning language dependent strings of text
    /// </summary>
    public abstract class TextClass
    {
        #region Properties
        /// <summary>
        /// The danish version of the text
        /// </summary>
        public string Danish { get; set; }
        /// <summary>
        /// the english version of the text
        /// </summary>
        public string English { get; set; }
        /// <summary>
        /// The german version of the text
        /// </summary>
        public string German { get; set; }
        #endregion

        #region public methods
        /// <summary>
        /// Return one of the strings dependig on the default language in settings.
        /// </summary>
        /// <returns>The string. Defaults to english if the relevant string is empty</returns>
        public string ToString(EnumDefaultText defaultLanguage)
        {
            string value = string.Empty;

            switch (defaultLanguage)
            {
                case EnumDefaultText.Danish:
                    value = Danish;
                    break;
                case EnumDefaultText.English:
                    value = English;
                    break;
                case EnumDefaultText.German:
                    value = German;
                    break;
                default:
                    value = English;
                    break;

            }
            if (value == string.Empty)
                return English;
            else
                return value;
        }
        #endregion
    }
}
