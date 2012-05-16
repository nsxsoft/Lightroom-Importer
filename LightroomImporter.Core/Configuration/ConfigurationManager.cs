
namespace LightroomImporter.Core.Configuration
{
    public class ConfigurationManager
    {
        public static readonly string ImageDestinationPathKeyName = "ImageDestinationPath";
        public static readonly string IsKeepFolderStructureKeyName = "IsKeepFolderStructure";

        public string ImageDestinationPath { get; set; }
        public bool IsKeepFolderStructure { get; set; }

        public ConfigurationManager()
        {
            ImageDestinationPath = System.Configuration.ConfigurationManager.AppSettings[ImageDestinationPathKeyName];
            IsKeepFolderStructure = SetIsKeepFolderStructure();
        }

        private bool SetIsKeepFolderStructure()
        {
            bool result;
            bool.TryParse(System.Configuration.ConfigurationManager.AppSettings[IsKeepFolderStructureKeyName], out result);
            return result;
        }
    }
}
