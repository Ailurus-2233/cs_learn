# 第21节 异步编程

## 1. 什么是异步
启动一个程序，系统在内存中创建一个新进程，进程内部是系统创建的线程，线程可以派生其他线程，这就有了多线程。进程内的多个线程共享进程的资源，系统为处理器规划的单元是线程。异步编程可以实现在新线程里面运行一部分代码，或改变代码的执行顺序。如需要I/O绑定（网络请求、访问数据库或文件读写）这种情况下，使用异步编程会有较好的实现。

本节主要介绍集中异步的实现方式，其中包括：`async/await`、`BackgroundWorker`、`Task Parellel`、`BeginInvoke/EndInvoke`以及`System.Threading.Timer`。

在GUI编程中，如WPF，一些事件的相应往往是需要使用异步编程的，例如：点击一个按钮，需要执行一个耗时的操作，这时候就需要使用异步编程，否则会导致界面卡死。

### 1.1 线程与进程

启动程序时，系统会在内存中创建一个新的进程。进程是构成运行程序的资源集合。包括虚地址空间、文件句柄和许多其他程序运行所需的东西。在进程内部，系统创建了一个称为线程的内核对象，它代表了真正执行的程序。一旦进程建立，系统会在Main方法的第一行语句处就开始线程的执行。

关于线程，需要了解以下知识点

1. 默认情况下，一个进程只包含一个线程，从程序的开始一直执行到结束
2. 线程可以派生其他线程，因此在任意时刻，一个进程都可能包含不同状态的多个线程，来执行程序的不同部分
3. 如果一个进程拥有多个线程，它们将共享进程的资源
4. 系统为处理器执行所规划的单元是线程，不是进程

如果只有一个线程的话，那么程序的执行顺序就是按照代码的顺序执行，这种方式称为同步编程。但是这种编程方式可能会导致一些难以接受的问题，例如：当进行一个网络请求时，程序会等待网络请求的结果，假如请求量大或者请求时间长，这样会导致程序的执行被阻塞，这种情况最好将网络请求的代码放在一个新的线程中执行，这样就不会阻塞主线程的执行，这也就是异步编程的好处。

## 2. 异步编程

### 2.1 async/await

基本使用方法是

``` c#
// 在声明方法的时候，使用async关键字 方法的返回类型应该是void Task 或者 Task<T>
public async Task<string> GetHtmlAsync(string url)
{
	// 使用await关键字，等待异步方法执行完成
	var html = await GetHtmlAsync(url);
	return html;
}

// 在其他方法中，调用异步方法
Task<string> html = GetHtmlAsync("http://www.baidu.com");
// 其他语句...
// 使用异步方法的返回值，如果没有执行完毕，则会等待异步方法执行完成
Console.WriteLine(html.Result);
```

`async/await`有以下的注意事项：
1. 异步方法在方法头中必须包含`async`关键字，且必须出现在返回类型之前
2. 该修饰符只是标识该方法包含一个或多个`await`表达式。也就是说，它本身并不能创建任何异步操作。
3. `async`关键字是一个上下文关键字，也就是说除了作为方法修饰符（或Lambda表达式修饰符、匿名方法修饰符）之外，async还可用作标识符
4. 如果`await`未用在`async `法的主体中，C# 编译器将生成一个警告，但此代码将会以类似普通方法的方式进行编译和运行。 
5. 添加“Async”作为编写的每个异步方法名称的后缀。(.Net惯例)
6. `async void`应仅用于事件处理程序，因为事件不具有返回类型（因此无法利用`Task`和`Task<T>`）。 其他任何对 `async void`的使用都不遵循 TAP 模型，且可能存在一定使用难度。

关于返回值，有以下几种情况：

* **`Task<T>`** 如果调用方法要从调用中获取一个`T`类型的值，异步方法的返回类型就必须是`Task<T>`。调用方法将通过读取`Task`的`Result`属性来获取这个T类型的值。
* **`Task`** 如果调用方法不需要从调用中获取一个值，但需要检査异步方法的状态，异步方法的返回类型就可以是`Task`。可以用`Task.Wait(	)`来等待异步方法完成。
* **`void`** 如果调用方法仅仅想执行异步方法，而不需要与它做任何进一步的交互时，异步方法可以返回void类型。这时，与上一种情况类似，即使异步方法中包含任何return语句，也不会返回任何东西。
* 任何返回`Task<T>`类型的异步方法其返回值必须为`T`类型或可以隐式转换为`T`的类型

### 2.2 await 详解
`await` 运算符暂停对其所属的 `async` 方法的求值，直到其操作数表示的异步操作完成。 异步操作完成后，`await` 运算符将返回操作的结果（如果有）。 当 `await` 运算符应用到表示已完成操作的操作数时，它将立即返回操作的结果，而不会暂停其所属的方法。 `await` 运算符不会阻止计算异步方法的线程。 当 `await` 运算符暂停其所属的异步方法时，控件将返回到方法的调用方。如下面所示代码:

```c#
public static async Task Main()
{
    Task<int> downloading = DownloadDocsMainPageAsync();
    Console.WriteLine($"{nameof(Main)}: Launched downloading.");

    int bytesLoaded = await downloading;
    Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
}

private static async Task<int> DownloadDocsMainPageAsync()
{
    Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

    var client = new HttpClient();
    byte[] content = await client.GetByteArrayAsync("https://learn.microsoft.com/en-us/");

    Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
    return content.Length;
}
```

输出为

```
DownloadDocsMainPageAsync: About to start downloading.
Main: Launched downloading.
DownloadDocsMainPageAsync: Finished downloading.
Main: Downloaded 39934 bytes.
```

执行顺序为
1. 调用异步方法 `DownloadDocsMainPageAsync()`
2. 进入异步方法，执行到第一个`await`语句中
    1. 检测语句是否执行完成，如果没有完成，继续执行异步方法调用方法后面的语句，即打印输出
    2. 如果执行完成，则将值赋值给表达式左侧的变量，然后继续执行方法后面的语句
3. `int bytesLoaded = await downloading;` 这一语句同样检测执行完成，执行完成后，继续执行后面语句

所以才会有以上输出结果。

**更细的说：**

await 语句是由由await关键字和一个空闲对象 (称为任务）组成。一个空闲对象即是一个awaitable类型的实例。awaitable类型是指包含GetAwaiter方法的类型，该方法没有参数，返回一个称为awaiter类型的对象。但是常用的就是Task和Task<T>类型了，也不需要手动去实现awaitable类型。

当执行到await语句时，会检查awaiter对象是否已经完成，如果完成，则直接返回结果，如果没有完成，则会将当前方法的控制权交给调用者，然后返回一个Task对象，该对象表示异步方法的执行状态。当awaiter对象完成时，会将awaiter对象的结果赋值给await语句左侧的变量，然后继续执行方法后面的语句。

最简单实现await语句的方式，就是使用Task.Run();方法，该方法会创建一个Task对象，然后在另一个线程上执行指定的方法。当指定的方法执行完成时，会将方法的返回值赋值给Task对象，然后将Task对象标记为完成状态。

`Task.Run`的一个签名以`Func<TReturn>`委托为参数，该委托表示一个不接受参数，返回值为TReturn类型的方法。要将你的方法传递给Task.Run方法，需要基于该方法创建一个委托。

```C#
class MyClass
{
    public int Get10()
    {
        return 10;
    }
    public async Task DoWorkAsync()
    {
        // 单独创建 Func<TReturn> 委托
        Func<int> ten=new Func<int>(Get10);
        int a=await Task.Run(ten);
        // 参数列表中创建 Func<TReturn> 委托
        int b=await Task.Run(new Func<int>(Get10));
        // 隐式转换为 Func<TReturn> 委托的 Lambda表达式
        int c=await Task.Run(()=>{return 10;});
        Console.WriteLine("{0}  {1}  {2}",a,b,c);
    }
}
class Program
{
    static void Main()
    {
        Task t=(new MyClass()).DoWorkAsync();
        t.Wait();
    }
}
```

**可用的委托类型：**

|委托类型|签名|说明|
|---|---|---|
|Action|void Action()|不需要参数且无返回值的方法|
|Func<TResult>|TResult Func()| 不需要参数且返回TResult对象|
|Func<Task>| Task Func()|不需要参数且返回简单Task对象|
|Func<Task<TResult>>| Task<TResult> Func()| 不需要参数且返回Task<TResult>对象|

### 2.3 取消一个异步操作
一些.NET异步方法允许你请求终止执行。你同样也可以在自己的异步方法中加入这个特性。`System.Threading.Tasks`命名空间中有两个类是为此目的而设计的：`CancellationToken`和`CancellationTokenSource`。

1. `CancellationToken`对象包含一个任务是否应被取消的信息
2. 拥有`CancellationToken`对象的任务需要定期检查其令牌（token）状态。如果`CancellationToken`对象的`IsCancellationRequested`属性为true，任务需停止其操作并返回
3. `CancellationToken`是不可逆的，并且只能使用一次。也就是说，一旦`IsCancellationRequested`属性被设置为true，就不能更改了
4. `CancellationTokenSource`对象创建可分配给不同任务的`CancellationToken`对象。任何持有`CancellationTokenSource`的对象都可以调用其`Cancel`方法，这会将`CancellationToken`的`IsCancellationRequested`属性设置为true

具体代码见CancellationTokenDemo.cs

### 2.4 异常处理和await表达式
异步方法中的异常处理与同步方法中的异常处理类似。如果异步方法中的异常没有被捕获，那么异常会被传播到调用者。如果调用者也没有捕获异常，那么异常会被传播到调用者的调用者，以此类推，直到异常被捕获或者到达调用堆栈的顶部。

``` C#
static void Main(string[] args)
{
    Task t = BadAsync();
    t.Wait();
    Console.WriteLine("Task Status : {0}", t.Status);
    Console.WriteLine("Task IsFaulted: {0}", t.IsFaulted);
}
static async Task BadAsync()
{
    try
    {
        await Task.Run(() => { throw new Exception(); });
    }
    catch
    {
        Console.WriteLine("Exception in BadAsync"); // 这里捕获了异常
    }
}
```

### 2.5 同步等待任务
调用方法可以调用任意多个异步方法并接收它们返回的`Task`对象。然后你的代码会继续执行其他任务，但在某个点上可能会需要等待某个特殊`Task`对象完成，然后再继续。为此，`Task`类提供了一个实例方法`Wait`，可以在`Task`对象上调用该方法。而等待的话需要限定时长或者取消标识，可以使用`Wait(TimeSpan)`/`Wait(int millisecondsTimeout)`和`Wait(CancellationToken)`方法。也可以复合使用，比如`Wait(TimeSpan,CancellationToken)`或者`Wait(int,CancellationToken)`。

除此之外，Task类中还有两个静态方法 `WaitAll` 和 `WaitAny`，分别用于等待所有的任务完成和等待任意一个任务完成。他们同样也可以使用额外的限定，比如`WaitAll(Task[],TimeSpan,CancellationToken)`或者`WaitAny(Task[],TimeSpan,CancellationToken)`。

具体代码见SyncWaitDemo.cs

### 2.6 异步等待任务
有时在异步方法中，你会希望用await表达式来等待Task。这时异步方法会返回到调用方法，但该异步方法会等待一个或所有任务完成。可以通过Task.WhenAll和Task.WhenAny方法来实现。例如 `Task.WhenAll(Task[])` 方法会返回一个Task对象，该对象会在所有的Task对象完成时完成。而 `Task.WhenAny(Task[])` 方法会返回一个Task对象，该对象会在任意一个Task对象完成时完成。

与Wait不同的是，Wait会阻塞进程，而采用`acync Tasck.WhenAll`的方式不会阻塞进程，而是在异步方法中等待任务完成。

### 2.7 Task.Delay
`Task.Delay`方法创建一个Task对象，该对象将暂停其在线程中的处理，并在一定时间之后完成。然而与Thread.Sleep阻塞线程不同的是，Task.Delay不会阻塞线程，线程可以继续处理其他工作。

### 2.8 Task.Yield

`Task.Yield`方法创建一个立即返回的awaitable。等待一个Yield可以让异步方法在执行后续部分的同时返回到调用方法。可以将其理解成离开当前的消息队列，回到队列末尾，让处理器有时间处理其他任务。Yield方法在GUI程序中非常有用，可以中断大量工作，让其他任务使用处理器

## 3 BackgroundWorker类 





## 参考资料

1. [微软C#教程-异步编程](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-scenarios)
2. [C# 图解编程 第20章 异步编程](https://www.cnblogs.com/moonache/p/7198669.html)
