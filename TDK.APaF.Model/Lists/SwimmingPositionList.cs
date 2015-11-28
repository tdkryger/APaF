using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Lists
{
    /// <summary>
    /// List of swimming positions
    /// </summary>
    public class SwimmingPositionList : List<SwimmingPositionClass>
    {



        #region Static public methods
        /// <summary>
        /// Creates a default list of swimming methods
        /// </summary>
        /// <returns></returns>
        public static SwimmingPositionList CreateDefaultList()
        {
            SwimmingPositionList spl = new SwimmingPositionList();
            spl.Add(new SwimmingPositionClass()
            {
                Code = "m",
                English = "Middle water layer",
                German = "Mittiere Wasserschichten",
                Danish = "Midterste vandlag"
            });

            spl.Add(new SwimmingPositionClass()
            {
                Code = "o",
                English = "Surface dweller",
                German = "Oberflächenfisch",
                Danish = "Overflade"
            });

            spl.Add(new SwimmingPositionClass()
            {
                Code = "u",
                English = "Bottom dweller",
                German = "Bodenfisch",
                Danish = "Bundfisk"
            });

            spl.Add(new SwimmingPositionClass()
            {
                Code = "um",
                English = "Bottom dweller/Middle water layer",
                German = "Bodenfisch/Mittiere Wasserschichten",
                Danish = "Bundfisk/Midterste vandlag"
            });

            spl.Add(new SwimmingPositionClass()
            {
                Code = "mo",
                English = "Middle water layer/Surface dweller",
                German = "Mittiere Wasserschichten/Oberflächenfisch",
                Danish = "Midterste vandlag/Overflade"
            });

            spl.Add(new SwimmingPositionClass()
            {
                Code = "a",
                English = "All water layer",
                German = "",
                Danish = "Alle vandlag"
            });

            return spl;
        }

        #endregion
    }
}
