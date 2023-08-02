using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Interfaces
{
    public interface IAccount
    {
        IEnumerable<Account> Accounts { get; }

        Task SaveAccount(Account Account);

        Account DeleteAccount(int AccountID);
    }
}
