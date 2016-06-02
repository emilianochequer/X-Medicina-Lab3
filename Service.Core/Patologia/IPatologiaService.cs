using Service.Core.Patologia.DTOs;
using System;
using System.Collections.Generic;


namespace Service.Core.Patologia
{
    public interface IPatologiaService
    {
        void Insert(PatologiaDto patologia);
        void Update(PatologiaDto patologia);
        void Delete(Guid patologiaId);
        PatologiaDto GetById(Guid patologiaId);
        IEnumerable<PatologiaDto> GetByFilter(string cadena);
        IEnumerable<PatologiaDto> GetAll();
    }
}
