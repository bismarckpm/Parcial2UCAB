using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2UCAB.BussinesLogic.DTOs
{
    public class BrandDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ProviderDTO> Providers { get; set; }
    }
}
