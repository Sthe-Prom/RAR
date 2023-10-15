using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Interfaces
{
    public interface IDriverInformation
    {
        IEnumerable<DriverInformation> DriverInformationList { get; }

        Task SaveDriverInformation(DriverInformation DriverInformation);

        DriverInformation DeleteDriverInformation(int DriverInformation);
    }
}