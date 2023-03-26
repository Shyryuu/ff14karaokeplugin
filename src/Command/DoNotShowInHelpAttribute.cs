using System;

namespace DalamudPluginProjectTemplate.Command
{
    [AttributeUsage(AttributeTargets.Method)]
    public class DoNotShowInHelpAttribute : Attribute
    {
    }
}