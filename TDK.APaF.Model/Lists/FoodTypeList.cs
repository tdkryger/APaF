using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model.Lists
{
    /// <summary>
    /// List of food types
    /// </summary>
    public class FoodTypeList : List<FoodTypeClass>
    {





        #region Statics
        /// <summary>
        /// Create a list with a few default Food types
        /// </summary>
        /// <returns></returns>
        public static FoodTypeList CreateDefaultList()
        {
            FoodTypeList ftl = new FoodTypeList();
            ftl.Add(new FoodTypeClass()
                    {
                        Code = "A",
                        English = "Omnivorous"
                    });
            ftl.Add(new FoodTypeClass()
            {
                Code = "B",
                English = "Live/Frozen food"
            });
            ftl.Add(new FoodTypeClass()
            {
                Code = "R",
                English = "Predator"
            });
            ftl.Add(new FoodTypeClass()
            {
                Code = "G",
                English = "Herbivorous"
            });

            return ftl;
        }
        #endregion
    }
}
