﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LibreriaClasesHotel.Models;

public partial class Empleado
{
    public int id { get; set; }

    public string apellido { get; set; }

    public string nombre { get; set; }

    public string email { get; set; }

    public string telefono { get; set; }

    public string direccion { get; set; }

    public virtual ICollection<Reservacion> Reservacion { get; set; } = new List<Reservacion>();
}