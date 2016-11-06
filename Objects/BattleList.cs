using System.Collections.Generic;

namespace Tibia.Objects
{
    public class BattleList
    {
        private Client client;

        /// <summary>
        /// Create a battlelist object.
        /// </summary>
        /// <param name="c"></param>
        public BattleList(Client c)
        {
            client = c;
        }

        /// <summary>
        /// Get a list of all the creatures on the battlelist.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Creature> GetCreatures()
        {
            for (uint i = Addresses.BattleList.Start; i < Addresses.BattleList.End; i += Addresses.BattleList.StepCreatures)
            {
                if (client.Memory.ReadInt32(i) > 0)
                    yield return new Creature(client, i);
            }
        }

        private int GetIDAddress()
        {
            int ID = 0, PID = 0, y = 0;
            for (int x = (int)Addresses.BattleList.Start; x < Addresses.BattleList.End; x += (int)Addresses.BattleList.StepCreatures)
            {
                ID = client.Memory.ReadInt32(x);
                PID = client.Memory.ReadInt32(Addresses.Player.Id);
                if (ID == PID)
                {
                    y = x;
                    return x;
                }
            }
            return y;
        }
    }
}
