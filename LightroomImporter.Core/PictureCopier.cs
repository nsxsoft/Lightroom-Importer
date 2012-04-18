using System.IO;

namespace LightroomImporter.Core
{
    /// <summary>
    /// This class copies pictures from a source folder to the destination folder.
    /// </summary>
    public class PictureCopier
    {
        private string DestinationFolder { get; set; }

        public PictureCopier(string destinationFolder)
        {
            DestinationFolder = destinationFolder;
        }

        /// <summary>
        /// This method copies the files from the source folder to the destination folder.
        /// </summary>
        /// <param name="sourceFolder"></param>
        /// <returns>The number of files copied.</returns>
        public int Copy(string sourceFolder)
        {
            DirectoryInfo source = new DirectoryInfo(sourceFolder);
            return Copy(source);
        }

        public int Copy(DirectoryInfo directory)
        {
            int count = 0;
            count += CopyFiles(directory.GetFiles());
            foreach (var subDirectory in directory.GetDirectories())
            {
                count += Copy(subDirectory);
            }
            return count;
        }

        private int CopyFiles(FileInfo[] fileInfo)
        {
            int count = 0;
            foreach (var file in fileInfo)
            {
                switch (file.Extension.ToLower())
                {
                    case "jpg":
                    case "jpeg":
                    case "cr2":
                    {
                        CopyToDestination(file);
                        count++;
                    }
                    break;
                }
            }
            return count;
        }

        private void CopyToDestination(FileInfo file)
        {
            file.CopyTo(Path.Combine(DestinationFolder, file.Name));
        }

        
    }
}
