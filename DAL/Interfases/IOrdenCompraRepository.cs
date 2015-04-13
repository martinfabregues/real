﻿using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Interfases
{
    public interface IOrdenCompraRepository :IRepository<OrdenCompra>
    {
        OrdenCompra GetByIdWithDetalle(int id);
        IList<OrdenCompra> BusquedaCondicional(string numero, int? proveedor_id, DateTime? desde, DateTime? hasta);
    }
}