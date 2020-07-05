using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tarea6RegistroDetalle2.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public int Inventario
        {
            get; set;
        }
    }
}
