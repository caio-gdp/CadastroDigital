using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Configuration.Annotations;

namespace CadastroDigital.Domain.Entities
{
    public class Pais : Base
    {
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}