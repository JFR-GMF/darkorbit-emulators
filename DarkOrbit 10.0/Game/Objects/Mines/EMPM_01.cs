﻿using Ow.Game.Movements;
using Ow.Managers;
using Ow.Net.netty.commands;
using Ow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ow.Game.Objects.Mines
{
    class EMPM_01 : Mine
    {
        public EMPM_01(Player player, Spacemap spacemap, Position position, int mineTypeId) : base(player, spacemap, position, mineTypeId) { }

        public override void Explode()
        {
            foreach (var character in Spacemap.Characters.Values)
            {
                if (character is Player player && player.Position.DistanceTo(Position) < EXPLODE_RANGE)
                {
                    if (Player == player || player.Storage.DuelOpponent == null || (player.Storage.DuelOpponent != null && Player == player.Storage.DuelOpponent))
                    {
                        if (player.Invisible && player.Attackable())
                            player.CpuManager.DisableCloak();
                    }
                }
            }
        }
    }
}
