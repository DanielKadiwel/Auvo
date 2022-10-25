using System;
using System.Collections.Generic;

namespace AuvoProject_Core
{
    public partial class Cidade
    {
        public Cidade()
        {
            PrevisaoClimas = new HashSet<PrevisaoClima>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; } = null!;
        public virtual ICollection<PrevisaoClima> PrevisaoClimas { get; set; }
    }
}
