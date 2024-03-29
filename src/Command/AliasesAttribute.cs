﻿using System;

namespace DalamudPluginProjectTemplate.Command
{
    [AttributeUsage(AttributeTargets.Method)]
    public class AliasesAttribute : Attribute
    {
        public AliasesAttribute(params string[] aliases)
        {
            Aliases = aliases;
        }

        public string[] Aliases { get; }
    }
}