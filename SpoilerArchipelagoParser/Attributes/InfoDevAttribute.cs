using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InfoDevAttribute(string name) : Attribute
    {
        public string Name { get; set; } = name;

        void foo()
        {
           
        }
    }
}
