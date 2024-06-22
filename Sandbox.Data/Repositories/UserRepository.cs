using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Sandbox.Data.Entities;

namespace Sandbox.Data.Repositories;

public class UserRepository(Context c)
{
    public async Task<IEnumerable<T>> Get<T>(Expression<Func<User, T>> select) =>
        await c.Users.Select(select).ToArrayAsync();
}