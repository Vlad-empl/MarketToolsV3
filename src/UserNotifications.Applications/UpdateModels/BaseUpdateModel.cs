﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserNotifications.Domain.Entities;

namespace UserNotifications.Applications.UpdateModels
{
    public abstract record BaseUpdateModel
    {
        public Expression<Func<Notification, bool>>? Filter { get; init; }
    }
}
