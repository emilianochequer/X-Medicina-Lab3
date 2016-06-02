using System;
using System.Collections.Generic;
using System.Security.Policy;
using Service.Core.Paciente.DTOs;

namespace Service.Core.Paciente
{
    public interface IServicePaciente
    {
        void Insert(PacienteDto paciente);
        void Update(PacienteDto paciente);
        void Delete(Guid pacienteId);
        PacienteDto GetById(Guid pacienteId);
        IEnumerable<PacienteDto> GetByFilter(string cadena);
        IEnumerable<PacienteDto> GetAll();
    }
}
