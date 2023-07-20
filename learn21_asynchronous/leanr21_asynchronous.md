# ��21�� �첽���

## 1. ʲô���첽
����һ������ϵͳ���ڴ��д���һ���½��̣������ڲ���ϵͳ�������̣߳��߳̿������������̣߳�������˶��̡߳������ڵĶ���̹߳�����̵���Դ��ϵͳΪ�������滮�ĵ�Ԫ���̡߳��첽��̿���ʵ�������߳���������һ���ִ��룬��ı�����ִ��˳������ҪI/O�󶨣��������󡢷������ݿ���ļ���д����������£�ʹ���첽��̻��нϺõ�ʵ�֡�

������Ҫ���ܼ����첽��ʵ�ַ�ʽ�����а�����`async/await`��`BackgroundWorker`��`Task Parellel`��`BeginInvoke/EndInvoke`�Լ�`System.Threading.Timer`��

��GUI����У���WPF��һЩ�¼�����Ӧ��������Ҫʹ���첽��̵ģ����磺���һ����ť����Ҫִ��һ����ʱ�Ĳ�������ʱ�����Ҫʹ���첽��̣�����ᵼ�½��濨����

### 1.1 �߳������

��������ʱ��ϵͳ�����ڴ��д���һ���µĽ��̡������ǹ������г������Դ���ϡ��������ַ�ռ䡢�ļ�������������������������Ķ������ڽ����ڲ���ϵͳ������һ����Ϊ�̵߳��ں˶���������������ִ�еĳ���һ�����̽�����ϵͳ����Main�����ĵ�һ����䴦�Ϳ�ʼ�̵߳�ִ�С�

�����̣߳���Ҫ�˽�����֪ʶ��

1. Ĭ������£�һ������ֻ����һ���̣߳��ӳ���Ŀ�ʼһֱִ�е�����
2. �߳̿������������̣߳����������ʱ�̣�һ�����̶����ܰ�����ͬ״̬�Ķ���̣߳���ִ�г���Ĳ�ͬ����
3. ���һ������ӵ�ж���̣߳����ǽ�������̵���Դ
4. ϵͳΪ������ִ�����滮�ĵ�Ԫ���̣߳����ǽ���

���ֻ��һ���̵߳Ļ�����ô�����ִ��˳����ǰ��մ����˳��ִ�У����ַ�ʽ��Ϊͬ����̡��������ֱ�̷�ʽ���ܻᵼ��һЩ���Խ��ܵ����⣬���磺������һ����������ʱ�������ȴ���������Ľ�����������������������ʱ�䳤�������ᵼ�³����ִ�б����������������ý���������Ĵ������һ���µ��߳���ִ�У������Ͳ����������̵߳�ִ�У���Ҳ�����첽��̵ĺô���

## 2. �첽���

### 2.1 async/await

����ʹ�÷�����

``` c#
// ������������ʱ��ʹ��async�ؼ��� �����ķ�������Ӧ����void Task ���� Task<T>
public async Task<string> GetHtmlAsync(string url)
{
	// ʹ��await�ؼ��֣��ȴ��첽����ִ�����
	var html = await GetHtmlAsync(url);
	return html;
}

// �����������У������첽����
Task<string> html = GetHtmlAsync("http://www.baidu.com");
// �������...
// ʹ���첽�����ķ���ֵ�����û��ִ����ϣ����ȴ��첽����ִ�����
Console.WriteLine(html.Result);
```

`async/await`�����µ�ע�����
1. �첽�����ڷ���ͷ�б������`async`�ؼ��֣��ұ�������ڷ�������֮ǰ
2. �����η�ֻ�Ǳ�ʶ�÷�������һ������`await`���ʽ��Ҳ����˵�����������ܴ����κ��첽������
3. `async`�ؼ�����һ�������Ĺؼ��֣�Ҳ����˵������Ϊ�������η�����Lambda���ʽ���η��������������η���֮�⣬async����������ʶ��
4. ���`await`δ����`async `���������У�C# ������������һ�����棬���˴��뽫����������ͨ�����ķ�ʽ���б�������С� 
5. ��ӡ�Async����Ϊ��д��ÿ���첽�������Ƶĺ�׺��(.Net����)
6. `async void`Ӧ�������¼����������Ϊ�¼������з������ͣ�����޷�����`Task`��`Task<T>`���� �����κζ� `async void`��ʹ�ö�����ѭ TAP ģ�ͣ��ҿ��ܴ���һ��ʹ���Ѷȡ�

���ڷ���ֵ�������¼��������

* **`Task<T>`** ������÷���Ҫ�ӵ����л�ȡһ��`T`���͵�ֵ���첽�����ķ������;ͱ�����`Task<T>`�����÷�����ͨ����ȡ`Task`��`Result`��������ȡ���T���͵�ֵ��
* **`Task`** ������÷�������Ҫ�ӵ����л�ȡһ��ֵ������Ҫ����첽������״̬���첽�����ķ������;Ϳ�����`Task`��������`Task.Wait(	)`���ȴ��첽������ɡ�
* **`void`** ������÷���������ִ���첽������������Ҫ�������κν�һ���Ľ���ʱ���첽�������Է���void���͡���ʱ������һ��������ƣ���ʹ�첽�����а����κ�return��䣬Ҳ���᷵���κζ�����
* �κη���`Task<T>`���͵��첽�����䷵��ֵ����Ϊ`T`���ͻ������ʽת��Ϊ`T`������

### 2.2 await ���
`await` �������ͣ���������� `async` ��������ֵ��ֱ�����������ʾ���첽������ɡ� �첽������ɺ�`await` ����������ز����Ľ��������У��� �� `await` �����Ӧ�õ���ʾ����ɲ����Ĳ�����ʱ�������������ز����Ľ������������ͣ�������ķ����� `await` �����������ֹ�����첽�������̡߳� �� `await` �������ͣ���������첽����ʱ���ؼ������ص������ĵ��÷�����������ʾ����

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

���Ϊ

```
DownloadDocsMainPageAsync: About to start downloading.
Main: Launched downloading.
DownloadDocsMainPageAsync: Finished downloading.
Main: Downloaded 39934 bytes.
```

ִ��˳��Ϊ
1. �����첽���� `DownloadDocsMainPageAsync()`
2. �����첽������ִ�е���һ��`await`�����
    1. �������Ƿ�ִ����ɣ����û����ɣ�����ִ���첽�������÷����������䣬����ӡ���
    2. ���ִ����ɣ���ֵ��ֵ�����ʽ���ı�����Ȼ�����ִ�з�����������
3. `int bytesLoaded = await downloading;` ��һ���ͬ�����ִ����ɣ�ִ����ɺ󣬼���ִ�к������

���ԲŻ���������������

**��ϸ��˵��**

await ���������await�ؼ��ֺ�һ�����ж��� (��Ϊ������ɡ�һ�����ж�����һ��awaitable���͵�ʵ����awaitable������ָ����GetAwaiter���������ͣ��÷���û�в���������һ����Ϊawaiter���͵Ķ��󡣵��ǳ��õľ���Task��Task<T>�����ˣ�Ҳ����Ҫ�ֶ�ȥʵ��awaitable���͡�

��ִ�е�await���ʱ������awaiter�����Ƿ��Ѿ���ɣ������ɣ���ֱ�ӷ��ؽ�������û����ɣ���Ὣ��ǰ�����Ŀ���Ȩ���������ߣ�Ȼ�󷵻�һ��Task���󣬸ö����ʾ�첽������ִ��״̬����awaiter�������ʱ���Ὣawaiter����Ľ����ֵ��await������ı�����Ȼ�����ִ�з����������䡣

���ʵ��await���ķ�ʽ������ʹ��Task.Run();�������÷����ᴴ��һ��Task����Ȼ������һ���߳���ִ��ָ���ķ�������ָ���ķ���ִ�����ʱ���Ὣ�����ķ���ֵ��ֵ��Task����Ȼ��Task������Ϊ���״̬��

`Task.Run`��һ��ǩ����`Func<TReturn>`ί��Ϊ��������ί�б�ʾһ�������ܲ���������ֵΪTReturn���͵ķ�����Ҫ����ķ������ݸ�Task.Run��������Ҫ���ڸ÷�������һ��ί�С�

```C#
class MyClass
{
    public int Get10()
    {
        return 10;
    }
    public async Task DoWorkAsync()
    {
        // �������� Func<TReturn> ί��
        Func<int> ten=new Func<int>(Get10);
        int a=await Task.Run(ten);
        // �����б��д��� Func<TReturn> ί��
        int b=await Task.Run(new Func<int>(Get10));
        // ��ʽת��Ϊ Func<TReturn> ί�е� Lambda���ʽ
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

**���õ�ί�����ͣ�**

|ί������|ǩ��|˵��|
|---|---|---|
|Action|void Action()|����Ҫ�������޷���ֵ�ķ���|
|Func<TResult>|TResult Func()| ����Ҫ�����ҷ���TResult����|
|Func<Task>| Task Func()|����Ҫ�����ҷ��ؼ�Task����|
|Func<Task<TResult>>| Task<TResult> Func()| ����Ҫ�����ҷ���Task<TResult>����|

### 2.3 ȡ��һ���첽����
һЩ.NET�첽����������������ִֹ�С���ͬ��Ҳ�������Լ����첽�����м���������ԡ�`System.Threading.Tasks`�����ռ�������������Ϊ��Ŀ�Ķ���Ƶģ�`CancellationToken`��`CancellationTokenSource`��

1. `CancellationToken`�������һ�������Ƿ�Ӧ��ȡ������Ϣ
2. ӵ��`CancellationToken`�����������Ҫ���ڼ�������ƣ�token��״̬�����`CancellationToken`�����`IsCancellationRequested`����Ϊtrue��������ֹͣ�����������
3. `CancellationToken`�ǲ�����ģ�����ֻ��ʹ��һ�Ρ�Ҳ����˵��һ��`IsCancellationRequested`���Ա�����Ϊtrue���Ͳ��ܸ�����
4. `CancellationTokenSource`���󴴽��ɷ������ͬ�����`CancellationToken`�����κγ���`CancellationTokenSource`�Ķ��󶼿��Ե�����`Cancel`��������Ὣ`CancellationToken`��`IsCancellationRequested`��������Ϊtrue

��������CancellationTokenDemo.cs

### 2.4 �쳣�����await���ʽ
�첽�����е��쳣������ͬ�������е��쳣�������ơ�����첽�����е��쳣û�б�������ô�쳣�ᱻ�����������ߡ����������Ҳû�в����쳣����ô�쳣�ᱻ�����������ߵĵ����ߣ��Դ����ƣ�ֱ���쳣��������ߵ�����ö�ջ�Ķ�����

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
        Console.WriteLine("Exception in BadAsync"); // ���ﲶ�����쳣
    }
}
```

### 2.5 ͬ���ȴ�����
���÷������Ե����������첽�������������Ƿ��ص�`Task`����Ȼ����Ĵ�������ִ���������񣬵���ĳ�����Ͽ��ܻ���Ҫ�ȴ�ĳ������`Task`������ɣ�Ȼ���ټ�����Ϊ�ˣ�`Task`���ṩ��һ��ʵ������`Wait`��������`Task`�����ϵ��ø÷��������ȴ��Ļ���Ҫ�޶�ʱ������ȡ����ʶ������ʹ��`Wait(TimeSpan)`/`Wait(int millisecondsTimeout)`��`Wait(CancellationToken)`������Ҳ���Ը���ʹ�ã�����`Wait(TimeSpan,CancellationToken)`����`Wait(int,CancellationToken)`��

����֮�⣬Task���л���������̬���� `WaitAll` �� `WaitAny`���ֱ����ڵȴ����е�������ɺ͵ȴ�����һ��������ɡ�����ͬ��Ҳ����ʹ�ö�����޶�������`WaitAll(Task[],TimeSpan,CancellationToken)`����`WaitAny(Task[],TimeSpan,CancellationToken)`��

��������SyncWaitDemo.cs

### 2.6 �첽�ȴ�����
��ʱ���첽�����У����ϣ����await���ʽ���ȴ�Task����ʱ�첽�����᷵�ص����÷����������첽������ȴ�һ��������������ɡ�����ͨ��Task.WhenAll��Task.WhenAny������ʵ�֡����� `Task.WhenAll(Task[])` �����᷵��һ��Task���󣬸ö���������е�Task�������ʱ��ɡ��� `Task.WhenAny(Task[])` �����᷵��һ��Task���󣬸ö����������һ��Task�������ʱ��ɡ�

��Wait��ͬ���ǣ�Wait���������̣�������`acync Tasck.WhenAll`�ķ�ʽ�����������̣��������첽�����еȴ�������ɡ�

### 2.7 Task.Delay
`Task.Delay`��������һ��Task���󣬸ö�����ͣ�����߳��еĴ�������һ��ʱ��֮����ɡ�Ȼ����Thread.Sleep�����̲߳�ͬ���ǣ�Task.Delay���������̣߳��߳̿��Լ�����������������

### 2.8 Task.Yield

`Task.Yield`��������һ���������ص�awaitable���ȴ�һ��Yield�������첽������ִ�к������ֵ�ͬʱ���ص����÷��������Խ��������뿪��ǰ����Ϣ���У��ص�����ĩβ���ô�������ʱ�䴦����������Yield������GUI�����зǳ����ã������жϴ�������������������ʹ�ô�����

## 3 BackgroundWorker�� 





## �ο�����

1. [΢��C#�̳�-�첽���](https://learn.microsoft.com/zh-cn/dotnet/csharp/asynchronous-programming/async-scenarios)
2. [C# ͼ���� ��20�� �첽���](https://www.cnblogs.com/moonache/p/7198669.html)
