﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

public partial class BookReview
{
    [Key]
    public int ReviewID { get; set; }

    public int MemberID { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReviewTime { get; set; }

    [Required]
    public string Content { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string Rating { get; set; }

    public bool IsSpoiler { get; set; }

    [ForeignKey("MemberID")]
    [InverseProperty("BookReviews")]
    public virtual Member Member { get; set; }
}