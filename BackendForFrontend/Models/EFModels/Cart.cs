﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

[Table("Carts", Schema = "Orders")]
[Index("MemberId", Name = "FK_MemberId_uniq", IsUnique = true)]
public partial class Cart
{
    [Key]
    public int Id { get; set; }

    public int MemberId { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal TotalAmount { get; set; }

    [Column(TypeName = "decimal(18, 0)")]
    public decimal? DiscountAmount { get; set; }

    public string Message { get; set; }

    public int? Phone { get; set; }

    public string Address { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    [ForeignKey("MemberId")]
    [InverseProperty("Cart")]
    public virtual Member Member { get; set; }
}