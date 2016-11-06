using Tibia.Addresses;
using System.Diagnostics;
using System;

namespace Tibia
{
    public partial class Version
    {
        public static void SetVersion1099(Process p)
        {
            uint BaseAddress = Convert.ToUInt32(p.MainModule.BaseAddress.ToInt32());

            BattleList.Start = 0x73CF70 + BaseAddress;
            BattleList.StepCreatures = 0xDC;
            BattleList.MaxCreatures = 0x514;
            BattleList.End = BattleList.Start + (BattleList.StepCreatures * BattleList.MaxCreatures);

            Client.Connected = 0x556ADC + BaseAddress;

            Player.Id = 0x6E2050 + BaseAddress;
            Player.Xor = 0x544FD8 + BaseAddress;
            Player.Health = 0x6E2000 + BaseAddress;
            Player.HealthMax = 0x6E2048 + BaseAddress;
            Player.Mana = 0x54500C + BaseAddress;
            Player.ManaMax = 0x544FDC + BaseAddress;
            Player.Soul = 0x544FF4 + BaseAddress;

            Player.X = 0x6E2054 + BaseAddress;
            Player.Y = 0x6E2058 + BaseAddress;
            Player.Z = 0x6E205C + BaseAddress;

            Creature.DistanceName = 4;
            Creature.DistanceIsVisible = 148;
        }
    }
}
