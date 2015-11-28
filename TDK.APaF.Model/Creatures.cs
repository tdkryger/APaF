using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model
{
    //TODO: Handle multiple previous versions. 
    //Think it should be done in DB with triggers. Otherwise see https://en.wikipedia.org/wiki/Memento_pattern and http://dofactory.com/net/memento-design-pattern

    /// <summary>
    /// Abstract class for all types of creatures and plants
    /// </summary>
    public abstract class Creatures : CreatureIdentification
    {
        #region Properties
        /// <summary>
        /// Source of the data <see cref="EnumDataSource"/>
        /// </summary>
        public EnumDataSource DataSource { get; set; }
        /// <summary>
        /// Light requirements. 
        /// </summary>
        public LightClass Light { get; set; }
        /// <summary>
        /// Required temperature range
        /// </summary>
        public DecimalClass Temperature { get; set; }
        /// <summary>
        /// Region
        /// </summary>
        public RegionClass Region { get; set; }
        /// <summary>
        /// List of synonyms <see cref="LatinNameClass"/>
        /// </summary>
        public List<LatinNameClass> Synonyms { get; set; }
        /// <summary>
        /// AquaLog code. Empty if not present
        /// </summary>
        public string AquaLogCode { get; set; }
        /// <summary>
        /// Required pH range
        /// </summary>
        public DecimalClass PH { get; set; }
        /// <summary>
        /// Latin/scientific family name and names in multiple languages 
        /// </summary>
        public FamilyClass Family { get; set; }
        /// <summary>
        /// List of pictures <see cref="Picture"/>
        /// </summary>
        public PictureList Pictures { get; protected set; }
        /// <summary>
        /// Required water hardness. Null if not required/relevant
        /// </summary>
        public DecimalClass Hardness { get; set; }
        /// <summary>
        /// Creation date of original version
        /// </summary>
        public DateTimeInfoClass Created { get; set; }
        /// <summary>
        /// TODO: What is the meaning of this?
        /// </summary>
        public GroupClass Group { get; set; }
        /// <summary>
        /// List of other literature <seealso cref="Creatures.ReferenceBooks"/>
        /// </summary>
        public Lists.BookList OtherLiterature { get; set; }
        /// <summary>
        /// Protection level in multiple languages 
        /// </summary>
        public ProtectionLevel Protected { get; set; }
        /// <summary>
        /// List of reference books
        /// </summary>
        public Lists.BookList ReferenceBooks { get; set; }
        /// <summary>
        /// Required Water type <see cref="EnumWaterTypes"/>
        /// </summary>
        public EnumWaterTypes WaterType { get; set; }

        #endregion



        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public Creatures()
        {
            AquaLogCode = string.Empty;
            DataSource = EnumDataSource.Unknown;
            Pictures = new PictureList();
            CreatureType = CreatureTypes.Unknwon;
            OtherLiterature = new Lists.BookList();
            ReferenceBooks = new Lists.BookList();
        }
        #endregion

        #region Public methods

        #endregion
    }
}
