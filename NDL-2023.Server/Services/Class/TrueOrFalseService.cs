using NDL_2023.Server.Data;
using NDL_2023.Server.Data.Tables;
using NDL_2023.Server.Services.Interfaces;

namespace NDL_2023.Server.Services.Class;

public class TrueOrFalseService: ITrueOrFalseService
{
    private readonly EntityContext _context;

    public TrueOrFalseService(EntityContext context)
    {
        _context = context;
    }

    public TrueOrFalse? GetRandomTrueOrFalse(Guid? lastTrueOrFalseId)
    {
        TrueOrFalse?[] tableAsArray = _context.TrueOrFalses.ToArray();
        int nb = tableAsArray.Length;

        TrueOrFalse? randomElement = null;
        bool success = false;
        while (success)
        {
            randomElement = tableAsArray[new Random().Next(1, nb)];
            success = lastTrueOrFalseId is null || randomElement.id.Equals(lastTrueOrFalseId);
        }

        return randomElement;
    }
}