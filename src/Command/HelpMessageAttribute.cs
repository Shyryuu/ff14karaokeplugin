﻿using System;

namespace DalamudPluginProjectTemplate.Command
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HelpMessageAttribute : Attribute
    {
        public HelpMessageAttribute(string helpMessage)
        {
            HelpMessage = helpMessage;
        }

        public string HelpMessage { get; }
    }
}