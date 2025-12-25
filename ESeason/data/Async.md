# .NET 多线程



## C# 多线程入门概念

**什么是线程安全**

* 线程安全: 多个线程访问共享资源时, 对共享资源的访问不会导致数据不一致或不可预期的结果
* 同步机制: 保证线程安全(互斥 就是加锁, 改并行为串行)
  * 用于协调和控制多个线程之间执行顺序和互斥访问共享资源
  * 确保线程按照特定的顺序执行, 避免竞态条件和数据不一致的问题
* 原子操作: 保证线程安全 (底层提供的原子类实现的 ++ --)
  * 在执行过程中不会被终端的操作. 不可分割, 要么完全执行, 要么完全不执行, 没有中间状态
  * 在多线环境下, 原子操作能够保证数据的一致性和可靠性, 避免出现竞态条件和数据竞争的问题



**常用实现方式**

* 线程
* 线程池
* 异步编程
* 自带方法
  * Parallel: `For, ForEach, Invoke`
  * PLINQ: `AsParallel, AsSequential, AsOrdered`



## 线程Thread

**线程的创建**

* 创建Thread实例, 并传入ThreadStart委托, `还可以配置线程, 如是否为后台线程`
* 调用`Thread.Start`方法还可以传参



**线程的中止**

* 调用`Thread.Join`方法, 等待线程的结束
* 调用`Thread.Interrupt`方法, 中断线程的执行
  * 会在相应线程中抛出`ThreadInterruptedException`
  * 如果线程中包含一个`while(true)`循环, 那么需要保证包含等待方法, 如IO操作, `Thread.Sleep`等

* 不能用Abort?
  * 使用`Abort`方法来强制终止线程可能导致一些严重的问题, 包括资源泄露和不可预测的行为
  * 较新版本的 .NET 中如果使用这个方法, 会报`PlatformNotSupportedException`
  * 推荐使用`Thread.Interrupt`或`CancellationToken`
  * 我的补充: 我记得学习Java多线程时, 老师是建议使用标志位 `while(flag)`线程自己通过flag控制



**线程的挂起和恢复**

* `Thread.Suspend`以及`Thread.Resume`
* 较新版本的 .NET 中这两个方法已经被标记为 Obsolete, 且调用会报错
* 推荐使用锁, 信号量等方式实现这一逻辑



## 线程安全和同步机制 Thread-Safety

**原子操作**

* 上文做过介绍, 不过多阐述



**锁与信号量**

* lock & Monitor
* Mutex
* Semaphore
* WaitHandle
  * ManualResetEvent
  * AutoResetEvent

* ReaderWriterLock



**轻量型**

* SemaphoreSlim
* ManualResetEventSlim
* ReaderWriterLockSlim



**不要自己造轮子**

* 线程安全的单例 Lazy
* 线程安全的集合类型 `ConcurrentBag, ConcurrentStack, ConcurrentQuery, ConcurrentDictionary`
* 阻塞集合 `BlockingCollection`
* 通道 `Channel`
* 原子操作 `Interlocked`
* 周期任务`PeriodicTimer`





# .NET 异步编程

























