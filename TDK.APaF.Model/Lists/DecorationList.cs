using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Lists
{
    /// <summary>
    /// List of decorations
    /// </summary>
    public class DecorationList : List<Decoration>
    {



        #region Static methods
        /// <summary>
        /// Creates a default list of decorations
        /// </summary>
        /// <returns></returns>
        public static DecorationList CreateDefaultList()
        {
            DecorationList dl = new DecorationList();
            dl.Add(new Decoration()
            {
                Code = "O",
                English = "Just substrate, rocks, maybe tough plants",
                Danish = "Kun bundlag, sten og måske nogle hårdføre planter"
            });

            dl.Add(new Decoration()
            {
                Code = "W",
                English = "Bogwood necessary/advisable",
                Danish = "Rødder nødvendigt/tilrådeligt"
            });

            dl.Add(new Decoration()
            {
                Code = "Z",
                English = "Planted aquarium",
                Danish="Planteakvarie"
            });

            return dl;
        }

        #endregion
    }
}
