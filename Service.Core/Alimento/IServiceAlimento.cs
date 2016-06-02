using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Alimento.DTOs;

namespace Service.Core.Alimento
{
    public interface IServiceAlimento
    {
        void Insert(AlimentoDto alimento);
        void Update(AlimentoDto alimento);
        void Delete(Guid alimentoId);
        AlimentoDto GetById(Guid alimentoId);
        IEnumerable<AlimentoDto> GetByFilter(string cadena);
        IEnumerable<AlimentoDto> GetAll();
    }
}
