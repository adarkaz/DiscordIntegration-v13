// -----------------------------------------------------------------------
// <copyright file="ServerHandler.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DiscordIntegration.Events
{
    using Dependency;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Player;
    using Exiled.Events.EventArgs.Server;
    using Respawning;
    using Respawning.Waves;
    using static DiscordIntegration;

    /// <summary>
    /// Handles server-related events.
    /// </summary>
    internal sealed class ServerHandler
    {
#pragma warning disable SA1600 // Elements should be documented

        public async void OnReportingCheater(ReportingCheaterEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.ReportingCheater)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.Reports, string.Format(Language.CheaterReportFilled, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Target.Nickname, ev.Target.UserId, Language.RoleLocalization.TryGetValue(ev.Target.Role.Type, out string localrole2) ? localrole2 : ev.Target.Role.Type, ev.Reason))).ConfigureAwait(false);
        }

        public async void OnLocalReporting(LocalReportingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.ReportingCheater)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.Reports, string.Format(Language.CheaterReportFilled, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Target.Nickname, ev.Target.UserId, Language.RoleLocalization.TryGetValue(ev.Target.Role.Type, out string localrole2) ? localrole2 : ev.Target.Role.Type, ev.Reason))).ConfigureAwait(false);
        }

        public async void OnWaitingForPlayers()
        {
            if (Instance.Config.EventsToLog.WaitingForPlayers)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, Language.WaitingForPlayers)).ConfigureAwait(false);
        }

        public async void OnRoundStarted()
        {
            if (Instance.Config.EventsToLog.RoundStarted)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.RoundStarting, Player.Dictionary.Count))).ConfigureAwait(false);
        }

        public async void OnRoundEnded(RoundEndedEventArgs ev)
        {
            if (Instance.Config.EventsToLog.RoundEnded)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.RoundEnded, ev.LeadingTeam, Player.Dictionary.Count, Instance.Slots))).ConfigureAwait(false);
        }

        public async void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.RespawningTeam)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(ev.NextKnownTeam == PlayerRoles.Faction.FoundationEnemy ? Language.ChaosInsurgencyHaveSpawned : Language.NineTailedFoxHaveSpawned, ev.Players.Count))).ConfigureAwait(false);
        }
    }
}