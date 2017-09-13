//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Senparc.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public Nullable<int> AccountId { get; set; }
        public int ActivityId { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PayMoney { get; set; }
        public System.DateTime CompleteTime { get; set; }
        public Nullable<System.DateTime> GetPayOrderTime { get; set; }
        public byte Status { get; set; }
        public string Description { get; set; }
        public string PrepayId { get; set; }
        public string PrepayCodeUrl { get; set; }
        public int PayType { get; set; }
        public int OrderType { get; set; }
        public string PayParam { get; set; }
        public string AddIp { get; set; }
        public System.DateTime AddTime { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual APP_RedPackage_Activity APP_RedPackage_Activity { get; set; }
    }
}
