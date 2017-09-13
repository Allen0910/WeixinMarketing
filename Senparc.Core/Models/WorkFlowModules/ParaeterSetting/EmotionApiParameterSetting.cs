﻿/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc

    文件名：EmotionApiParameterSetting.cs

    创建标识：Senparc - 20170724

    注意：此项目是《微信开发深度解析：微信公众号、小程序高效开发秘籍》图书中第5章的WeixinMarketing项目源代码。
    本项目只包含了运行案例所必须的学习代码，以及精简的部分SenparcCore框架代码，不确保其他方面的稳定性、安全性，
    因此，请勿直接用于商业项目，例如安全性、缓存等需要根据具体情况进行调试。

    盛派网络保留所有权利。

----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senparc.Core.Models.WorkFlowModules
{
    /// <summary>
    /// 工作流参数
    /// </summary>
    [Serializable]
    public class EmotionApiParameterSetting : BaseParameterSetting
    {
        public EmotionApiParameterSetting(string name, object value) : base(ParameterSettingType.Number, name, value)
        {
        }

        public EmotionApiParameterSetting(string name, object value, ParameterSettingShowType showType) : base(ParameterSettingType.Number, showType, name, value)
        {
        }
    }
}