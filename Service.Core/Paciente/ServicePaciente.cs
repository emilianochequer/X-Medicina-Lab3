using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.Extensions;
using Domain.Base.UnitOfWork;
using Domain.Core.Entities;
using Service.Core.Paciente.DTOs;

namespace Service.Core.Paciente
{
    public class ServicePaciente : Base.ServiceBase, IServicePaciente
    {
        public ServicePaciente(IUnitOfWork uow)
            :base(uow)
        {
        }

        public void Insert(PacienteDto paciente)
        {
            var pacienteNuevo = Mapper.Map<PacienteDto, Domain.Core.Entities.Paciente>(paciente);
            Uow.Repository<Domain.Core.Entities.Paciente>().Insert(pacienteNuevo);
            Uow.Commit();
        }

        public void Update(PacienteDto paciente)
        {
            var pacienteActualizar = Mapper.Map<PacienteDto, Domain.Core.Entities.Paciente>(paciente);
            Uow.Repository<Domain.Core.Entities.Paciente>().Update(pacienteActualizar);
            Uow.Commit();
        }

        public void Delete(Guid pacienteId)
        {
            var pacienteEliminar = Uow.Repository<Domain.Core.Entities.Paciente>().GetById(pacienteId);
            pacienteEliminar.EstaActivo = false;
            Uow.Repository<Domain.Core.Entities.Paciente>().Update(pacienteEliminar);
            Uow.Commit();
        }

        public PacienteDto GetById(Guid pacienteId)
        {
            var paciente = Uow.Repository<Domain.Core.Entities.Paciente>()
                .GetById(pacienteId);

            var pacienteDto = Mapper.Map<Domain.Core.Entities.Paciente, PacienteDto>(paciente);

            return pacienteDto;
        }

        public IEnumerable<PacienteDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Paciente, bool>> pred = x => true;

            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Apellido.Contains(cadena)
                                     || x.Nombre.Contains(cadena)
                                     || x.Dni == cadena
                                     || x.Mail == cadena);

                pred = pred.And(x => x.EstaActivo);
            }

            var listaPacientes = Uow.Repository<Domain.Core.Entities.Paciente>().GetByFilter(pred);

            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Paciente>, IEnumerable<PacienteDto>>(listaPacientes.ToList());

            return listaDto.ToList();
        }

        public IEnumerable<PacienteDto> GetAll()
        {
            var listaPacientes = Uow.Repository<Domain.Core.Entities.Paciente>().GetAll();
            
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Paciente>, 
                IEnumerable<PacienteDto>>(listaPacientes.ToList());

            return listaDto;
        }
    }
}
