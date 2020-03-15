using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScriptsBookmark.DAL.Common
{
    public interface IBookmark
    {
        Guid BookmarkId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Code { get; set; }
    }
}
