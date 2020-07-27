using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaApi.Business.Interfaces
{
    public interface IUnitOfWork
    {
        IClienteRepository Endereco { get;  }
    }
}
