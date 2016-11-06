using System;

namespace Tibia.Objects
{
    public partial class Client
    {
        public class PlayerHelper
        {
            private Client client;

            internal PlayerHelper(Client client)
            {
                this.client = client;
            }

            #region Get/Set Properties

            public uint Id
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Id); }
            }

            public ulong Experience
            {
                get { return client.Memory.ReadUInt64(Addresses.Player.Experience); }
            }

            public uint Level
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Level); }
            }

            public uint LevelPercent
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.LevelPercent); }
            }

            public uint MagicLevel
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.MagicLevel); }
            }

            public uint MagicLevelPercent
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.MagicLevelPercent); }
            }

            public uint Mana
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Mana) ^ client.Memory.ReadUInt32(Addresses.Player.Xor); }
            }

            public uint ManaMax
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.ManaMax) ^ client.Memory.ReadUInt32(Addresses.Player.Xor); }
            }

            public uint ManaPercent
            {
                get { return Convert.ToUInt16(Math.Round(Convert.ToDouble(Mana * 100) / Convert.ToDouble(ManaMax))); }
            }

            public uint Health
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Health) ^ client.Memory.ReadUInt32(Addresses.Player.Xor); }
            }

            public uint HealthMax
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.HealthMax) ^ client.Memory.ReadUInt32(Addresses.Player.Xor); }
            }

            public uint HeathPercent
            {
                get { return Convert.ToUInt16(Math.Round(Convert.ToDouble(Health * 100) / Convert.ToDouble(HealthMax))); }
            }

            public uint Soul
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Soul); }
            }

            public uint X
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.X); }
            }

            public uint Y
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Y); }
            }

            public uint Z
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.Z); }
            }

            public uint GoToX
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.GoToX); }
            }

            public uint GoToY
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.GoToY); }
            }

            public uint GoToZ
            {
                get { return client.Memory.ReadUInt32(Addresses.Player.GoToZ); }
            }

            #endregion
        }
    }
}

