using System.ComponentModel;

namespace Manufacture.BusinessLogic;

public static class GetDisplayNameExtension
{
    public static string GetDisplayName(this Type type)
    {
        var displayNameAttribute = type.GetCustomAttributes(typeof(DisplayNameAttribute), false)
            .OfType<DisplayNameAttribute>()
            .FirstOrDefault();

        return displayNameAttribute?.DisplayName ?? type.Name;
    }
}