# 控件模板

控件模板用于来定义控件的外观、样式，还可通过控件模板的触发器(ControlTemplate.Triggers)修改控件的行为、响应动画等。
- 对与WPF当中，每个控件都是无外观的，这意味着我们可以完全自定义其可视元素的外观，但是不能修改其内部的行为，因为控件的行为已经被固定在控件的具体类中。
- 在Winform当中，你会发现，控件的外观与行为都被固定在控件的具体类中，当我们想要修改按钮的的边框弧度、或者修改控件本身一些细节的时候，我们需要修改外观的同时，把原来具备的所有行为重写一遍，我们大多数称之为自定义控件。


在 visual studio 中可以在预览里面，右键控件->编辑模板->编辑副本，就可以快速的创建一个控件的模板到指定位置。

在生成的代码中

```html
<SolidColorBrush x:Key="Button.Static.Background" Color="#FFDDDDDD"/>
<SolidColorBrush x:Key="Button.Static.Border" Color="#FF707070"/>
<SolidColorBrush x:Key="Button.MouseOver.Background" Color="#FFBEE6FD"/>
<SolidColorBrush x:Key="Button.MouseOver.Border" Color="#FF3C7FB1"/>
<SolidColorBrush x:Key="Button.Pressed.Background" Color="#FFC4E5F6"/>
<SolidColorBrush x:Key="Button.Pressed.Border" Color="#FF2C628B"/>
<SolidColorBrush x:Key="Button.Disabled.Background" Color="#FFF4F4F4"/>
<SolidColorBrush x:Key="Button.Disabled.Border" Color="#FFADB2B5"/>
<SolidColorBrush x:Key="Button.Disabled.Foreground" Color="#FF838383"/>
```

可以发现这里定义了一下 SolidColorBursh 对象，`x:Key` 相当于给这对象命名，这个对象包含了属性`Color`，根据名字不难理解这个是为了给Button组件在各种状态时（如静置、鼠标覆盖、点击以及不可用）的背景颜色、前景颜色等。

在后面是 `<Style x:Key="ButtonStyle1" TargetType="{x:Type Button}"></Style>`这个标签，这个标签定义了一个样式，`x:Key` 为样式命名，`TargetType` 为样式的目标类型，这里是Button，也就是说这个样式是给Button用的，接着后面声明一些属性，不过多介绍。

```html
<Setter Property="FocusVisualStyle" Value="{StaticResource FocusVisual}"/>
<Setter Property="Background" Value="{StaticResource Button.Static.Background}"/>
<Setter Property="BorderBrush" Value="{StaticResource Button.Static.Border}"/>
<Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
<Setter Property="BorderThickness" Value="1"/>
<Setter Property="HorizontalContentAlignment" Value="Center"/>
<Setter Property="VerticalContentAlignment" Value="Center"/>
<Setter Property="Padding" Value="1"/>
```

模板标签如下代码所示，第一行引用了一个模板，`x:Key` 为模板命名，`Value` 为模板的内容，这里引用了一个模板，`ButtonControlTemplate1`（或者说把style中Template的属性设置为预先定义的ButtonControlTemplate1）。当然也可以直接在这里定义模板，不过这样不利于复用。其中`Border`用来定义控件边框外观的结构和样式，可用的属性有`BorderBrush`、`BorderThickness`、`CornerRadius`、`Background`等；Triggers可以定义控件的行为，例如鼠标点击、鼠标覆盖等。

```html
<Setter Property="Template" Value="{DynamicResource ButtonControlTemplate1}"/>

<Setter Property="Template">
    <Setter.Value>
        <ControlTemplate TargetType="{x:Type Button}">
            <Border>
                <ContentPresenter /> //对于继承自ContentControl的控件，可以使用ContentPresenter来呈现内容
                <ItemsPresenter /> //对于继承自ItemsControl的控件，可以使用ItemsPresenter来呈现内容
            </Border>
            <ControlTemplate.Triggers>                
            </ControlTemplate.Triggers>
        </ControlTemplate>
    </Setter.Value>
</Setter>
```
**TemplateBinding:** 用于绑定模板中的属性，例如上面的`BorderBrush="{TemplateBinding BorderBrush}"`，这里的`BorderBrush`是模板中的属性，`BorderBrush`是控件的属性，这样就把模板中的属性绑定到了控件的属性上，这样就可以在模板中定义属性，然后在控件中使用模板，这样就可以把模板中的属性绑定到控件中，这样就可以在控件中使用模板中的属性了。而如果模板中没有使用TemplateBinding的话，那么就是使用模板中明确定义的样式，或者默认的样式，在控件属性和样式中怎么改都不会生效了。

**ContentPresenter：** 对于继承自ContentControl的控件，可以使用ContentPresenter来呈现内容，例如上面的`<ContentPresenter />`，在控件中使用模板的时候，就可以使用`Content`属性来定义内容，例如`<Button Content="Button" />`，这样就在控件中显示内容了。