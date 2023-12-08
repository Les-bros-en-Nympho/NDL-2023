using System;
using System.Collections.Generic;
using backend.Adapters;
using Microsoft.AspNetCore.Http;
using NDL_2023.Server.Data.Tables;

namespace NDL_2023.Server.Services.Interfaces;

public interface ITrueOrFalseService
{
    public TrueOrFalseSendAdapter? GetRandomTrueOrFalse(Guid? lastTrueOrFalseId);
    public TrueOrFalse GetTrueOrFalse(Guid id);
    public bool GuessTrueOrFalse(Guid lastTrueOrFalseId, bool response);
}