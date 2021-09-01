﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }

        public int idVeiculo { get; set; }

        public int idCliente { get; set; }

        public DateTime dataAluguel { get; set; }

        public DateTime dataDevolucao { get; set; }

        public VeiculoDomain veiculo { get; set; }

        public ClienteDomain cliente { get; set; }
    }
}
