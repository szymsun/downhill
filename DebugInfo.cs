using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace downhill;

public static class DebugInfo
{
    private static readonly Dictionary<string, string> ValueRegistry = new();

    public static void SetParameter(string name, Object value)
    {
        ValueRegistry[name] = value.ToString();
    }

    public static string GetParameter(string name)
    {
        return ValueRegistry[name];
    }

    public static string GetParams()
    {
        var t = new StringBuilder();
        
        foreach (var value in ValueRegistry)
        {
            t.AppendLine($"{value.Key} : {value.Value} ");
        }

        return t.ToString();
    }
}