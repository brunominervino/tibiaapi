using System;

namespace Tibia.Constants
{
    public static class TAConstants
    {
        public static string CurrentTibiaVersion = "10.99";
        public static string AppDataPath = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "TibiaAPI");
    }
}
