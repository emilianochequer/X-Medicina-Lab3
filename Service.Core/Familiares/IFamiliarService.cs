using Service.Core.Familiares.DTOs;
using System;
using System.Collections.Generic;

namespace Service.Core.Familiares
{
    public interface IFamiliarService
    {
        void Insert(FamiliarDto familiar);
        void Update(FamiliarDto familiar);
        void Delete(Guid familiarId);
        FamiliarDto GetById(Guid familiarId);
        IEnumerable<FamiliarDto> GetByFilter(string cadena);
        IEnumerable<FamiliarDto> GetAll();
    }
}
