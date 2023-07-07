# Z.RabbitMQ-Demo

## 应用通讯

1. 应用程序内部的消息处理和解耦使用 `MediatR`
2. 应用程序之间的异步消息传递和解耦使用`RabbitMQ `


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