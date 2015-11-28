using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Light min/max levels
    /// </summary>
    public class LightClass
    {
        #region Properties
        /// <summary>
        /// Minimum light level
        /// </summary>
        public virtual EnumLight MinLight { get; set; }
        /// <summary>
        /// Maximum light level
        /// </summary>
        public virtual EnumLight MaxLight { get; set; }
        #endregion

        #region Public methods
        /// <summary>
        /// Overriden ToString
        /// </summary>
        /// <param name="defaultLanguage">The language</param>
        /// <returns>The light levels in the requested language</returns>
        public string ToString(EnumDefaultText defaultLanguage)
        {
            if (MinLight == MaxLight)
                return translateENumToString(MinLight, defaultLanguage);
            else
                return string.Concat(translateENumToString(MinLight, defaultLanguage), " - ", translateENumToString(MaxLight, defaultLanguage));
        }
        #endregion

        #region Private Methods
        private string translateENumToString(EnumLight value, EnumDefaultText defaultLanguage)
        {
            switch (defaultLanguage)
            {
                case EnumDefaultText.Danish:
                    switch (value)
                    {
                        case EnumLight.Low:
                            return "Lavt";
                        case EnumLight.Average:
                            return "Middel";
                        case EnumLight.High:
                            return "Højt";
                    }
                    break;
                case EnumDefaultText.English:
                    switch (value)
                    {
                        case EnumLight.Low:
                            return "Low";
                        case EnumLight.Average:
                            return "Average";
                        case EnumLight.High:
                            return "High";
                    }
                    break;
                case EnumDefaultText.German:
                    switch (value)
                    {
                        case EnumLight.Low:
                            return "Low";
                        case EnumLight.Average:
                            return "Durchschnittlich";
                        case EnumLight.High:
                            return "Hoch";
                    }
                    break;
            }
            return string.Empty;
        }
        #endregion
    }
}
