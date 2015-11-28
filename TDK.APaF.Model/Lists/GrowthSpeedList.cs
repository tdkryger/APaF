using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Lists
{
    /// <summary>
    /// List of growthspeed
    /// </summary>
    public class GrowthSpeedList : List<GrowthSpeedClass>
    {

        #region Public static methods
        /// <summary>
        /// Create a default list of growthspeed
        /// </summary>
        /// <returns></returns>
        public static GrowthSpeedList CreateDefaultList()
        {
            GrowthSpeedList gsl = new GrowthSpeedList();
            gsl.Add(new GrowthSpeedClass()
            {
                Code = "~~~~~",
                English="Very slow",
                German = "Sehr langsam",
                Danish="Meget langsomt"
            });

            gsl.Add(new GrowthSpeedClass()
            {
                Code = "~~~",
                English = "Slow",
                German = "Langsam",
                Danish = "Langsomt"
            });

            gsl.Add(new GrowthSpeedClass()
            {
                Code = "~>~>",
                English = "Moderate",
                German = "Mittel",
                Danish = "Middel"
            });

            gsl.Add(new GrowthSpeedClass()
            {
                Code = ">>",
                English = "Fast",
                German = "Schnell",
                Danish = "Hurtigt"
            });

            gsl.Add(new GrowthSpeedClass()
            {
                Code = ">>>>>",
                English = "Very fast",
                German = "Sehr schnell",
                Danish = "Meget hurtigt"
            });

            return gsl;
        }
        #endregion
    }
}
