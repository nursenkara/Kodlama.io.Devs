using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    /// <summary>
    /// Kullanıcılar için metotların imzalarını tutar.
    /// </summary>
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {
    }
}
