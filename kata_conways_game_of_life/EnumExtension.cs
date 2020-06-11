using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace kata_conways_game_of_life
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum GenericEnum)
        {
            Type genericEnumType = GenericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
            if((memberInfo.Length <= 0)) return GenericEnum.ToString();
            object[] attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attribs.Any() ? ((DescriptionAttribute) attribs.ElementAt(0)).Description : GenericEnum.ToString();
        }
    }
    
}