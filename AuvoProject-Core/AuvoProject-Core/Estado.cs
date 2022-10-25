using System;
using System.Collections.Generic;

namespace AuvoProject_Core
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Uf { get; set; } = null!;

        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
