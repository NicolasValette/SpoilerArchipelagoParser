using NoNiDev.CLIParser.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NoNiDev.CLIParser
{
    public class CommandLineParser
    {
        public static T Parse <T> (string[] args) where T : new()
        {
            T result = new T();

            var properties = typeof(T).GetProperties();
            for (int i = 0; i < args.Length; i++)
            {
                var prop = properties.FirstOrDefault(p =>
                {
                    var attr = p.GetCustomAttribute<FlagAttribute>();
                    return attr != null && (
                        $"--{attr.LongFlag}" == args[i] ||
                        $"-{attr.ShortFlag}" == args[i]
                    );
                });
                if (prop != null && prop.PropertyType == typeof(bool))
                {
                    prop.SetValue(result, true);
                    continue; // Les booléens n'ont pas de valeur à lire, on passe à l'argument suivant
                }
                if (prop != null && i + 1 < args.Length)
                {
                    string valeurBrute = args[i + 1];
                    if (prop.PropertyType == typeof(List<string>))
                    {
                        var liste = (List<string>)prop.GetValue(result) ?? new List<string>();

                        liste.Add(valeurBrute);

                        prop.SetValue(result, liste);
                    }
                    else
                    {
                        prop.SetValue(result, valeurBrute);
                    }
                    i++;
                }
            }
            return result;
        }
    }
}
