// -----------------------------------------------------------------------
// <copyright file="PlayerHandler.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DiscordIntegration.Events
{
    using System;
    using Dependency;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Player;
    using Exiled.Events.EventArgs.Scp079;
    using Exiled.Events.EventArgs.Scp096;
    using Exiled.Events.EventArgs.Scp106;
    using Exiled.Events.EventArgs.Scp914;
    using MapGeneration.Distributors;
    using MEC;
    using PlayerRoles;
    using static DiscordIntegration;

    /// <summary>
    /// Handles player-related events.
    /// </summary>
    internal sealed class PlayerHandler
    {
#pragma warning disable SA1600 // Elements should be documented
        public async void OnActivatingGenerator(ActivatingGeneratorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerActivatedGenerator)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GeneratorStartedCountdown, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }
        public async void OnOpeningGenerator(OpeningGeneratorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerOpeningGenerator)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GeneratorOpened, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Generator.Room.Type))).ConfigureAwait(false);
        }
        public async void On096AddingTarget(AddingTargetEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.SCP096AddingTarget)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.SCP096AddingTarget, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Target.Nickname, ev.Target.UserId, Language.RoleLocalization.TryGetValue(ev.Target.Role.Type, out string localrole2) ? localrole2 : ev.Target.Role.Type))).ConfigureAwait(false);
        }

        public async void OnUnlockingGenerator(UnlockingGeneratorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerUnlockingGenerator)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GeneratorUnlocked, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }
        public async void OnChangingItem(ChangingItemEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.ChangingPlayerItem)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.ItemChanged, ev.Player.Nickname, ev.Player.UserId, ev.Player.CurrentItem.Type, ev.Item.Type))).ConfigureAwait(false);
        }

        public async void OnGainingExperience(GainingExperienceEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.GainingScp079Experience)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GainedExperience, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Amount, ev.GainType))).ConfigureAwait(false);
        }

        public async void OnGainingLevel(GainingLevelEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.GainingScp079Level)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GainedLevel, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.NewLevel))).ConfigureAwait(false);
        }

        public async void OnDestroying(DestroyingEventArgs ev)
        {
            if (Instance.Config.EventsToLog.PlayerLeft)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.LeftServer, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.ReloadingPlayerWeapon)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.Reloaded, ev.Player.Nickname, ev.Player.UserId, ev.Player.CurrentItem.Type, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerActivatingWarheadPanel)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.AccessedWarhead, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnInteractingElevator(InteractingElevatorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerInteractingElevator)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.CalledElevator, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Lift.Type))).ConfigureAwait(false);
        }

        public async void OnInteractingLocker(InteractingLockerEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerInteractingLocker)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.UsedLocker, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public void OnTriggeringTesla(TriggeringTeslaEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (!ev.Tesla.PlayersInTriggerRange.Contains(ev.Player)) return;

            if (CurrentTeslaCoroutineProcessing.Contains(ev.Player)) return;

            Timing.RunCoroutine(TeslaPlayer(ev.Player, ev.Tesla));
        }
        public static readonly List<Player> CurrentTeslaCoroutineProcessing = new();
        public static IEnumerator<float> TeslaPlayer(Player pl, TeslaGate tesla)
        {
            CurrentTeslaCoroutineProcessing.Add(pl);
            DateTime startedTime = DateTime.Now;

            while (tesla.PlayersInTriggerRange.Contains(pl))
            {
                yield return Timing.WaitForSeconds(5f);
            }

            CurrentTeslaCoroutineProcessing.Remove(pl);

            Timing.CallDelayed(0.1f, async () =>
            {
                if (Instance.Config.EventsToLog.PlayerTriggeringTesla)
                    await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasTriggeredATeslaGate, pl.Nickname, pl.UserId, pl.Role, string.Format(Language.UsingTimeInSeconds, DateTime.Now.Subtract(startedTime).TotalSeconds)))).ConfigureAwait(false);
            });

            yield return Timing.WaitForOneFrame;
        }

        public async void OnClosingGenerator(ClosingGeneratorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerClosingGenerator)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GeneratorClosed, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnStoppingGenerator(StoppingGeneratorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerEjectingGeneratorTablet)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GeneratorDisabledCountdown, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnInteractingDoor(InteractingDoorEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerInteractingDoor)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(ev.Door.IsOpen ? Language.HasClosedADoor : Language.HasOpenedADoor, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Door.Nametag))).ConfigureAwait(false);
        }

        public async void OnActivatingScp914(ActivatingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.ActivatingScp914)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.Scp914HasBeenActivated, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, Scp914.KnobStatus))).ConfigureAwait(false);
        }

        public async void OnChangingScp914KnobSetting(ChangingKnobSettingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.ChangingScp914KnobSetting)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.Scp914KnobSettingChanged, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.KnobSetting))).ConfigureAwait(false);
        }

        public async void OnEnteringPocketDimension(EnteringPocketDimensionEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerEnteringPocketDimension)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasEnteredPocketDimension, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnEscapingPocketDimension(EscapingPocketDimensionEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerEscapingPocketDimension)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasEscapedPocketDimension, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnInteractingTesla(InteractingTeslaEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.Scp079InteractingTesla)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasTriggeredATeslaGate, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnHurting(HurtingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.HurtingPlayer && ev.Player != null && (ev.Attacker == null || !Instance.Config.ShouldLogFriendlyFireDamageOnly || ev.Attacker.Role.Side == ev.Player.Role.Side) && !Instance.Config.BlacklistedDamageTypes.Contains(ev.DamageHandler.Type) && (!Instance.Config.OnlyLogPlayerDamage || ev.Attacker != null))
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasDamagedForWith, ev.Attacker != null ? ev.Attacker.Nickname : "Server", ev.Attacker != null ? ev.Attacker.UserId : string.Empty, ev.Attacker?.Role ?? RoleTypeId.None, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Amount, Language.DamageLocalization.TryGetValue(ev.DamageHandler.Type, out var local) ? local : ev.DamageHandler.Type))).ConfigureAwait(false);
        }

        public async void OnDying(DyingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerDying && ev.Player != null && (ev.Attacker == null || !Instance.Config.ShouldLogFriendlyFireKillsOnly || ev.Attacker.Role.Side == ev.Player.Role.Side))
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasKilledWith, ev.Attacker != null ? ev.Attacker.Nickname : "Server", ev.Attacker != null ? ev.Attacker.UserId : string.Empty, ev.Attacker?.Role ?? RoleTypeId.None, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, Language.DamageLocalization.TryGetValue(ev.DamageHandler.Type, out var local) ? local : ev.DamageHandler.Type))).ConfigureAwait(false);
        }

        public async void OnThrownProjectile(ThrownProjectileEventArgs ev)
        {
            if (ev.Player != null && Instance.Config.EventsToLog.PlayerThrowingGrenade)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.ThrewAGrenade, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Item.Type))).ConfigureAwait(false);
        }

        public async void OnUsedMedicalItem(UsedItemEventArgs ev)
        {
            if (ev.Player != null && Instance.Config.EventsToLog.PlayerUsedMedicalItem)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.UsedMedicalItem, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Item))).ConfigureAwait(false);
        }

        public async void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (ev.Player != null && Instance.Config.EventsToLog.ChangingPlayerRole)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.ChangedRole, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.NewRole))).ConfigureAwait(false);
        }

        public async void OnVerified(VerifiedEventArgs ev)
        {
            if (Instance.Config.EventsToLog.PlayerJoined)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasJoinedTheGame, ev.Player.Nickname, ev.Player.UserId, ev.Player.IPAddress))).ConfigureAwait(false);
        }

        public async void OnRemovingHandcuffs(RemovingHandcuffsEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerRemovingHandcuffs)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasBeenFreedBy, ev.Target.Nickname, ev.Target.UserId, Language.RoleLocalization.TryGetValue(ev.Target.Role.Type, out string localrole2) ? localrole2 : ev.Target.Role.Type, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }

        public async void OnHandcuffing(HandcuffingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.HandcuffingPlayer)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasBeenHandcuffedBy, ev.Target.Nickname, ev.Target.UserId, Language.RoleLocalization.TryGetValue(ev.Target.Role.Type, out string localrole2) ? localrole2 : ev.Target.Role.Type, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type))).ConfigureAwait(false);
        }
        public async void OnBanning(BanningEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            Log.Info(ev.Duration);

            if (Instance.Config.EventsToLog.PlayerBanned)
            {
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.Bans, $":no_entry: {ev.Target.Nickname} ({ev.Target.UserId} - {ev.Target.IPAddress}) был забанен {ev.Player.Nickname} ({ev.Player.UserId}) по причине: {ev.Reason} до <t:{DateTimeOffset.Now.AddSeconds(ev.Duration).ToUnixTimeSeconds()}>"));
            }
        }

        public void OnIntercomSpeaking(IntercomSpeakingEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (CurrentIntercomCoroutineProcessing.Contains(ev.Player)) return;

            Timing.RunCoroutine(IntercomPlayer(ev.Player));
        }

        public static readonly List<Player> CurrentIntercomCoroutineProcessing = new();
        public static IEnumerator<float> IntercomPlayer(Player pl)
        {
            CurrentIntercomCoroutineProcessing.Add(pl);

            DateTime startedTime = DateTime.Now;

            while (Intercom.Speaker == pl)
            {
                Timing.CallDelayed(0.1f, async () =>
                {
                    if (pl != null && Instance.Config.EventsToLog.PlayerIntercomSpeaking)
                        await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasStartedUsingTheIntercom, pl.Nickname, pl.UserId, pl.Role, string.Format(Language.UsingTimeInSeconds, DateTime.Now.Subtract(startedTime).TotalSeconds)))).ConfigureAwait(false);
                });

                yield return Timing.WaitForSeconds(5f);
            }

            CurrentIntercomCoroutineProcessing.Remove(pl);

            yield return Timing.WaitForOneFrame;
        }

        public async void OnPickingUpItem(PickingUpItemEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerPickingupItem)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasPickedUp, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Pickup.Type))).ConfigureAwait(false);
        }

        public async void OnItemDropped(DroppingItemEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (Instance.Config.EventsToLog.PlayerItemDropped)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.HasDropped, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.Item.Type))).ConfigureAwait(false);
        }

        public async void OnChangingGroup(ChangingGroupEventArgs ev)
        {
            if (!ev.IsAllowed) return;

            if (ev.Player != null && Instance.Config.EventsToLog.ChangingPlayerGroup)
                await Network.SendAsync(new RemoteCommand(ActionType.Log, ChannelType.GameEvents, string.Format(Language.GroupSet, ev.Player.Nickname, ev.Player.UserId, Language.RoleLocalization.TryGetValue(ev.Player.Role.Type, out string localrole) ? localrole : ev.Player.Role.Type, ev.NewGroup?.BadgeText ?? Language.None, ev.NewGroup?.BadgeColor ?? Language.None))).ConfigureAwait(false);
        }
    }
}