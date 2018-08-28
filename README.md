# AOP 面向切面

## 简述
>AOP 是 Aspect-Oriented programming 的缩写，中文翻译为面向切面编程，它是OOP（Object-Oriented Programing，面向对象编程）的补充和完善。它和OOP一样是一种编程思想。

## 概念点
* 横切（cross-cutting）：与对象核心功能无关的公共行为
* 关注点（concern）：一块我们感兴趣的区域
* 方面（Aspect）：就是将那些与业务无关，却为业务模块所共同调用的逻辑或*责任封装起来，便于减少系统的重复代码，降低模块间的耦合度，并有利于未来的可操作性和可维护性。
* 连接点（join point）：是程序执行中一个精确执行点，例如类中的一个方法。它是一个抽象的概念，在实现AOP时，并不需要去定义一个连接点。
* 切入点（point cut）：本质是一个捕获连接点的结构。在AOP中，可以定义一个切入点来捕获相关方法的调用。
* 通知（advice）：是“切入点”的执行方代码，是执行“方面”的具体逻辑
* 引入（introduce）：为对象引入附加的方法或属性，从而达到修改对象结构的目的


>AOP把软件系统分为两个部分：核心关注点和横切关注点。业务处理的主要流程部分是核心关注点，与之关系不大的部分是横切关注点。AOP的作用在于分离系统中各种关注点，将核心关注点和横切关注点分离开来。

## AOP实现方式
1. 动态代理（Dynamic Proxy）利用截取消息的方式，对该消息进行装饰，以取代原有对象行为的执行。一般通过Emit来动态的创建代理类。
2. 静态织入（AspectJ）通过引入特定的语法来创建“方面”，从而在编译期间就织入了“方面”的代码。目前这种实现方式，都是对编译器扩展，这种实现方式性能是最好的。

AOP用来封装横切关注点，具体可以在下面的场景中使用:
* Authentication 权限
* Caching 缓存
* Context passing 内容传递
* Error handling 错误处理
* Lazy loading 懒加载
* Debugging 调试
* logging, tracing, profiling and monitoring 记录跟踪 优化 校准
* Performance optimization 性能优化
* Persistence 持久化
* Resource pooling 资源池
* Synchronization 同步
* Transactions 事务
