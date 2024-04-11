﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MinimalAPIs.MinimalAPIs.Models;

[Table("CouponType")]
public partial class CouponType
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    [Unicode(false)]
    public string Type { get; set; }

    [InverseProperty("CouponType")]
    public virtual ICollection<Coupon> Coupons { get; set; } = new List<Coupon>();
}