using System;
using System.Diagnostics;

namespace Tibia
{
    public partial class Version
    {
        public static ushort CurrentVersion = 1009;
        public static string CurrentVersionString = "10.99";

        public static string VersionToString(ushort version)
        {
            int main = version / 100;
            int secondary = version - main * 100;
            return String.Format("{0}.{1:00}", main, secondary);
        }

        public static ushort StringToVersion(string versionString)
        {
            string[] split = versionString.Split('.');
            int main = int.Parse(split[0]);
            int secondary = int.Parse(split[1] + split[2]);
            return (ushort)(main * 100 + secondary);
        }

        public static void Set(string version, Process p)
        {

            CurrentVersion = StringToVersion(version);
            CurrentVersionString = version;
            switch (version)
            {
                case "10.9.9.0":
                    SetVersion1099(p);
                    break;
                default:
                    throw new Exceptions.VersionNotSupportedException("Tibia version " + CurrentVersionString + " is not supported by TibiaAPI.");
            }

        }

    }
}
