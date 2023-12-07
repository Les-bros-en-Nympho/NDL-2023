using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NDL_2023.Server.Data.Tables;

namespace NDL_2023.Server.Services.Interfaces;

public interface ITrueOrFalseService
{
    public TrueOrFalse? GetRandomTrueOrFalse(Guid? lastTrueOrFalseId);
}