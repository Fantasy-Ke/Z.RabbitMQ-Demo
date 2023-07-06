using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.RabbitMQ.Bus.Options
{
    public class RabbitMQOptions
    {
        /// <summary>
        /// 要连接的端口。 <see cref="AmqpTcpEndpoint.UseDefaultPort"/>
        /// 指示应使用的协议的缺省值。
        /// </summary>
        public int Port { get; set; } = AmqpTcpEndpoint.UseDefaultPort;

        /// <summary>
        /// 地址
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}
