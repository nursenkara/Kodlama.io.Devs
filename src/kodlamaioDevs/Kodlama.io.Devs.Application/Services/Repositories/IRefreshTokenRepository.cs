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
    /// Token Yenileme Metotlarının imzasını tutar.
    /// </summary>
    public interface IRefreshTokenRepository: IAsyncRepository<RefreshToken>, IRepository<RefreshToken>
    {
    }
}
