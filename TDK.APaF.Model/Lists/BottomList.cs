using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Lists
{
    /// <summary>
    /// Bottom type list
    /// </summary>
    public class BottomList : List<BottomTypeClass>
    {
        /*
        O=Kies oder Sand / Pebbles or sand 
        S = Stein- und Wurzelhaftig / Grows on stone and root
        */

        #region Static public methods
        /// <summary>
        /// Create a default list of bottom types
        /// </summary>
        /// <returns></returns>
        public static BottomList CreateDefaultList()
        {
            BottomList bl = new BottomList();

            bl.Add(new BottomTypeClass()
            {
                Code = "O",
                English = "Pebbles or sand",
                German = "Kies oder sand",
                Danish = "Grus eller sand"
            });

            bl.Add(new BottomTypeClass()
            {
                Code = "S",
                English = "Grows on stone and root",
                German = "Stein- und Wurzelhaftig",
                Danish = "Gror på sten eller rødder"
            });

            return bl;
        }
        #endregion
    }
}
