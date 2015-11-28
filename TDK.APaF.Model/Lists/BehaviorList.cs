using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Lists
{
    /// <summary>
    /// List for <see cref="Behavior"> Behavior</see>. Inherites from <see cref="Lists"/>
    /// </summary>
    public class BehaviorList : List<Behavior>
    {


        #region Static Methods
        /// <summary>
        /// Creates a default list of behaviors
        /// </summary>
        /// <returns>A list of behaviors</returns>
        public static BehaviorList CreateDefaultList()
        {
            BehaviorList bl = new BehaviorList();

            bl.Add(new Behavior()
            {
                Code = "S",
                English="Shoaling"
            });

            bl.Add(new Behavior()
            {
                Code = "E",
                English = "Egglayer"
            });

            bl.Add(new Behavior()
            {
                Code = "L",
                English = "Livebearer"
            });

            bl.Add(new Behavior()
            {
                Code = "MA",
                English = "Mouthbrooder"
            });

            bl.Add(new Behavior()
            {
                Code = "SH",
                English = "Bubblenest builder"
            });

            bl.Add(new Behavior()
            {
                Code = "HOE",
                English = "Cavebrooder"
            });

            bl.Add(new Behavior()
            {
                Code = "O!",
                English = "Eggs need special care"
            });

            bl.Add(new Behavior()
            {
                Code = "PT",
                English = "Keep only as pair of trio"
            });

            bl.Add(new Behavior()
            {
                Code = "G",
                English = "Algea-eater, needs vegetable food"
            });

            bl.Add(new Behavior()
            {
                Code = ",-",
                English = "Easy to maintain"
            });

            bl.Add(new Behavior()
            {
                Code = ",!",
                English = "More difficult / Experience needed"
            });

            bl.Add(new Behavior()
            {
                Code = ",X",
                English = "Extremely difficult"
            });

            bl.Add(new Behavior()
            {
                Code = "§",
                English = "Protected species/Washington/CITES permission required!"
            });
            return bl;
        }

        #endregion
    }
}
