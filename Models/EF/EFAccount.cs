// using rar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rar.Interfaces;
using rar.Models;
using rar.Models.Repositories;

namespace rar.Models
{
    public class EFAccount : IAccount
    {
        public AppDbContext context;

        public IEnumerable<Account> Accounts => context.Account;

        public EFAccount(AppDbContext ctx)
        {
            context = ctx;
        }

        public async Task SaveAccount(Account Account)
        {
            if (Account.AccountID == 0)
            {
                context.Account.Add(Account);
            }
            else
            {
                Account dbEntry = context.Account
                    .FirstOrDefault(c => c.AccountID == Account.AccountID);

                if (dbEntry != null)
                {
                    dbEntry.Name = Account.Name;
                    dbEntry.Surname = Account.Surname;
                    dbEntry.Email = Account.Email;
                    dbEntry.Cell = Account.Cell;
                    dbEntry.ProfileImg = Account.ProfileImg;
                    dbEntry.Id = Account.Id;                   
                    dbEntry.IdentityDoc = Account.IdentityDoc;                   
                    dbEntry.FullAddress = Account.FullAddress;
                    dbEntry.MarriageDoc = Account.MarriageDoc;
                    dbEntry.MaritalStatus = Account.MaritalStatus;
                }
            }

            context.SaveChanges(); //commit to db

        }

        public Account DeleteAccount(int AccountID)
        {
            Account dbEntry = context.Account
                .FirstOrDefault(c => c.AccountID == AccountID);

            if (dbEntry != null)
            {
                context.Account.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }

    }
}
