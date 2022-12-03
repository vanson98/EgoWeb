using System;
using System.Collections.Generic;
using System.Text;
using TLS.Common.Enums.EnumAttribute;

namespace TLS.Common.Enums
{
    public enum ProjectType
    {
        [EnumDisplayName(DisplayName = "Villa")]
        VILLA = 1,
        [EnumDisplayName(DisplayName = "Gia đình")]
        FAMILY = 2,
        [EnumDisplayName(DisplayName = "Kinh doanh")]
        BUSINESS = 3,
        [EnumDisplayName(DisplayName = "Nghỉ dưỡng - Homestay")]
        RESORT_HOMESTAY = 4
    }
}
