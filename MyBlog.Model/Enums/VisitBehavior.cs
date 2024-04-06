using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.Enums
{
    /// <summary>
    /// 访问行为枚举类
    /// </summary>
    public enum VisitBehavior
    {
        UNKNOWN,
        INDEX,
        ARCHIVE,
        MOMENT,
        FRIEND,
        ABOUT,
        BLOG,
        CATEGORY,
        TAG,
        SEARCH,
        CLICK_FRIEND,
        LIKE_MOMENT,
        CHECK_PASSWORD
    }
}
