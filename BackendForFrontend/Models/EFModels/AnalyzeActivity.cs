﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

[Table("AnalyzeActivity")]
public partial class AnalyzeActivity
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal SalesGrowthRate { get; set; }
}