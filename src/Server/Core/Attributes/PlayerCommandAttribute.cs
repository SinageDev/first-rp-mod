using System;

namespace Mod.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class PlayerCommandAttribute : Attribute
    {
        public string Name;

        public PlayerCommandAttribute(string name)
        {
            Name = name;
        }

        public byte Admin;
        public string[] Aliases;
    }
}