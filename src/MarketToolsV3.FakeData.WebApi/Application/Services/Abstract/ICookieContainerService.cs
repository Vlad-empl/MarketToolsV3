﻿using System.Net;

namespace MarketToolsV3.FakeData.WebApi.Application.Services.Abstract
{
    public interface ICookieContainerService
    {
        Task<CookieContainer> CreateByTask(string id);
        Task RefreshByTask(string id, CookieContainer container);
    }
}
