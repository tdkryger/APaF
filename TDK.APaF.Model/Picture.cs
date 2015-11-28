using ExifLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using TDK.APaF.Model.Exceptions;

namespace TDK.APaF.Model
{
    /// <summary>
    /// A picture..
    /// Description/Title in inherited strings from TextClass
    /// </summary>
    public class Picture : TextClass
    {


        #region Delegates and events
        /// <summary>
        /// Delegate for Exif events
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">Event arguments</param>
        public delegate void ExifErrorDelegate(object sender, Args.ExifErrorArgs e);
        /// <summary>
        /// Event for Exif errors. Most are ignorable
        /// </summary>
        public event ExifErrorDelegate OnExifError;
        #endregion

        #region Properties
        /// <summary>
        /// the unique identifier
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The picture
        /// </summary>
        public Image PictureData { get; set; } //TODO: change object to something else
        /// <summary>
        /// The copyright Text
        /// </summary>
        public string CopyrightText { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        public Picture()
        {
            this.PictureData = null;
            this.ID = -1;
            this.CopyrightText = string.Empty;
            this.Danish = string.Empty;
            this.English = string.Empty;
            this.German = string.Empty;
        }
        /// <summary>
        /// Constructor. 
        /// Loads the copyright and user comment for english language from EXIF info in picture
        /// </summary>
        /// <param name="fileName"></param>
        /// <exception cref="FileNotFoundException">Throws exception if file not found</exception>
        public Picture(string fileName)
        {
            if (File.Exists(fileName))
            {
                this.ID = -1;
                this.CopyrightText = string.Empty;
                this.Danish = string.Empty;
                this.English = string.Empty;
                this.German = string.Empty;

                try
                {
                    using (ExifReader reader = new ExifReader(fileName))
                    {
                        string outString = string.Empty;

                        if (reader.GetTagValue<string>(ExifTags.Copyright, out outString))
                        {
                            this.CopyrightText = outString;
                        }
                        if (reader.GetTagValue<string>(ExifTags.UserComment, out outString))
                        {
                            this.English = outString;
                        }
                    }
                }
                catch(ExifLibException exExif)
                {
                    if (OnExifError != null)
                        OnExifError(this, new Args.ExifErrorArgs(Args.ExifErrorArgs.ExifErrorTypes.MissingExif, exExif));
                }
                PictureData = Image.FromFile(fileName);
            }
            else
                throw new FileNotFoundException(string.Format("File not found: {0}", fileName), fileName);
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Sets the picture from a array of bytes
        /// </summary>
        /// <param name="dataArray">the raw picture data</param>
        public void SetPictureData(byte[] dataArray)
        {
            MemoryStream ms = new MemoryStream(dataArray);
            PictureData = Image.FromStream(ms);
        }

        /// <summary>
        /// Get the picture data in a byte array
        /// </summary>
        /// <returns>The raw picture data.</returns>
        /// <param name="imgFormat">The picture format to be returned</param>
        /// <exception cref="ModelException">Throws an exception if picture data is null</exception>
        public byte[] GetPictureData(System.Drawing.Imaging.ImageFormat imgFormat)
        {
            if (PictureData == null)
                throw new Exceptions.ModelException("PictureData is null");

            MemoryStream ms = new MemoryStream();
            PictureData.Save(ms, imgFormat);
            return ms.ToArray();
        }
        /// <summary>
        /// Returns a thumbnail of the picture. If the picture already contains an embeded thumbnail, 
        /// that thumbnail is returned scaled to the size
        /// </summary>
        /// <param name="width">the width in pixel</param>
        /// <param name="height">The height in pixel</param>
        /// <returns>The thumbnail</returns>
        /// <exception cref="ModelException">Throws an exception if picture data is null</exception>
        public Image GetThumbnail(int width, int height)
        {
            if (PictureData == null)
                throw new Exceptions.ModelException("PictureData is null");
            return PictureData.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
        }
        #endregion
    }
}
