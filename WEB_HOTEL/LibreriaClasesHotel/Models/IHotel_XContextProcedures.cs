﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using LibreriaClasesHotel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace LibreriaClasesHotel.Models
{
    public partial interface IHotel_XContextProcedures
    {
        Task<int> InsertarDatosReservacionAsync(string ApellidoCliente, string NombreCliente, string DNICliente, string EmailCliente, string TelefonoCliente, int? NumeroHabitacion, DateTime? FechaInicio, int? DiasEstancia, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
