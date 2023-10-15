using rar.Models.Repositories;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rar.Interfaces;
using rar.Models;

namespace RAR.Models.EF
{
    public class EFCollision: ICollision
    {
        public AppDbContext context;

        public IEnumerable<Collision> CollisionTypes => context.Collision;
        
        public EFCollision(AppDbContext ctx)
        {
            context = ctx;
        }
    }
}