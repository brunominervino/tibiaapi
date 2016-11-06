using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tibia.Objects
{
    public partial class Client
    {
        #region Variables

        private string cachedVersion = null;
        private ushort cachedVersionNumber = 0;

        private Process process;
        private IntPtr processHandle;

        private int startTime;

        private BattleList battleList;
        private MemoryHelper memory;
        private PlayerHelper player;

        #endregion

        #region Events

        /// <summary>
        /// Event raised when the Tibia client is exited.
        /// </summary>
        public event EventHandler Exited;

        private void process_Exited(object sender, EventArgs e)
        {
            if (Exited != null)
                Exited.Invoke(this, e);
        }

        #endregion

        #region Constructor/Destructor

        /// <summary>
        /// "Support" constructor
        /// </summary>
        /// <param name="p">used when necessary to use classes such as packet builder when working clientless</param>
        public Client() { }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="p">the client's process object</param>
        public Client(Process p)
        {
            process = p;
            process.Exited += new EventHandler(process_Exited);
            process.EnableRaisingEvents = true;

            process.WaitForInputIdle();

            while (process.MainWindowHandle == IntPtr.Zero)
            {
                process.Refresh();
                System.Threading.Thread.Sleep(5);
            }

            memory = new MemoryHelper(this);
            player = new PlayerHelper(this);

            processHandle = p.Handle;

            startTime = Memory.ReadInt32(Addresses.Client.StartTime);
        }

        /// <summary>
        /// Finalize this client, closing the handle.
        /// Called before the object is garbage collected.
        /// </summary>
        ~Client()
        {
            // Close the process handle
            Util.WinApi.CloseHandle(ProcessHandle);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Check whether or not the client is logged in
        /// </summary>
        public bool LoggedIn
        {
            get { return Convert.ToBoolean(memory.ReadByte(Addresses.Client.Connected)); }
        }

        /// <summary>
        /// Get the client's version
        /// </summary>
        /// <returns></returns>
        public string Version
        {
            get
            {
                if (cachedVersion == null)
                {
                    cachedVersion = process.MainModule.FileVersionInfo.FileVersion;
                }
                return cachedVersion;
            }
        }

        /// <summary>
        /// Get the client's version as a number
        /// </summary>
        /// <returns></returns>
        public ushort VersionNumber
        {
            get
            {
                if (cachedVersionNumber == 0)
                {
                    cachedVersionNumber = Tibia.Version.StringToVersion(Version);
                }
                return cachedVersionNumber;
            }
        }

        #endregion

        #region Override Functions
        /// <summary>
        /// String identifier for this client.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (!Constants.TAConstants.CurrentTibiaVersion.Equals(Version))
            {
                Tibia.Version.Set(Version, Process);
            }

            string s = "[" + Tibia.Version.VersionToString(Tibia.Version.CurrentVersion) + "] ";
            if (!LoggedIn)
                s += "Not logged in.";
            else
                s += GetPlayer().Name;

            return s;
        }
        #endregion

        #region Client's Objects

        /// <summary>
        /// Get the client's player.
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            if (!LoggedIn)
                throw new Exceptions.NotLoggedInException();

            int playerId = Memory.ReadInt32(Addresses.Player.Id);

            return new Player(this, BattleList.GetCreatures().
                First(c => c.Id == playerId).Address);
        }

        /// <summary>
        /// Get the time the client was started.
        /// </summary>
        /// <returns></returns>
        public int StartTime
        {
            get { return startTime; }
        }

        /// <summary>
        /// Get the client's process.
        /// </summary>
        public Process Process
        {
            get { return process; }
        }

        /// <summary>
        /// Get the client's process handle
        /// </summary>
        public IntPtr ProcessHandle
        {
            get { return processHandle; }
        }

        public MemoryHelper Memory
        {
            get { return memory; }
        }

        public PlayerHelper Player
        {
            get { return player; }
        }

        /// <summary>
        /// Get the client's battlelist.
        /// </summary>
        /// <returns></returns>
        public BattleList BattleList
        {
            get
            {
                if (battleList == null) battleList = new BattleList(this);
                return battleList;
            }
        }

        #endregion

        #region Client Processes

        /// <summary>
        /// Get a list of all the open clients. Class method.
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients()
        {
            return GetClients(null);
        }

        /// <summary>
        /// Get a list of all the open clients of certain version. Class method.
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients(string version)
        {
            return GetClients(version, false);
        }

        /// <summary>
        /// Get a list of all the open clients of certain version. Class method.
        /// </summary>
        /// <returns></returns>
        public static List<Client> GetClients(string version, bool offline)
        {
            List<Client> clients = new List<Client>();
            Client client = null;

            foreach (Process process in Process.GetProcessesByName("tibia"))
            {
                if (version == null)
                {
                    client = new Client(process);
                    if (!offline || !client.LoggedIn)
                        clients.Add(client);
                }
                else if (process.MainModule.FileVersionInfo.FileVersion == version)
                {
                    clients.Add(new Client(process));
                    if (!offline || !client.LoggedIn)
                        clients.Add(client);
                }
            }

            return clients;
        }

        public void Close()
        {
            if (process != null && !process.HasExited)
                process.Kill();
        }

        #endregion
    }
}
