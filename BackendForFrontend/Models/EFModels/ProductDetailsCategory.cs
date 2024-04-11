﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

public partial class ProductDetailsCategory
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    public int? DiscountDegree { get; set; }

    [InverseProperty("DetailsCategory")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}