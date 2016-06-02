﻿using System;
using System.ComponentModel.DataAnnotations;
using Domain.Core.Entities.Enums;

namespace Domain.Core.Entities.Validation
{
    public interface IPaciente
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Campo Obligatorio")]
        [StringLength(8, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.", MinimumLength = 7)]
        string Dni { get; set; }

        [StringLength(400, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Domicilio { get; set; }

        [StringLength(25, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Telefono { get; set; }

        [StringLength(250, ErrorMessage = "El campo {0} no debe superar los {1} caracteres.")]
        string Cecular { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        DateTime FechaNacimiento { get; set; }

        [EnumDataType(typeof(Sexo))]
        Sexo Sexo { get; set; }

        [EnumDataType(typeof(GrupoSanguineo))]
        GrupoSanguineo GrupoSanguineo { get; set; }

        [EnumDataType(typeof(EstadoCivil))]
        EstadoCivil EstadoCivil { get; set; }
    }
}
