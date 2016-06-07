using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Core.Consulta.DTOs;

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

            Uow.Repository<Domain.Core.Entities.Consulta>().Insert(consultaInsertar);
            Uow.Commit();
        }

    }
}
