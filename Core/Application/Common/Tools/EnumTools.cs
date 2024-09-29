using Application.Common.Models;

namespace Application.Common.Tools
{
    public static class EnumTools
    {
        public static List<BasicList> GetEnumList<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum))
                       .Cast<TEnum>()
                       .Select(e => new BasicList
                       {
                           Id = Convert.ToInt32(e),
                           Name = e.GetDisplayName()
                       })
                       .ToList();
        }
    }
}
