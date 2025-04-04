// -----------------------------------------------------------------------
// <copyright file="MapHandler.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DiscordIntegration.Events
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using Dependency;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Map;
    using Exiled.Events.EventArgs.Scp914;
    using Exiled.Events.EventArgs.Warhead;
    using static DiscordIntegration;

    /// <summary>
    /// Handles map-related events.
    /// </summary>
    internal sealed class MapHandler
    {
#pragma warning disable SA1600 // Elements should be documented
        public async void OnWarheadDetonated()
        {
            if (Instance.Config.EventsToLog.WarheadDetonated)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, Language.WarheadHasDetonated)).ConfigureAwait(false);
        }

        public async void OnGeneratorActivated(GeneratorActivatingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.GeneratorActivated)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GeneratorFinished, ev.Generator.Room, Generator.Get(GeneratorState.Engaged).Count() + 1))).ConfigureAwait(false);
        }

        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1313:Parameter names should begin with lower-case letter", Justification = "Discard operator")]
        public async void OnDecontaminating(DecontaminatingEventArgs _)
        {
            if (Instance.Config.EventsToLog.Decontaminating)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, Language.DecontaminationHasBegun)).ConfigureAwait(false);
        }

        public async void OnStartingWarhead(StartingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.StartingWarhead && (ev.Player == null || (ev.Player != null)))
            {
                object[] vars = ev.Player == null ?
                    new object[] { Warhead.DetonationTimer } :
                    new object[] { ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, Warhead.DetonationTimer };

                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(ev.Player == null ? Language.WarheadStarted : Language.PlayerWarheadStarted, vars))).ConfigureAwait(false);
            }
        }

        public async void OnStoppingWarhead(StoppingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.StoppingWarhead && (ev.Player == null || (ev.Player != null)))
            {
                object[] vars = ev.Player == null ?
                    Array.Empty<object>() :
                    new object[] { ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type };

                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(ev.Player == null ? Language.CanceledWarhead : Language.PlayerCanceledWarhead, vars))).ConfigureAwait(false);
            }
        }

        public async void OnUpgradingItems(UpgradingInventoryItemEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.UpgradingScp914Items)
            {
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.Scp914ProcessedItem, ev.Item.Type)));
            }
        }
    }
}