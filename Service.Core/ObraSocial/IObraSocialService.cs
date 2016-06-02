using Service.Core.ObraSocial.DTOs;
using System;
using System.Collections.Generic;

namespace Service.Core.ObraSocial
{
    public interface IObraSocialService
    {
        void Insertar(ObraSocialDto obraSocial);
        void Update(ObraSocialDto obraSocial);
        void Delete(Guid obraSocialId);
        ObraSocialDto GetById(Guid obraSocialId);
        IEnumerable<ObraSocialDto> GetByFilter(string cadena);
        IEnumerable<ObraSocialDto> GetAll();
    }
}
