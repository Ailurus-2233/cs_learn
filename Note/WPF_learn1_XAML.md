# XAML概览
## 什么是XAML

XAML是WPF技术中专门用于设计UI的语言，XAML 的全称是 Extensible Application Markup Language，即可扩展应用程序标记语言。它在桌面开发及富媒体网络程序的开发中扮演了 HTML+CSS+JavaScript的角色、成为设计师与程序员之间沟通的枢纽。

## XAML优点

1. XAML可以设计出专业的UI和动画
2. XAML不需要专业的编程知识，它简单易懂、结构清晰
3. XAML使设计师能直接参与软件开发，随时沟通、无需二次转化
4. XAML是一种单纯的声明型语言，也就是说，它只能用来声明一些UI元素、绘制UI和动画，它帮助开发团队真正实现了 UI与逻辑的剥离

## WPF 项目构成

1. Properties分支：里面的主要内容是程序要用到的一些资源（如图标、图片、静态的字符串）和配置信息。
2. References分支：标记了当前这个项目需要引用哪些其他的项目，[里面列出来的条目.NET](http://xn--79qpcz12gpa964qhsam81m4lj.NET) Framework类库或其他程序员编写的项目及类库。
3. App.xaml分支：程序的主体。大家知道，在Windows系统里，一个程序就是一个进程。Windows还规定，一个GUI进程需要有一个窗体作为主窗体。App.xaml文件的作用就是声明了程序的进程会是谁，同时指定了程序的主窗体是谁。在这个分支里还有一个文件App.xaml.cs,它是App.xaml的后台代码。
4. MainWindow.xaml分支：程序的主窗体，它也具有自己的后台代码MainWindow.xaml.cs。

# XAML语法
## XAML概述

XAML是一种由XML派生而来的语言，所以很多XML中的概念在XAML是通用的。比如， 使用标签声明一个元素（每个元素对应内存中的一个对象）时，需要使用起始标签<Tag>和终止标签</Tag>,夹在起始标签和终止标签中的XAML代码表示是隶属于这个标签的内容。如果没有什么内容隶属于某个标签，则这个标签称为空标签，可以写为<Tag/>。

### Property 与 Attribute

Property属于面向对象理论范畴。在使用面向对象思想编程的时候，常常需要对客观事物进行抽象，再把抽象出来的结果封装成类，类中用来表示事物状态的成员就是Property。

Attribute则是编程语言文法层面的东西。比如有两个同类的语法元素A和B,为了表示A与 B不完全相同或者A与B在用法上有些区别，这时候就要针对A和B加一些Attribute。

因为XAML是用来在UI上绘制控件的，而控件本身就是面向对象抽象的产物，所以XAML标签的Attribute里就有一大部分是与控件对象的Property互相对应的.当然，这还意味着XAML标签还有一些Attribute并不对应控件对象的Property。

## XAML 初步标签详解

```xml
<Window>
	<Grid>
	</Grid>
</Window>
```

XAML是一种"声明”式语言，当你见到一个标签，就意味着声明了一个对象，对象之间的层级关系要么是并列、要么是包含，全都体现在标签的关系上.对于任何一个**WPF窗口**，**总体结构是一个<Window>标签内部包含着一个<Grid>标签**（或者说＜Grid＞标签是＜Window＞标签的内容），代表的含义是一个窗体对象内嵌套着一个Grid对象。

``` xml
x:Class="MyFirstWpfApplication.MainWindow"
xmlns="<http://schemas.microsoft.com/winfx/2006/xaml/presentation>"
xmlns:x="<http://schemas.microsoft.com/winfx/2006/xamr>
Title="Window!" Heighr"300" Width=”300"
```

这些代码就都是<Window>标签的Attribute，其中，Title、Height和Width 一看就知道是与Window对象的Property相对应的。中间两行（即两个`xmlns`）是在声明名称空间，这两个地址定义了一个或一组的类库。最上面一行是在使用名为Class的Attribute，这个Attribute来自于`x:`前缀所对应的名称空间。

``` xml
xmlns[:可选的映射前缀]="名称空间"
```

XML语言有一个功能就是可以在XML文档的标签上使用xmlns特征来定义名称空间（Namespace）, xmlns也就是XML-Namespace的缩写了。定义名称空间的好处就是，当来源不同的类重名时，可以使用名称空间加以区分。xmlns后可以跟一个可选的映射前缀，之间用冒号分隔。如果没有写可选映射前缀，那就意味着所有来自于这个名称空间的标签前都不用加前缀，这个没有映射前缀的名称空间称为"默认名称空间"。默认名称空间只能有一个，而且应该选择其中元素被最频繁使用的名称空间来充当默认名称空间。

## XAML本质

x:Class这个Attribute的作用是当XAML解析器将包含它的标签解析成C#类后，这个类的类名是什么。这里，已经触及到的XAML的本质。前面我们已经看到，示例代码的结构就是使用XAML语言直观地告诉我们，当前被设计的窗体是在一个<Window>里面嵌套了一个<Grid>。xaml文件中声明的类和其对应的cs文件共同编译生成一个类，其中cs文件中的class声明为

```csharp
public partial class MainWindow : Window
```

通过partial关键字，就可以将一个类分为两个部分一起编译，在xaml中，主要定义了类的样式，动画等，而在cs文件中，主要定义了类的逻辑代码等。

## XAML中为对象属性赋值的语法

XAML中为对象属姓赋值共有两种语法：

- 使用字符串进行简单赋值
- 使用属性元素(Property Element)进行复杂赋值

### 使用字符串赋值

`Attribute=Value` 实例如下：

```csharp
<Rectangle x:Name="rectangle" Width="200" Height="120" Fill="Blue"/>
```

这个XAML标签就声明了一个`Ractangle`对象，其中的属性`Width`、`Height`、`File` 都直接通过字符串声明。即一个长宽为$200\times 120$ 被蓝色填充的一个长方形。

从对象的层面来说，`Rectangle.Fill` 的类型是Brush，Brush是一个抽象类，所以以下的对象都可以作为属性的值：

- `SolidColorBrush`：单色画刷
- `LinearGradientBrush`：线性渐变画刷
- `RadialGradientBrush`：径向渐变画刷
- `ImageBrush`：位图画刷
- `DrawingBrush`：矢量图画刷
- `VisualBrush`：可视元素画刷

### 属性元素

在XAML中，非空标签均具有自己的内容（Content）。标签的内容指的就是夹在起始标签和结束标签之间的一些子级标签，每个子级标签都是父级标签内容的一个元素（Element）,简称为父级标签的一个元素。如下所示，这样，在这个标签的内部就可以使用对象（而不再局限于简单的字符串）进行赋值了。

```xml
<ClassName>
	<ClassName.PropertyName>
		<!--以对象形式为属性赋值-->
	</ClassName.PropertyName>
</ClassName>
```

实例：

```xml
<Rectangle x:Name="rectanglcH Width-"200" Height="120">
	<Rectanglc.Fill>
		<SolidColorBrush Color="Blue"/>
	</Rectangle.Fill>
</Rectangle>
```

注：

- 能使用Attribute=Value形式赋值的就不使用属性元素.
- 充分利用默认值，去除冗余：`StartPoint="0,0"EndPoint="1,1"`是默认值，可以省略。
- 充分利用XAML的简写方式

### 标记扩展

```ad-note
所谓标记扩展，实际上是一种特殊的Attribute=Value语法，其特殊的地方在于Value字符串是由一对花括号及其括起来的内容姐成，XAML编译器会对这样的内容做出解析，生成相应的对象。
```

```xml
<TextBox Text=" {Binding ElementName=sliderl, Path=Value, Mode=OneWay}" Margin="5"/>
```
例如这段代码：
* 当编译器看到这句代码时就会把花括号里的内容解析成相应的对象
* 对象的数据类型名是紧邻左花括号的字符串
* 对象的属性由一串以逗号连接的子字符串负责初始化（注意，属性值不再加引号）

```ad-note
最后，使用标记扩展时还需要注意以下几点：
* 标记扩展是可以嵌套的，例如 `Text="{Binding Source={StaticResource myDataSource}, Path=PersonName}"`是正确的语法
* 标记扩展具有一些简写语法，例如`{Binding Value,…}`与`{Binding Path=Value,…}`是等价的，`{StaticResource myString, ...}` `{StaticResource ResourceKey=myString,…}`是等价的。两种写法中，前者称为固定位置参数,后者称为具名参数)。固定位置参数实际上就标记扩展类构造器的参数，其位置由构造器参数列表决定。
* 标记扩展类的类名均以单词Extension为后缀，在XAML使用它们的时候Extension后缀可以省略不写,比如写`Text="{x:Stalic …}"`与写`Text="{x:StaticExtension …}"`是等价的.
```

## 事件处理器与代码后置

在`.NET`事件处理机制中，可以为对象的某个事件指定一个能与该事件匹配的成员函数，当这个事件发生时，.NET运行时会去调用这个函数，即表示对这个事件的响应和处理。

```xml
<ClassName EventName="EventHandlerName" />
```

而翻译C#代码的话，例如：
```C#
Button button1 = new Button();
button1.Click += new RoutedEventHandler(buttonl_Click);
```

这种将逻辑代码与UI代码分离、隐藏在UI代码后面的形式就叫作"代码后置"。

```ad-note
之所以能实现代码后置功能，是因为.NET支持partial类并能将解析XAML所生成的代码与`x:Class`所指定的类进行合并，有两点需要注意的是：
* 不只是事件处理器，一切用于实现程序逻辑的代码都要放在后置的C#文件中
* 默认情况下，VS为每个XAML文件生成的后置代码文件名为"XAML文件全名.cs"，比如XAML文件名为`MyWindow.xaml`，那么它的后置代码文件名为`MyWindow.xaml.cs`。这样做是为了方便包文件，但并不是必须的， 只要XAML解析器能找到`x:Class`所指定的类，无论你的文件叫什么名字都可以。
```

### 引用其他类库

语法：
```xml
xmlns:映射名="clr-namespace:类库中namespace的名字;assembly=类库文件名"
```

* xmlns是用于在XAML中声明名称空间的Attribute，它从XML语言继承而来，是XML Namespace 的缩写
* 冒号后的映射名是可选的，但由于可以不加映射名的默认名称空间已经被WPF的主要名称空间占用，所以所引用的名称空间都需要加上这个映射名。
* 引号中的字符串值确定了你要引用的是哪个类库以及类库中的哪个名称空间。

类的引用：
```xml
<映射名:类名>…</映射名:类名>
```

### XAML的注释

```xml
<!-- 注释内容 -->
```

# X命名空间

在生成的Window.xaml文件中，有这么一个引用
``` xml
xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
```
其中的内容有如下

## X中的具体内容

| 名称            | 种类          |
| --------------- | ------------- |
| x:Array         | 标签拓展      |
| x:Class         | Attribute     |
| x:ClassModifier | Attribute     |
| x:Code          | XAML 指令元素 |
| x:FieldModifier | Attribute     |
| x:Key           | Attribute     |
| x:Name          | Attribute     |
| x:Null          | 标签扩展      |
| x:Shared        | Attribute     |
| x:Static        | 标签扩展      |
| x:Subclass      | Attribute     |
| x:Type          | 标签扩展      |
| x:TypeArguments | Attribute     |
| x:Uid           | Attribute     |
| x:XData         | 标签扩展      | 

## x名称空间中的Attribute
### x:Class
这个Attribute的作用是告诉XAML编译器将XAML标签的编译结果与后台代码中指定的类合并。

在使用x:Class时必须遵循以下要求:
1. 这个Attribute只能用于根结点
2. 使用x:Class的根结点的类型要与x:Class的值所指示的类型保持一致
3. x:Class的值所指示的类型在声明时必须使用partial关键字

### x: ClassModifier
这个Attribute的作用是告诉XAML编译由标签编译生成的类具有怎样的访问控制级别。

使用这个Attribute时客要注意：
1. 标签必须具有x:Class Attribute
2. x:ClassModifier的值必须与x:Class所指示类的访问控制级别一致
3. x:ClassModifier的值随后台代码编程语言不同而有所不同，参见TypeAttributes枚举类型

### x: Name
x:Name的作用有两个：
1. 告诉XAML编译器，当一个标签带有x:Name时除了为这个标签生成对应实例外还要为这个实例声明一个引用变量，变量名就是x:Name的值.
2. 将XAML标签所时应对象的Name属性(如果有)也设为x:Name的值，并把这个值注册到UI树上，以方便查找.


### Name与x:Name的区别
1. Name属性定义在FrameworkElement类中，这个类是WPF控件的基类，所以所有WPF控件都具有Name这个属性。
2. x:Name 在Name的基础上，额外生成了一个引用变量，变量名就是x:Name的值

### x:FieldModifier
使用x:Name后，XAML标签对应的实例就具有了自己的引用变量，而且这些引用变量都是类的字段。既然是类的字段就免不了要关注一下它们的访问级别。这个属性就是设定这些字段的访问级别的。前提需要有`x:Name`

### x:Key
x:Key的作用就是为资源贴上用于检索的索引。资源(Resources)在WPF中非常重要，需要重复使用的XAML内容，如Style、各种Template和动画等都需要放在资源里。

### x:Shared
xShared 一定要与x:Key配合使用，如果x:Shared的值为true,那么每次检索到这个对象时，我们得到的都是同一个对象，否则如果 x:Shared的值为false,每次我们检索到这个对象时，我们得到的都是这个对象的一个新副本。XAML编译器会为资源隐藏地添加x:Shared="true",也就是说，默认情况下我们得到的都是同一个对象。

## x名称空间中的标记扩展

### x:Type
x:Type的值是一个数据类型的名称。
```xml
<local:MyButton Content="Show" UserWindowType="{x:Type TypeName=local:MyWindow}" Margin="5"/>
```
### x:Null
通过x:Null 可以显式地对一个属性赋一个空值
```xml
<TextBox Style="{x:Null}" />
<!-- 或者 -->
<TextBox>
	<TextBox.Style>
		<x:Null/>
	</TextBox.Style>
</TextBox>
```

### x:Array
x:Array的作用就是通过它的Items属性向使用者暴露一个类型已知的ArrayList实例，ArrayList内成员的类型由x:Array的Type指明

```xml
<ListBox Margin="5" ItemsSource="{x:Array Type=sys:String}"/>
```
这样子的声明，Array中没有对象赋值给ListBox，所以需要修改成以下的声明方式

```xml
<ListBox Margin="5">
	<ListBox.ItemsSource>
		<x:Array Type="sys:String">
			<sys:String>Tim</sys:S<ring>
			<sys:String>Tom</sys:String>
			<sys:String>Victor</sys:String>
		</x:Array>
	</LostBox.ItemsSource>
</ListBox>
```

### x:Static
x:Static是一个很常用的标记扩展，它的功能是在XAML文档中使用数据类型的static成员。 因为XAML不能编写逻辑代码，所以使用x:Static访问的static成员一定是数据类型的属性或字段。


## XAML指令元素
x:Code 可以用来写代码

x:XData 标签是一个专用标签。WPF中把包含数据的对象称为数据源，用于把数据源中的数据提供给数据使用者的对象被称为数据提供者。

