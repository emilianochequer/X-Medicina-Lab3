using Service.Core.MotivoConsulta.DTOs;
using System;
using System.Collections.Generic;

namespace Service.Core.MotivoConsulta
{
     public interface IServiceMotivoConsulta
    {
        void Insert(MotivoConsultaDto motivoConsulta);
        void Update(MotivoConsultaDto motivoConsulta);
        void Delete(Guid motivoConsultaId);
        MotivoConsultaDto GetById(Guid motivoConsultaId);
        IEnumerable<MotivoConsultaDto> GetByFilter(string cadena);
        IEnumerable<MotivoConsultaDto> GetAll();
    }
}
