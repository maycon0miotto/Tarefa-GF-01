﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRV.Modas
{
    public class ClienteModel
    {
        public long? ClienteID { get; set; }
        public Guid ClienteIDGUID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public static readonly List<ClienteModel> clientes = new List<ClienteModel>();

        public string NomeCompleto
        {
            get
            {
                return $"{Nome} {Sobrenome}";
            }
        }
    }
}