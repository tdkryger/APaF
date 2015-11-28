using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.FishbaseImport
{
    class XMLImport
    {

        #region public methods
        public TDK.APaF.Model.FishClass Import(int fishbaseId, string genus, string species, string xmlSummary, string xmlPointData, string xmlCommonNames, string xmlPhotos)
        {
            Model.FishClass theFish = new Model.FishClass();
            theFish.ScientificName = new Model.LatinNameClass() { Genus = genus, Species = species };
            importXMLCommonNames(xmlCommonNames, theFish);
            importXMLPhotos(xmlPhotos, theFish);
            importXMLPointData(xmlPointData, theFish);
            importXMLSummary(xmlSummary, theFish);


            return theFish;
        }
        #endregion

        #region Private methods

        private void importXMLSummary(string summaryXML, TDK.APaF.Model.FishClass item)
        {
            //TODO: importXMLSummary
        }

        private void importXMLPointData(string pointDataXML, TDK.APaF.Model.FishClass item)
        { 
            //TODO: importXMLPointData
        }

        private void importXMLCommonNames(string commonNamesXML, TDK.APaF.Model.FishClass item)
        {
            //TODO: importXMLCommonNames
        }

        private void importXMLPhotos(string photoXML, TDK.APaF.Model.FishClass item)
        {
            //TODO: importXMLPhotos
        }
        #endregion
    }
}
