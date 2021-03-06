﻿using EBZ.Mobile.ServicesInterface;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EBZ.Mobile.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettings _settings;
        private const string UserName = "UserName";
        private const string UserId = "UserId";
        private const string Token = "Token";
        private const string ValidTo = "ValidTo";
        private const string Roles = "Roles";

        public SettingsService()
        {
            _settings = CrossSettings.Current;
        }

        public void AddItem(string key, string value)
        {
            _settings.AddOrUpdateValue(key, value);
        }

        public string GetItem(string key)
        {
            return _settings.GetValueOrDefault(key, string.Empty);
        }

        public string UserNameSetting
        {
            get => GetItem(UserName);
            set => AddItem(UserName, value);
        }

        public string UserIdSetting
        {
            get => GetItem(UserId);
            set => AddItem(UserId, value);
        }

        public string TokenSetting
        {
            get => GetItem(Token);
            set => AddItem(Token, value);
        }

        public string ValidToSetting
        {
            get => GetItem(ValidTo);
            set => AddItem(ValidTo, value);
        }

        public string RolesSetting
        {
            get => GetItem(Roles);
            set => AddItem(Roles, value);
        }
    }
}
