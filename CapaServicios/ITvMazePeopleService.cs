﻿using CapaDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaServicios
{
    public interface ITvMazePeopleService
    {
        Task<List<People>> ObtenerPeopleAsync();
    }
}
