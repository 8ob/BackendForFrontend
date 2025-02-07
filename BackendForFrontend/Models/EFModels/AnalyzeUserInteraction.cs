﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

public partial class AnalyzeUserInteraction
{
    [Key]
    public int ID { get; set; }

    public int MemberID { get; set; }

    public int BookID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime InteractionDate { get; set; }

    [Required]
    [StringLength(50)]
    public string InteractionType { get; set; }

    [ForeignKey("BookID")]
    [InverseProperty("AnalyzeUserInteractions")]
    public virtual Product Book { get; set; }

    [ForeignKey("MemberID")]
    [InverseProperty("AnalyzeUserInteractions")]
    public virtual Member Member { get; set; }
}