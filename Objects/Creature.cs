using System;

namespace Tibia.Objects
{
    public class Creature
    {
        protected Client client;
        protected uint address;

        /// <summary>
        /// Create a new creature object with the given client and address.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="address">The address.</param>
        public Creature(Client client, uint address)
        {
            this.client = client;
            this.address = address;
        }

        public uint Address
        {
            get { return address; }
            set { address = value; }
        }

        #region Get/Set Methods

        public Client Client
        {
            get { return client; }
        }

        public uint Id
        {
            get { return client.Memory.ReadUInt32(address); }
        }

        public string Name
        {
            get { return client.Memory.ReadString(address + Addresses.Creature.DistanceName); }
        }

        public bool IsWalking
        {
            get { return Convert.ToBoolean(client.Memory.ReadByte(address + Addresses.Creature.DistanceIsWalking)); }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
