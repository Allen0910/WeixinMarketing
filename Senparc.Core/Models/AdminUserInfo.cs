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
    
    public partial class AdminUserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string RealName { get; set; }
        public int Sex { get; set; }
        public string Phone { get; set; }
        public System.DateTime ThisLoginTime { get; set; }
        public string ThisLoginIP { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public string LastLoginIP { get; set; }
        public string Note { get; set; }
        public System.DateTime AddTime { get; set; }
        public string AddIP { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string UpdateIP { get; set; }
    }
}