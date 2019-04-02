using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Application.Tag
{
    public interface ITagService
    {
        List<TagResponse> GetAll();
        int Create(TagRequest request);
    }
}
