using Syncfusion.Maui.DataSource.Extensions;

namespace ListViewNestedBinding.Models;

public sealed class ThemeComparer: IComparer<GroupResult>
{
    public ThemeComparer()
    {
    }

    public int Compare(GroupResult x, GroupResult y)
    {
        string left = x.Key.ToString();
        string right = y.Key.ToString();

        bool leftIsNone = string.IsNullOrEmpty(left) || StringComparer.Ordinal.Compare(left, Meta.DefaultTheme) == 0;
        bool rightIsNone = string.IsNullOrEmpty(right) || StringComparer.Ordinal.Compare(right, Meta.DefaultTheme) == 0;    

        if (leftIsNone && rightIsNone)
        {
            return 0;
        }
        else if (leftIsNone)
        {
            return 1;
        }
        else if (rightIsNone)
        {
            return -1;
        }
        return StringComparer.Ordinal.Compare(left, right);
   }
}
