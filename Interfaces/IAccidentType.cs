using rar.Models.Repositories;

namespace rar.Interfaces
{
    public interface IAccidentType
    {
        IEnumerable<AccidentType> AccidentTypes { get; }
    }
}