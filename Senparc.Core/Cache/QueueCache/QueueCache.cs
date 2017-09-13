﻿/*----------------------------------------------------------------
    Copyright (C) 2017 Senparc

    文件名：QueueCache.cs

    创建标识：Senparc - 20170724

    注意：此项目是《微信开发深度解析：微信公众号、小程序高效开发秘籍》图书中第5章的WeixinMarketing项目源代码。
    本项目只包含了运行案例所必须的学习代码，以及精简的部分SenparcCore框架代码，不确保其他方面的稳定性、安全性，
    因此，请勿直接用于商业项目，例如安全性、缓存等需要根据具体情况进行调试。

    盛派网络保留所有权利。

----------------------------------------------------------------*/


using System;
using System.Collections.Generic;
using Senparc.Core.Extensions;
using System.Linq;
using System.Text;

namespace Senparc.Core.Cache
{
    public interface IQueueCache<T>
    {
        List<QueueCacheData<T>> MessageQueue { get; set; }
        Dictionary<string, QueueCacheData<T>> MessageCollection { get; set; }
        string CreateKey();
        /// <summary>
        /// 插入缓存
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="key">如果为null将自动生成16位Guid</param>
        /// <returns></returns>
        string Insert(T obj, string key);
        QueueCacheData<T> Get(string key);
        void Remove(string key);
    }

    public class QueueCache<T> : IQueueCache<T>
    {
        private string _cacheKey;
        private int _timeoutSeconds;
        public List<QueueCacheData<T>> MessageQueue { get; set; }
        public Dictionary<string, QueueCacheData<T>> MessageCollection { get; set; }

        public QueueCache(string cacheKey, int timeoutSeconds)
        {
            _cacheKey = cacheKey;
            _timeoutSeconds = timeoutSeconds;
            MessageQueue = MethodCache.GetMethodCache<List<QueueCacheData<T>>>(_cacheKey + "Queue", () => new List<QueueCacheData<T>>(), 9999999);
            MessageCollection = MethodCache.GetMethodCache<Dictionary<string, QueueCacheData<T>>>(_cacheKey + "Collection", () => new Dictionary<string, QueueCacheData<T>>(StringComparer.OrdinalIgnoreCase), 9999999);
        }


        /// <summary>
        /// 获取MessageContext，如果不存在，返回null
        /// 这个方法的更重要意义在于操作TM队列，及时移除过期信息，并将最新活动的对象移到尾部
        /// </summary>
        /// <param name="key">用户名（OpenId）</param>
        /// <returns></returns>
        private QueueCacheData<T> GetMessageContext(string key)
        {
            //检查并移除过期记录，为了尽量节约资源，这里暂不使用独立线程轮询
            while (MessageQueue.Count > 0)
            {
                var firstMessageContext = MessageQueue[0];
                var timeSpan = DateTime.Now - firstMessageContext.LastActiveTime;
                if (timeSpan.TotalSeconds >= _timeoutSeconds)
                {
                    MessageQueue.RemoveAt(0);//从队列中移除过期对象
                    MessageCollection.Remove(firstMessageContext.Key);//从集合中删除过期对象
                }
                else
                {
                    break;
                }
            }

            /* 
             * 全局只有在这里用到MessageCollection.ContainsKey
             * 充分分离MessageCollection内部操作，
             * 为以后变化或扩展MessageCollection留余地
             */
            if (!MessageCollection.ContainsKey(key))
            {
                return null;
            }

            return MessageCollection[key];
        }

        private QueueCacheData<T> GetMessageContext(string key, bool createIfNotExists)
        {
            var messageContext = GetMessageContext(key);

            if (messageContext == null)
            {
                if (createIfNotExists)
                {
                    //全局只在这一个地方使用MessageCollection[Key]写入
                    MessageCollection[key] = new QueueCacheData<T>(key);
                    messageContext = GetMessageContext(key);
                    //插入列队
                    MessageQueue.Add(messageContext); //最新的排到末尾
                }
                else
                {
                    return null;
                }
            }
            return messageContext;
        }

        public virtual string CreateKey()
        {
            return Guid.NewGuid().ToString("n").Substring(0, 16);
        }

        public virtual string Insert(T obj,string key)
        {
            //检查并移除过期记录，为了尽量节约资源，这里暂不使用独立线程轮询
            //while (MessageQueue.Count > 0)
            //{
            //    var firstMessageContext = MessageQueue[0];
            //    var timeSpan = DateTime.Now - firstMessageContext.LastActiveTime;
            //    if (timeSpan.TotalSeconds >= _timeoutSeconds)
            //    {
            //        MessageQueue.RemoveAt(0);//从队列中移除过期对象
            //        MessageCollection.Remove(firstMessageContext.Key);//从集合中删除过期对象
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            while (key.IsNullOrEmpty() || MessageCollection.ContainsKey(key))
            {
                key = CreateKey();
            }

            var messageContext = GetMessageContext(key, true);
            messageContext.Data = obj;

            var messageContextInQueue = MessageQueue.IndexOf(messageContext);
            if (MessageQueue.Count > 1 && messageContextInQueue != MessageQueue.Count - 1)
            {
                //如果不是新建的对象，把当前对象移到队列尾部（新对象已经在底部）
                MessageQueue.RemoveAt(messageContextInQueue); //移除当前对象
                MessageQueue.Add(messageContext); //插入到末尾
            }

            messageContext.LastActiveTime = DateTime.Now;//记录请求时间
            return key;
        }

        public virtual QueueCacheData<T> Get(string key)
        {
            return GetMessageContext(key);
        }

        public virtual void Remove(string key)
        {
            try
            {
                var messageContext = GetMessageContext(key, true);
                MessageQueue.Remove(messageContext);
                MessageCollection.Remove(key);
            }
            catch (Exception)
            {
            }
        }
    }
}
