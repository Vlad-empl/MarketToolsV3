﻿using MarketToolsV3.FakeData.WebApi.Domain.Entities;

namespace MarketToolsV3.FakeData.WebApi.Application.Features.FakeTasks.Services.Abstract
{
    public interface ITaskEntityService
    {
        Task AddAsync(TaskEntity entity);
        Task<TaskEntity?> FindAsync(string id);
    }
}
