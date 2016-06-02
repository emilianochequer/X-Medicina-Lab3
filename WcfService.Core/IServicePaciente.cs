using System;
using System.Collections.Generic;
using System.ServiceModel;
using WcfService.Core.DTOs;

namespace WcfService.Core
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServicePaciente
    {
        [OperationContract]
        void Insert(PacienteWcf paciente);
        [OperationContract]
        void Update(PacienteWcf paciente);
        [OperationContract]
        void Delete(Guid pacienteId);
        [OperationContract]
        PacienteWcf GetById(Guid pacienteId);
        [OperationContract]
        IEnumerable<PacienteWcf> GetByFilter(string cadena);
        [OperationContract]
        IEnumerable<PacienteWcf> GetAll();
    }
}
