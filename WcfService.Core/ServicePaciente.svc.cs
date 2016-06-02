using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Core.DTOs;

namespace WcfService.Core
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServicePaciente : IServicePaciente
    {
        private readonly IServicePaciente _servicePaciente;

        public ServicePaciente(IServicePaciente servicePaciente)
        {
            _servicePaciente = servicePaciente;
        }

        public void Delete(Guid pacienteId)
        {
            _servicePaciente.Delete(pacienteId);
        }

        public IEnumerable<PacienteWcf> GetAll()
        {
            var listaPacientes = _servicePaciente.GetAll();
            return null;

        }

        public IEnumerable<PacienteWcf> GetByFilter(string cadena)
        {
            throw new NotImplementedException();
        }

        public PacienteWcf GetById(Guid pacienteId)
        {
            throw new NotImplementedException();
        }

        public void Insert(PacienteWcf paciente)
        {
            throw new NotImplementedException();
        }

        public void Update(PacienteWcf paciente)
        {
            throw new NotImplementedException();
        }
    }
}
