# 控件与布局

## 常用控件类型

| 控件名称       | 说明                                                                                    | 举例                        |
| -------------- | --------------------------------------------------------------------------------------- | --------------------------- |
| 布局控件       | 可以容纳多个控件或嵌套其他布局控件，用于在UI上组织和排列控件。                          | Grid、StackPanel、DockPanel |
| 内容控件       | 只能容纳一个其他控件或布局控件作为它的内容。                                            | Window、Button              |
| 带标题内容控件 | 相当于一个内容控件，但可以加一个标题,标题部分亦可容纳一个控件或布局。                   | GroupBox、Tabitem           |
| 条目控件       | 可以显示一列数据，一般情况下这列数据的类型相同。                                        | ListBox、ComboBox           |
| 带标题条目控件 | 相当于一个条目控件加上一个标题显示区。                                                  | TreeViewitem、Menuitem      |
| 特殊内容控件   | 比如TextBox容纳的是字符串、TextBlock可以容纳可自由控制格式的文本、Image容纳图片类型数据 |                             |


## 内容模型
| 名称                   | 注释                           |
| ---------------------- | ------------------------------ |
| ContentControl         | 单一内容控件                   |
| HeaderedContentControl | 带标题的单一内容控件           |
| ItemsControl           | 以条目集合为内容的控件         |
| HeaderedltemsControl   | 带标题的以条目集合为内容的控件 |
| Decorator              | 控件装饰元素                   |
| Panel                  | 面板类元素                     |
| Adorner                | 文字点缀元素                   |
| FlowText               | 流式文本元素                   |
| TextBox                | 文本输入框                     |
| TextBlock              | 静态文字                       |
| Shape                  | 图形元素                       | 

控件是内存中的对象，控件的内容也是内存中的对象。控件通过自己的某个属性引用着作为其内容的对象，这个属性称为内容属性(Content Property)。

## 各类内容模型详解

### ContentCcntrol 族
特点：
1. 均派生自 ContentControl类
2. 它们都是控件(Control)
3. 内容属性的名称为Content
4. 只能由单一元素充当其内容

包含的控件有：
```
Button ButtonBase CheckBox ComboBoxItem
ContentControl Frame GridViewColumnHeader Groupitem
Label ListBoxltem ListViewitem NavigationWindow
RadioButton RepeatButton Scrollviewer StatusBarltem
ToggleButton ToolTip UserControl Window
```

### HeaderedContentControl 族
特点：
1. 它们都派生自 HcaderedContentControl 类，HeaderedContentControi 是 ContentControl 类的派生类
2. 它们都是控件，用于显示带标题的数据
3. 除了用于显示主体内容的区域外，控件还具有一个显示标题(Header)的区域
4. 内容属性为Content和Header
5. 无论是Content还是Header都只能容纳一个元素作为其内容

包含的控件有：
```
Expander GroupBox HeaderedContentControi Tabitem
```

### ItemsCcntrol 族
特点：
1. 均派生自ItemsControl类
2. 它们都是控件，用于显示列表化的数据
3. 内容属性为Items或ItemsSource
4. 每种ItemsControl都对应有自己的条目容器

包含的控件：
```
Menu MenuBase ContextMenu ComboBox
ItemsControl ListBox ListView TabControI
TreeView Selector StatusBar
```

书中样例：
```C#
this.listBoxEmplyee.DisplayMemberPath = "Name";
this.listBoxEmplyee.SelectedValuePath = "Id";
this.listBoxEmplyee.ItemsSource = empList;
```

DisplayMemberPath这个属性告诉ListBox显示每条数据的哪个属性，换句话说，ListBox会去调用这个属性值的ToString()方法，把得到的字符串放入一个TextBlock (最简单的文本控件)，然后再按前面说的办法把TextBlock包装进一个ListBoxItem里。

ListBox 的 SelectedValuePath 属性将与其 SelectedValue 属性配合使用。当你调用 SelectedValue属性时，ListBox先找到选中的Item所对应的数据对象，然后把SelectedValuePath的值当作数据对象的属性名称并把这个属性的值取出来。

DisplayMemberPath 和 SelectedValuePath 是两个相当简化的属性。DisplayMemberPath 只能显示简单的字符串，想用更加复杂的形式显示数据需要使用DataTemplate。


### HeaderedltemsControl 族
特点：
1. 均派生自 HeaderedltemsControl 类
2. 它们都是控件，用于显示列表化的数据，同时可以显示一个标题。
3. 内容属性为 Items、ItemsSource 和 Header

包含控件：
Menuitem、TreeViewitem、ToolBar

### Decorator 族
特点：
1. 均派生自Decorator类
2. 起UI装饰作用
3. 内容属性为Child
4. 只能由单一元素充当内容

包含控件：
```
ButtonChrome ClassicBorderDecorator ListBoxChrome SystemDropShadowChrome
Border InkPresenter BulletDecorator Viewbox AdornerDecorator
```


### TextBlock 和 TextBox
1. TextBlock只能显示文本，不能编辑，所以又称静态文本。TextBox不需要太多的格式显示，所以它的内容是简单的字符串，内容属性为Text。
2. TextBox则允许用户编辑其中的内容。TextBlock由于需要操纵格式，所以内容属性是Inlines （印刷中的"行”），同时，TextBlock也保留一个名为Text的属性，当简单地显示一个字符串时，可以使用这个属性。

### Shape 族元素
特点：
1. 均派生自Shape类
2. 用于2D图形绘制
3. 无内容属性
4. 便用Fill属性设置填充，使用Stroke属性设置边线

### Panel 族元索
特点：
1. 均派生自Panel抽象类
2. 主要功能是控制UI布局
3. 内容属性为Children
4. 内容可以是多个元素，Panel元素将控制它们的布局

包含的控件：
```
Canvas DockPanel Grid TabPanel
ToolBarOverflowPanel StackPanel ToolBarPanel UniformGrid
VirtualizingPanel VirtualizingStackPanel WrapPane1
```

## UI布局
WPF中的布局元素有如下几个：
1. Grid：网格。可以自定义行和列并通过行列的数量、行高和列宽来调整控件的布局。
2. StackPanel：栈式面板。可将包含的元素在竖直或水平方向上排成一条直线，当移除一个元素后，后面的元素会自动向前移动以填充空缺。
3. Canvas：画布。内部元素可以使用以像素为单位的绝对坐标进行定位，类似于Windows Form编程的布局方式。
4. DockPanel：泊靠式面板。内部元素可以选择泊靠方向，类似于在Windows Form编程中设置控件的Dock属性。
5. WrapPanel：自动折行面板。内部元素在排满一行后能够自动折行，类似于HTML中的流式布局。

### Grid
特点：
1. 可以定义任意数量的行和列，非常灵活
2. 行的高度和列的宽度可以使用绝对数值、相对比例或自动调整的方式进行精确设定，并可设置最大值和最小值
3. 内部元素可以设置自己的所在的行和列，还可以设置自己纵向跨几行、横向跨几列
4. 可以设置Children元素的对齐方向

使用场景：
1. UI布局的大框架设计
2. 大量UI元素需要成行或者成列对齐的情况
3. UI整体尺寸改变时，元素需要保持固有的高度和宽度比例
4. UI后期可能有较大变更或扩展

**定义行与列：**
```xml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>
    <Grid.RowDefinitions>
        <RowDefinition/>
        <RowDefinition/>
        <RowDefinition/>
        <RowDefinition/>
    </Grid.RowDefinitions>
</Grid>
```

如果需要动态地调整Grid的布局，可以在C#完成对列和行的定义。假设窗体包含一个名为gridMain的Grid元素，我为这个窗体的Loaded事件准备了如下的处理器：

```C#
private void Window_Loaded(object sender, RoutedEventArgs e)
{
    // 添加4列
    this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
    this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
    this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
    this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

    // 添加三行
    this.mainGrid.RowDefinitions.Add(new RowDefinition());
    this.mainGrid.RowDefinitions.Add(new RowDefinition());
    this.mainGrid.RowDefinitions.Add(new RowDefinition());
}
```

**Grid 可接受的宽度和高度的单位**

| 英文名称   | 中文名称 | 简写                 | 换算                  |
| ---------- | -------- | -------------------- | --------------------- |
| Pixel      | 像索     | px(默认单位，可省略) | 图形基本单位          |
| Inch       | 英寸     | in                   | 1 inch = 96pixel      |
| Centimeter | 厘米     | cm                   | 1 cm = (96/2.54)pixel |
| Point      | 点       | Pt                   | 1 pt = (96/72)pixel   | 

```ad-danger
1. 属性的值为double类型
2. 因为像素是默认单位，所以px可以省略
3. 其他单位也会被转换成像素并显示在Grid的边缘处
```

**Grid的行高和列宽设置方法:**
1. 绝对值：double数值加单位后缀（如上例）
2. 比例值：double数值后加一个星号（"\*")
3. 自动值：字符串Auto

**为控件指定行和列遵循以下规则:**
1. 行和列都是从0开始计数
2. 指定一个控件在某行，就为这个控件的标签添加Grid.Row="行编号"这样一个Attribute.若行编号为0 (即控件处于首行)则可省略这个Attribute.
3. 指定一个控件在某列，就为此控件添加Grid.Column="列编号"这样的Attribute,若列编号为0则Attribute可以省略不写
4. 若控件需要跨多个行或列，请使用Grid.RowSpan="行数"和Grid.ColumnSpan="列数"两个Attribute

### StackPanel
StackPanel可以把内部元素在纵向或横向上紧凑排列、形成栈式布局

使用场景：
1. 同类元素需要紧凑排列（如制作菜单或者列表）
2. 移除其中的元素后能够自动补缺的布局或者动画

**StackPanel的三个属性**

| 属性                | 数据类型                 | 可取值                    | 描述                               |
| ------------------- | ------------------------ | ------------------------- | ---------------------------------- |
| Orientation         | Orientation 枚举         | Horizontal/Vertical       | 决定内部元素是横向累积还是纵向累积 |
| HorizontalAlignment | HorizontalAlignment 枚举 | Left/Center/Right/Stretch | 决定内部元素水平方向上的对齐方式   |
| VerticalAlignment   | VerticalAlignment 枚举   | Top/Center/Bottom/Stretch | 决定内部元素竖直方向上的对齐方式   | 

### Canvas
Canvas译成中文就是"画布"，显然，在Canvas里布局就像在画布上画控件一样。当控件被放置在Canvas里时就会被附加上Canvas.Left、Canvas.Top、Canvas.Right、Canvas.Buttom属性。

使用场景有：
1. 一经设计基本上不会再有改动的小型布局（如图标）。
2. 艺术性比较强的布局。
3. 需要大量使用横纵坐标进行绝对点定位的布局。
4. 依赖于横纵坐标的动画。

### DockPanel
DockPanel内的元素会被附加上DockPanel.Dock这个属性，这个属性的数据类型为Dock枚举。Dock枚举可取Left、Top、Right和Bottom四个值。

DockPanel还有一个重要属性——bool类型的LastChildFill,它的默认值是True。当LastChildFill属性的值为True时，DockPanel内最后一个元素的DockPanel.Dock属性值会被忽略，这个元素会把DockPanel内部所有剩余空间充满。

### WrapPanel
WrapPanel内部采用的是流式布局。WrapPanel使用Orientation属性来控制流延伸的方向，使用HorizontalAlignment和VerticalAlignment两个属性控制内部控件的对齐。


