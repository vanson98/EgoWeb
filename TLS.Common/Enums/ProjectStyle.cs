using System;
using System.Collections.Generic;
using System.Text;
using TLS.Common.Enums.EnumAttribute;

namespace TLS.Common.Enums
{
    public enum ProjectStyle
    {
        [EnumDisplayName(DisplayName ="Châu á")]
        ASIAN = 1,
        [EnumDisplayName(DisplayName ="Cổ điển")]
        CLASSIC = 2,
        [EnumDisplayName(DisplayName ="Hiện đại")]
        MODERN = 3,
        [EnumDisplayName(DisplayName ="Tân cổ điển")]
        NEOCLASSICAL = 4
    }
}
