﻿using API.LuizaLabs.Domain.Models;
using System;

namespace API.LuizaLabs.Domain.Core.Service
{
    public interface IServiceCliente : IServiceBase<Cliente>, IDisposable
    {
        Product GetByEmail(string email);
    }
}
