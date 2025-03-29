// -----------------------------------------------------------------------
// <copyright file="CommandLogging.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DiscordIntegration.Patches
{
#pragma warning disable SA1118
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Emit;
    using Dependency;
    using Exiled.API.Features;
    using HarmonyLib;
    using NorthwoodLib.Pools;
    using RemoteAdmin;

    using static HarmonyLib.AccessTools;

    /// <summary>
    /// Patches <see cref="RemoteAdmin.CommandProcessor.ProcessQuery"/> for command logging.
    /// </summary>
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    internal class CommandLogging
    {
        [HarmonyPostfix]
        private static void Postfix(string q, CommandSender sender, string __result)
        {
            if (!DiscordIntegration.Instance.Config.EventsToLog.SendingRemoteAdminCommands)
                return;

            string[] args = q.Trim().Split(QueryProcessor.SpaceArray, 512, StringSplitOptions.RemoveEmptyEntries);

            if (args[0].StartsWith("$"))
                return;

            Player player = sender is RemoteAdmin.PlayerCommandSender playerCommandSender
                ? Player.Get(playerCommandSender)
                : Server.Host;

            if (player == null || (!string.IsNullOrEmpty(player.UserId) && DiscordIntegration.Instance.Config.TrustedAdmins.Contains(player.UserId)))
                return;
            
            _ = DiscordIntegration.Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.Command, string.Format(DiscordIntegration.Language.UsedCommand, sender.Nickname, sender.SenderId ?? DiscordIntegration.Language.DedicatedServer, player.Role.Type, string.Join(" ", args), (string.IsNullOrEmpty(__result) ? DiscordIntegration.Language.UsedCommandResultEmpty : __result))));
        }
    }
}