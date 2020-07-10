using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XGame.Domain.Arguments.Plataforma;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServicePlataforma
    {
        AdicionarPlataformaResponse AdicionarPlataforma(AdicionarPlataformaRequest request);
    }
}
