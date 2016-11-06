using System.Collections.Generic;

namespace Tibia.Util
{
    /// <summary>
    /// Options for the ClientChooser class
    /// </summary>
    public class ClientChooserOptions
    {
        /// <summary>
        /// Use a custom title for the client chooser.
        /// </summary>
        public string Title = string.Empty;

        /// <summary>
        /// Shows only offline clients
        /// </summary>
        public bool OfflineOnly = false;

        /// <summary>
        /// If the client chooser is topmost window
        /// </summary>
        public bool Topmost = true;

        /// <summary>
        /// Version of the clients to look for
        /// </summary>
        public string Version = null;
    }
}
