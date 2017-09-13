﻿/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc

    文件名：SenparcExpressionModifier.cs

    创建标识：Senparc - 20170724

    注意：此项目是《微信开发深度解析：微信公众号、小程序高效开发秘籍》图书中第5章的WeixinMarketing项目源代码。
    本项目只包含了运行案例所必须的学习代码，以及精简的部分SenparcCore框架代码，不确保其他方面的稳定性、安全性，
    因此，请勿直接用于商业项目，例如安全性、缓存等需要根据具体情况进行调试。

    盛派网络保留所有权利。

----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Senparc.Utility
{
    public class SenparcExpressionModifier<TEntity> : ExpressionVisitor
    {
        public BinaryExpression BE { get; set; }

        public SenparcExpressionModifier()
        { }

        public ReadOnlyCollection<Expression> AndAlso(IList<Expression> expressions)
        {
            ReadOnlyCollection<Expression> col = new ReadOnlyCollection<Expression>(expressions);
            var result = Visit(col);
            return result;
        }

        public Expression<Func<TEntity, bool>> BuildWhereExpression()
        {
            ParameterExpression pe = Expression.Parameter(typeof(string), "z");

            Expression<Func<TEntity, bool>> where = Expression.Lambda<Func<TEntity, bool>>(BE, pe);
            return where;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.IsLifted)
            {
                return base.VisitBinary(b);
            }
            if (BE == null)
            {
                BE = b;
            }
            else
            {
                //默认为添加And
                BE = Expression.MakeBinary(ExpressionType.AndAlso, BE, b);
            }

            return base.VisitBinary(b);
        }
    }
}