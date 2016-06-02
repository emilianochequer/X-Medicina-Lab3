using Service.Core.Empresa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Empresa
{
    public interface IEmpresaService
    {
        void Insert(EmpresaDto empresa);
        void Update(EmpresaDto empresa);
        void Delete(Guid empresaId);
        EmpresaDto GetById(Guid empresaId);
        IEnumerable<EmpresaDto> GetByFilter(string cadena);
        IEnumerable<EmpresaDto> GetAll();
    }
}
