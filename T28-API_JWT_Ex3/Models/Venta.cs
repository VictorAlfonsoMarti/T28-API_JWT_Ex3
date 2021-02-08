using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace T28_API_JWT_Ex3.Models
{
    public partial class Venta
    {
        public int Cajero { get; set; }
        public int Maquina { get; set; }
        public int Producto { get; set; }

        public virtual Cajeros CajeroNavigation { get; set; }
        public virtual MaquinasRegistradoras MaquinaNavigation { get; set; }
        public virtual Productos ProductoNavigation { get; set; }
    }
}
