using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// A list of pictures
    /// </summary>
    public class PictureList : List<Picture>
    {
        //TODO: Do we need anything special?
        #region Properties

        #endregion

        #region Public Methods
        /// <summary>
        /// Fills the list with pictures from the given path
        /// Pictures are any file with the following extensions: jpg, jpeg, png, gif, tiff, bmp
        /// </summary>
        /// <param name="path">The Path To Pictures</param>
        public void CreateFromPath(string path)
        {
            var filters = new string[] { "jpg", "jpeg", "png", "gif", "tiff", "bmp" };
            if (Directory.Exists(path))
            {
                List<string> filesFound = new List<string>();
                foreach (var filter in filters)
                {
                    filesFound.AddRange(Directory.GetFiles(path, string.Format("*.{0}", filter), SearchOption.AllDirectories));
                }
                foreach(string s in filesFound)
                {
                    this.Add(new Picture(s));
                }
            }
        }
        #endregion
    }
}
