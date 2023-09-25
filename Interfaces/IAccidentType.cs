using rar.Models.Repositories;

namespace RAR.Interfaces
{
    public interface IAccidentType
    {
        IEnumerable<AccidentType> AccidentTypes { get; }
    }
}