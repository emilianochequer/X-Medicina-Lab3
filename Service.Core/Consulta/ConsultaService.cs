using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Consulta.DTOs;
using Domain.Base.UnitOfWork;
using System.Linq.Expressions;
using Application.Extensions;

namespace Service.Core.Consulta
{
    public class ConsultaService : Base.ServiceBase, IConsultaService
    {
        public ConsultaService(IUnitOfWork uow)
            : base(uow)
        {
                
        }        

        public ConsultaDto Details(Guid consultaId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConsultaDto> GetAll()
        {
            var listaconsulta = Uow.Repository<Domain.Core.Entities.Consulta>().GetAll();
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Consulta>, IEnumerable<ConsultaDto>>(listaconsulta.ToList());
            return listaDto;
        }

        public IEnumerable<ConsultaDto> GetByFilter(string cadena)
        {
            Expression<Func<Domain.Core.Entities.Consulta, bool>> pred = x => false;
            if (!string.IsNullOrEmpty(cadena))
            {
                pred = pred.And(x => x.Paciente.Apellido.Contains(cadena)
                                || x.Paciente.Nombre.Contains(cadena)
                                || x.Paciente.Dni.Contains(cadena));
            }
            var listaConsulta = Uow.Repository<Domain.Core.Entities.Consulta>().GetByFilter(pred);
            var listaDto = Mapper.Map<IEnumerable<Domain.Core.Entities.Consulta>, IEnumerable<ConsultaDto>>(listaConsulta.ToList());
            return listaDto.ToList();
        }

        public ConsultaDto GetById(Guid consultaId)
        {
            var listaConsulta = Uow.Repository<Domain.Core.Entities.Consulta>().GetById(consultaId);

            var listaDto = Mapper.Map<Domain.Core.Entities.Consulta,
                ConsultaDto>(listaConsulta);
            return listaDto;
        }

        public void Insert(ConsultaDto consulta)
        {
            var consultaInsertar = Mapper.Map<ConsultaDto, Domain.Core.Entities.Consulta>(consulta);
            consultaInsertar.IMC = consultaInsertar.Peso / (consultaInsertar.Talle) * (consultaInsertar.Talle);
            consultaInsertar.IndiceCaderaCintura = consultaInsertar.Cintura / consultaInsertar.Cadera;
            if (consultaInsertar.Paciente.Sexo == Domain.Core.Entities.Enums.Sexo.Masculino)
            {
                consultaInsertar.IndiceGrasaCorporal = (1.20m * consultaInsertar.IMC) + (0.23m * consultaInsertar.Paciente.Edad) + (10.8m * 1) - 5.4m;
            }
            else
            {
                consultaInsertar.IndiceGrasaCorporal = (1.20m * consultaInsertar.IMC) + (0.23m * consultaInsertar.Paciente.Edad) + (10.8m * 0) - 5.4m;
            }
            consultaInsertar.PesoIdeal = (50 + 0.75m) * (consultaInsertar.Talle - 150);
            Uow.Repository<Domain.Core.Entities.Consulta>().Insert(consultaInsertar);
            Uow.Commit();
        }

    }
}
