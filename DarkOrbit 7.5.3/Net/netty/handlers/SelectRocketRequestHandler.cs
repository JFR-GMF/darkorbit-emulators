﻿using Ow.Game;
using Ow.Managers;
using Ow.Net.netty.commands;
using Ow.Net.netty.requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ow.Net.netty.handlers
{
    class SelectRocketRequestHandler : IHandler
    {
        public void execute(GameSession gameSession, byte[] bytes)
        {
            var read = new SelectRocketRequest();
            read.readCommand(bytes);

            var player = gameSession.Player;
            var settingsManager = player.SettingsManager;
            var newSelectedRocket = read.rocketType.typeValue;

            settingsManager.SelectedRocket = newSelectedRocket;
            player.AttackManager.RocketAttack();
            player.Settings.ShipSettings.selectedRocket = newSelectedRocket;
        }
    }
}
