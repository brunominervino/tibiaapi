namespace Tibia.Objects
{
    public class Player : Creature
    {
        /// <summary>
        /// Default constructor, same as Objects.Creature.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="address">The address.</param>
        public Player(Client client, uint address)
            : base(client, address)
        { }

        #region Get/Set Properties

        public new uint Id
        {
            get { return client.Player.Id; }
        }

        public ulong Experience
        {
            get { return client.Player.Experience; }
        }

        public uint Level
        {
            get { return client.Player.Level; }
        }

        public uint LevelPercent
        {
            get { return client.Player.LevelPercent; }
        }

        public uint MagicLevel
        {
            get { return client.Player.MagicLevel; }
        }

        public uint MagicLevelPercent
        {
            get { return client.Player.MagicLevelPercent; }
        }

        public uint Mana
        {
            get { return client.Player.Mana; }
        }

        public uint ManaMax
        {
            get { return client.Player.ManaMax; }
        }

        public uint ManaPercent
        {
            get { return client.Player.ManaPercent; }
        }

        public uint Health
        {
            get { return client.Player.Health; }
        }

        public uint HealthMax
        {
            get { return client.Player.HealthMax; }
        }

        public uint HeathPercent
        {
            get { return client.Player.HeathPercent; }
        }

        public uint Soul
        {
            get { return client.Player.Soul; }
        }

        public uint X
        {
            get { return client.Player.X; }
        }

        public uint Y
        {
            get { return client.Player.Y; }
        }

        public uint Z
        {
            get { return client.Player.Z; }
        }

        public uint GoToX
        {
            get { return client.Player.GoToX; }
        }

        public uint GoToY
        {
            get { return client.Player.GoToY; }
        }

        public uint GoToZ
        {
            get { return client.Player.GoToZ; }
        }

        #endregion
    }
}
