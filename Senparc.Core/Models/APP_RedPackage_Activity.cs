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
    
    public partial class APP_RedPackage_Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public APP_RedPackage_Activity()
        {
            this.APP_RedPackage_Activity_Award_Log = new HashSet<APP_RedPackage_Activity_Award_Log>();
            this.Orders = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public int State { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public decimal TotalMoney { get; set; }
        public string Rule { get; set; }
        public decimal RemainingMoney { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.DateTime BeginTime { get; set; }
        public System.DateTime AddTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APP_RedPackage_Activity_Award_Log> APP_RedPackage_Activity_Award_Log { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
