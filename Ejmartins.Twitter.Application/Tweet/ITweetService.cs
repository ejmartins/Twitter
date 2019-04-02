using System;
using System.Collections.Generic;
using System.Text;

namespace Ejmartins.Twitter.Application.Tweet
{
    public interface ITweetService
    {
        List<TweetResponse> GetAll();
        void Create(List<TweetRequest> request);

        int Create(TweetRequest request);

    }
}
