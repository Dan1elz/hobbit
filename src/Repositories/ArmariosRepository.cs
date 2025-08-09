using Hobbit.src.Infrastructure;
using Hobbit.src.Interfaces;
using Hobbit.src.Models;
using Hobbit.src.Repositories.Base;

namespace Hobbit.src.Repositories;
public class ArmariosRepository(ApplicationDbContext context) : BaseRepository<Armarios>(context), IArmariosRepository
{ 
}
