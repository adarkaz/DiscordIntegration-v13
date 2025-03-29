// -----------------------------------------------------------------------
// <copyright file="Language.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DiscordIntegration
{
    using System;
    using System.IO;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Newtonsoft.Json;
    using PlayerRoles;
    using static DiscordIntegration;

    /// <summary>
    /// Represents the plugin language.
    /// </summary>
    [JsonObject(ItemRequired = Required.Always)]
    public sealed class Language
    {
        private readonly JsonSerializer jsonSerializer = new JsonSerializer();

        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        public Language()
        {
            jsonSerializer.Error += Error;
            jsonSerializer.Formatting = Formatting.Indented;
        }

        /// <summary>
        /// Gets the language folder.
        /// </summary>
        public static string Folder { get; } = Path.Combine(Paths.Plugins, Instance.Name, "Languages");

        /// <summary>
        /// Gets the language fullpath.
        /// </summary>
        public static string FullPath => Path.Combine(Folder, $"{Instance.Config.Language}.json");

#pragma warning disable SA1600 // Elements should be documented
#pragma warning disable CS1591
        public string UsingTimeInSeconds { get; set; } = "{0} секунд";
        public string UsedCommand { get; set; } = ":keyboard: {0} ({1}) [{2}] использовал команду: {3}, которая вывела -> {4}";
        public string UsedCommandResultEmpty { get; set; } = "ничего не вывела";
        public string HasRunClientConsoleCommand { get; set; } = ":keyboard: {0} ({1}) [{2}] использовал консольную команду: {3} {4}";
        public string NoPlayersOnline { get; set; } = "Нет игроков онлайн.";

        public string NoStaffOnline { get; set; } = "Нет администраторов онлайн.";

        public string WaitingForPlayers { get; set; } = $":hourglass: Ожидаем игроков..";

        public string RoundStarting { get; set; } = ":arrow_forward: Раунд начинается: {0} игроков в раунде.";

        public string RoundEnded { get; set; } = ":stop_button: Раунд закончился, выиграли: {0} - Игроков онлайн {1}/{2}.";

        public string PlayersOnline { get; set; } = "Игроков онлайн: {0}/{1}";

        public string RoundDuration { get; set; } = "Раунд длится: {0}";

        public string AliveHumans { get; set; } = "Живых людей: {0}";

        public string AliveScps { get; set; } = "Живых SCP: {0}";

        public string CheaterReportFilled { get; set; } = ":incoming_envelope: **Cheater report filled: {0} ({1}) [{2}] reported {3} ({4}) [{5}] for {6}.**";

        public string HasDamagedForWith { get; set; } = ":crossed_swords: **{0} ({1}) [{2}] нанес {6} урона {3} ({4}) [{5}] с помощью {7}.**";

        public string HasKilledWith { get; set; } = ":skull_crossbones: **{0} ({1}) [{2}] убил {3} ({4}) [{5}] с помощью {6}.**";

        public string ThrewAGrenade { get; set; } = ":boom: {0} ({1}) [{2}] бросил {3}.";

        public string UsedMedicalItem { get; set; } = ":medical_symbol: {0} ({1}) [{2}] использовал {3}.";

        public string ChangedRole { get; set; } = ":mens: {0} ({1}) [{2}] изменил роль на {3}.";

        public string ChaosInsurgencyHaveSpawned { get; set; } = ":spy: ПХ были заспавнены с {0} игроками.";

        public string NineTailedFoxHaveSpawned { get; set; } = ":cop: МТФ были заспавнены с {0} игроками.";

        public string HasJoinedTheGame { get; set; } = ":arrow_right: **{0} ({1}) [{2}] зашёл в игру.**";

        public string HasBeenFreedBy { get; set; } = ":unlock: {0} ({1}) [{2}] был освобожден {3} ({4}) [{5}].";

        public string HasBeenHandcuffedBy { get; set; } = ":lock: {0} ({1}) [{2}] был связан {3} ({4}) [{5}].";

        public string WasKicked { get; set; } = ":no_entry: {0} ({1}) был кикнут за {2}.";

        public string WasBannedBy { get; set; } = ":no_entry: {0} ({1}) был забанен {2} за {3}. Бан истекает: {4}.";

        public string HasStartedUsingTheIntercom { get; set; } = ":loud_sound: {0} ({1}) [{2}] начал использовать интерком на протяжении {3}.";

        public string HasPickedUp { get; set; } = "{0} ({1}) [{2}] подобрал **{3}**.";

        public string HasDropped { get; set; } = "{0} ({1}) [{2}] выбросил **{3}**.";

        public string DecontaminationHasBegun { get; set; } = ":biohazard: **Обеззараживание началось.**";

        public string HasEnteredPocketDimension { get; set; } = ":door: {0} ({1}) [{2}] попал в измерение.";

        public string HasEscapedPocketDimension { get; set; } = ":high_brightness: {0} ({1}) [{2}] вышёл из измерения.";

        public string HasTriggeredATeslaGate { get; set; } = ":zap: {0} ({1}) [{2}] активировал тесла-ворота на протяжении {3}.";

        public string Scp914ProcessedItem { get; set; } = ":gear: SCP-914 обработал: **{0}**";

        public string HasClosedADoor { get; set; } = ":door: {0} ({1}) [{2}] закрыл дверь {3}.";

        public string HasOpenedADoor { get; set; } = ":door: {0} ({1}) [{2}] открыл дверь {3}.";

        public string Scp914HasBeenActivated { get; set; } = ":gear: {0} ({1}) [{2}] активировал SCP-914 на настройке {3}.";

        public string Scp914KnobSettingChanged { get; set; } = ":gear: {0} ({1}) [{2}] изменил настройку SCP-914 на {3}.";

        public string PlayerCanceledWarhead { get; set; } = ":no_entry: **{0} ({1}) [{2}] отменил детонацию альфа-боеголовки.**";

        public string CanceledWarhead { get; set; } = ":no_entry: **Детонация альфа-боеголовки отменена.**";

        public string WarheadHasDetonated { get; set; } = ":radioactive: **Альфа-боеголовка сдетанировала.**";

        public string WarheadHasBeenDetonated { get; set; } = "Боеголовка сдетанировала.";

        public string WarheadIsCountingToDetonation { get; set; } = "Ожидается детонация боеголовки.";

        public string WarheadHasntBeenDetonated { get; set; } = "Боеголовка не сдетанировала.";

        public string PlayerWarheadStarted { get; set; } = ":radioactive: **{0} ({1}) [{2}] запустил альфа-боеголовку, детонация через: {3}.**";

        public string WarheadStarted { get; set; } = ":radioactive: **Альфа-боеголовка запущена, детонация через: {0}.**";

        public string AccessedWarhead { get; set; } = ":key: {0} ({1}) [{2}] получил доступ к кнопке детонации.";

        public string CalledElevator { get; set; } = ":elevator: {0} ({1}) [{2}] отправил лифт {3}.";

        public string UsedLocker { get; set; } = "{0} ({1}) [{2}] открыл ящик.";

        public string GeneratorDisabledCountdown { get; set; } = "{0} ({1}) [{2}] выключил генератор в {3}.";

        public string GeneratorOpened { get; set; } = "{0} ({1}) [{2}] открыл генератор в {3}.";

        public string SCP096AddingTarget { get; set; } = "{0} ({1}) [{2}] - было добавлено в цели -  {3} ({4}) [{5}]";

        public string GeneratorClosed { get; set; } = "{0} ({1}) [{2}] закрыл генератор.";

        public string GeneratorFinished { get; set; } = "Генератор в {0} включился. {1} генераторов было активировано.";

        public string GeneratorStartedCountdown { get; set; } = ":calling: {0} ({1}) [{2}] запустил генератор.";

        public string GeneratorUnlocked { get; set; } = ":unlock: {0} ({1}) [{2}] разблокировал генератор.";

        public string GainedExperience { get; set; } = "{0} ({1}) [{2}] получил {3} опыта за {4}.";

        public string GainedLevel { get; set; } = "{0} ({1}) [{2}] получил {3} уровень.";

        public string LeftServer { get; set; } = ":arrow_left: **{0} ({1}) [{2}] вышел с сервера.**";

        public string Reloaded { get; set; } = ":arrows_counterclockwise: {0} ({1}) [{2}] перезарядил оружие {3}.";

        public string GroupSet { get; set; } = "{0} ({1}) [{2}] был привязан к группе **{3} ({4})**.";

        public string ItemChanged { get; set; } = "{0} ({1}) [{2}] изменил вещь в руке с {3} на {4}.";

        public string InvalidSubcommand { get; set; } = "Неправильная подкоманда!";

        public string Available { get; set; } = "Доступно";

        public string BotIsNotConnectedError { get; set; } = "Бот не подключен!";

        public string PlayerListCommandDescription { get; set; } = "Получить список игроков на сервере.";

        public string StaffListCommandDescription { get; set; } = "Получить список администраторов на сервере.";

        public string ReloadConfigsCommandDescription { get; set; } = "Перезагрузить конфиги бота.";

        public string ReloadConfigsCommandSuccess { get; set; } = "Конфиги бота успешно перезагружены.";

        public string NotEnoughPermissions { get; set; } = "Вам необходимо право \"{0}\" для использования этой команды!";

        public string ServerConnected { get; set; } = "```diff\n+ Сервер подключен.\n```";

        public string SendingDataError { get; set; } = "Ошибка при отправлении данных: {0}";

        public string ReceivingDataError { get; set; } = "Ошибка при получении данных: {0}";

        public string ConnectingError { get; set; } = "Ошибка при подключении: {0}";

        public string SuccessfullyConnected { get; set; } = "Успешно подключен к {0}:{1}.";

        public string ReceivedData { get; set; } = "Получено {0} ({1} байтов) с сервера.";

        public string SentData { get; set; } = "Отправлено {0} ({1} байтов) на сервер.";

        public string ConnectingTo { get; set; } = "Подключаюсь к {0}:{1}.";

        public string ReloadLanguageCommandDescription { get; set; } = "Перезагрузить язык плагина.";

        public string ReloadLanguageCommandSuccess { get; set; } = "Язык успешно перезагружен!";

        public string CouldNotUpdateChannelTopicError { get; set; } = "Ошибка при обновлении темы канала: {0}";

        public string HandlingRemoteCommand { get; set; } = "Обработка слеш-команды \"{0}\" с параметрами: {1} от {2}.";

        public string HandlingRemoteCommandError { get; set; } = "Ошибка при обработке слеш-команды: {0}";

        public string None { get; set; } = "Нет";

        public string InvalidGroupError { get; set; } = "{0} не правильная группа!";

        public string ServerHasBeenTerminated { get; set; } = "Сервер был уничтожен.";

        public string ServerHasBeenTerminatedWithErrors { get; set; } = "Сервер был уничтожен с ошибкой: {0}";

        public string UpdatingConnectionError { get; set; } = "Ошибка при обновлении подключения: {0}";

        public string InvalidIPAddress { get; set; } = "{0} это не правильный IP адресс !";

        public string Redacted { get; set; } = "████████";

        public string NotAuthenticated { get; set; } = "Неавторизован";

        public string DedicatedServer { get; set; } = "Сервер";

        public Dictionary<DamageType, string> DamageLocalization { get; set; } = new()
        {
            {
                DamageType.Unknown,
                "неизвестно"
            }
        };
        public Dictionary<RoleTypeId, string> RoleLocalization { get; set; } = new()
        {
            {
                RoleTypeId.ClassD,
                "класс Д"
            }
        };

#pragma warning restore CS1591
#pragma warning restore SA1600 // Elements should be documented

        /// <summary>
        /// Loads the language.
        /// </summary>
        public void Load()
        {
            StreamReader streamReader = new StreamReader(FullPath);

            try
            {
                jsonSerializer.Populate(streamReader, this);
            }
            catch (Exception exception)
            {
                Log.Error($"Error! Failed to read {Instance.Config.Language} language, located at \"{FullPath}\": {exception}.\nDefault translation will be used.");
                return;
            }
            finally
            {
                streamReader?.Dispose();
            }
        }

        /// <summary>
        /// Saves the language.
        /// </summary>
        /// <param name="shouldOverwrite">Indicates a value whether the file should be overwritten or not.</param>
        public void Save(bool shouldOverwrite = false)
        {
            if (File.Exists(FullPath) && !shouldOverwrite)
                return;

            try
            {
                if (!Directory.Exists(Folder))
                    Directory.CreateDirectory(Folder);
            }
            catch (Exception exception)
            {
                Log.Error($"Error! Failed to create language directory at \"{Folder}\": {exception}.");
                return;
            }

            StreamWriter streamWriter = new StreamWriter(FullPath);

            try
            {
                jsonSerializer.Serialize(streamWriter, this);
            }
            catch (Exception exception)
            {
                Log.Error($"Error! Failed to create \"{Instance.Config.Language}\" language at \"{FullPath}\": {exception}.");
                return;
            }
            finally
            {
                streamWriter?.Dispose();
            }
        }

        private void Error(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs ev)
        {
            Log.Warn($"Translation not found for \"{ev.ErrorContext.Member}\" key, loading default one...");

            ev.ErrorContext.Handled = true;
        }
    }
}
