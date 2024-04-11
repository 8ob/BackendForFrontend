﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BackendForFrontend.Models.EFModels;

[Table("EcpayOrders", Schema = "Orders")]
public partial class EcpayOrder
{
    [Key]
    [StringLength(50)]
    public string MerchantTradeNo { get; set; }

    [Required]
    [StringLength(50)]
    public string MemberID { get; set; }

    public int? RtnCode { get; set; }

    [StringLength(50)]
    public string RtnMsg { get; set; }

    [Required]
    [StringLength(50)]
    public string TradeNo { get; set; }

    public int? TradeAmt { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PaymentDate { get; set; }

    [StringLength(50)]
    public string PaymentType { get; set; }

    [StringLength(50)]
    public string PaymentTypeChargeFee { get; set; }

    [StringLength(50)]
    public string TradeDate { get; set; }

    public int? SimulatePaid { get; set; }
}