
namespace LightroomImporter.Core.Configuration
{
    public class ConfigurationManager
    {
        public static readonly string ImageDestinationPathKeyName = "ImageDestinationPath";
        public static readonly string IsKeepFolderStructureKeyName = "IsKeepFolderStructure";
        public static readonly string LightroomProgramLocationKeyName = "LightroomProgramLocation";

        public string ImageDestinationPath { get; set; }
        public bool IsKeepFolderStructure { get; set; }
        public string LightroomProgramLocation { get; set; }

        public ConfigurationManager()
        {
            ImageDestinationPath = System.Configuration.ConfigurationManager.AppSettings[ImageDestinationPathKeyName];
            IsKeepFolderStructure = SetIsKeepFolderStructure();
            LightroomProgramLocation = System.Configuration.ConfigurationManager.AppSettings[LightroomProgramLocationKeyName];
        }

        private bool SetIsKeepFolderStructure()
        {
            bool result;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings[IsKeepFolderStructureKeyName], out result);
            return result;
        }
    }
}
