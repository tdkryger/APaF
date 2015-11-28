using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Abstract class for all types of animals
    /// </summary>
    public abstract class Animal : Creatures
    {
        #region Properties
        /// <summary>
        ///  List of food types eating by animal
        /// </summary>
        public Lists.FoodTypeList FoodTypes { get; protected set; }
        /// <summary>
        /// Decorations need/suggested by animal
        /// </summary>
        public Lists.DecorationList Decorations { get; protected set; }
        /// <summary>
        /// Behaviors of the animal
        /// </summary>
        public Lists.BehaviorList Behavior { get; protected set; }
        /// <summary>
        /// Size of the fish
        /// </summary>
        public DecimalClass Size { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor. Initializes all lists
        /// </summary>
        public Animal()
        {
            FoodTypes = new Lists.FoodTypeList();
            Decorations = new Lists.DecorationList();
            Behavior = new Lists.BehaviorList();

        }
        #endregion
    }
}
