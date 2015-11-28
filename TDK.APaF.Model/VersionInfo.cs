using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Version information
    /// </summary>
    public class VersionInfo : DateTimeInfoClass
    {
        #region Properties
        /// <summary>
        /// The version number
        /// </summary>
        public decimal Version { get; protected set; }
        /// <summary>
        /// The CreatureIdentification <see cref="CreatureIdentification"/>
        /// </summary>
        public CreatureIdentification CreatureIdentification { get; protected set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="versionNumber">The version number</param>
        /// <param name="creatureIdentification">the CreatureIdentification</param>
        public VersionInfo(decimal versionNumber, CreatureIdentification creatureIdentification) : base()
        {
            Version = versionNumber;
            CreatureIdentification = creatureIdentification;
        }
        #endregion
    }
}
