namespace CMI.Model.Extensions;
public static class PageParam_Ex
{
    public static bool TryHasFilter(this PageParams pageParams, string key, out string value)
    {
        value = default!;
        var filter = pageParams.FilterParams.FirstOrDefault(x => string.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));
        if (filter is not null && filter.Value != "-1")
        {
            pageParams.FilterParams.Remove(filter);
            value = filter.Value;
            return true;
        }
        return false;
    }
}