# Z.RabbitMQ-Demo

## 应用通讯

1. 应用程序内部的消息处理和解耦使用 `MediatR`
   1. [MediatR借鉴](https://www.cnblogs.com/yaopengfei/p/16672851.html)
2. 应用程序之间的异步消息传递和解耦使用`RabbitMQ `
   1. [RabbitMQ借鉴](https://www.cnblogs.com/CKExp/p/16533386.html)

## RabbitMQ安装

下载以下内容以使用 RabbitMQ:

[下载并安装 ERLANG 最新版本](https://www.erlang.org/downloads),

[下载并安装 RabbitMQ 最新版本](https://www.rabbitmq.com/download.html)

RabbitMQ默认地址: 

http://localhost:15672/

```
rabbitmq-server           //启动rabbitMQ服务
```

### 目录结构
```
Z.RabbitMQ-Demo
├─ .gitattributes
├─ .gitignore
├─ LICENSE.txt
├─ RabbitMQ.Consumers.API
├────消费者API
├─ RabbitMQ.Producer.API
├────生产者API
├─ README.md
├─ Z.RabbitMQ-Demo.sln
├─ Z.RabbitMQ.Bus
├────基础RabbitMQ发布订阅
├─ Z.RabbitMQ.Consumers.Application
├────消费者Application
├─ Z.RabbitMQ.Consumers.Data
├────消费者Data
├─ Z.RabbitMQ.Consumers.Domain
├────消费者Domain
├─ Z.RabbitMQ.Domain.Core
├────基础类和事件
├─ Z.RabbitMQ.Ioc
├────公用IOC注入
├─ Z.RabbitMQ.Producer.Application
├────生产者Application
├─ Z.RabbitMQ.Producer.Data
├────生产者Data
└─ Z.RabbitMQ.Producer.Domain
├────生产者Domain
```