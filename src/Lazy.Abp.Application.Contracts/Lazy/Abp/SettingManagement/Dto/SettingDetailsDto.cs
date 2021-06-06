﻿using System.Collections.Generic;

namespace Lazy.Abp.SettingManagement
{
    public class SettingDetailsDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string DefaultValue { get; set; }

        public bool IsEncrypted { get; set; }

        public ValueType ValueType { get; set; }
        /// <summary>
        /// 选项列表,仅当 ValueType 为 Option有效
        /// </summary>
        public List<OptionDto> Options { get; set; } = new List<OptionDto>();

        public SettingDetailsDto AddOption(string name, string value)
        {
            Options.Add(new OptionDto
            {
                Name = name,
                Value = value
            });

            return this;
        }

        public SettingDetailsDto AddOptions(IEnumerable<OptionDto> options)
        {
            Options.AddRange(options);
            return this;
        }
    }
}