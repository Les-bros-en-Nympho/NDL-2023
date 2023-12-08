using backend.Adapters;
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

    public TrueOrFalseSendAdapter? GetRandomTrueOrFalse(Guid? lastTrueOrFalseId)
    {
        int nb = _context.TrueOrFalses.Count();

        TrueOrFalse? randomElement = null;
        bool success = false;
        while (!success)
        {
            randomElement = _context.TrueOrFalses.ElementAt(new Random().Next(1, nb));
            success = lastTrueOrFalseId is null || !randomElement.id.Equals(lastTrueOrFalseId);
        }

        return new TrueOrFalseSendAdapter
        {
            id = randomElement.id,
            statement = randomElement.statement
        };
    }

    private TrueOrFalse FindTrueOrFalse(Guid id)
    {
        return _context.TrueOrFalses.First(tof => tof.id == id);
    }

    public TrueOrFalse GetTrueOrFalse(Guid id)
    {
        return FindTrueOrFalse(id);
    }

    public bool GuessTrueOrFalse(Guid id, bool response)
    {
        return FindTrueOrFalse(id).true_or_false == response;
    }
}