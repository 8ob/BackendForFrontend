﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

public partial class AnalyzeSale
{
    [Key]
    public int ID { get; set; }

    public long DateRange { get; set; }

    public int BookID { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal Total { get; set; }

    [ForeignKey("BookID")]
    [InverseProperty("AnalyzeSales")]
    public virtual Product Book { get; set; }
}