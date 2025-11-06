# WinFrom

**新建一个WiFrom项目后，会生成一个**

* Form1.cs 直接双击会打开一个窗口页面，视图-工具箱中可以通过鼠标拖动工具箱中的各种控件，如按钮，多选框，下拉框等到页面（类似安卓的拖动控件布局）

  * Form1.cs  **主要定义 事件，业务，逻辑处理的相关代码**

    ```C#
    //通过 partial 关键字将Form类在两个文件中定义
    public partial class Form1 : Form
    
    public Form1()
    {
        InitializeComponent();
    }
    ```

  * Form1.Designer.cs   **主要定义 设计，外观的相关代码**

    ```C#
    // 定义各种控件
    partial class Form1
    ```

    

* Form.resx 据说是资源文件，点开后是可以创建一条条记录：名称，类型，值，注释



**当通过工具箱拖动一个 按钮控件 到Form1.cs的窗口页面上会发生什么**

* Form1.Designer.cs 中 定义一个 Button，其次会在InitializeComponent()方法中初始化这个Button

```C#
private System.Windows.Forms.Button button1;

// 这个方法会在 public partial class Form1 : Form 的构造器中被调用
private void InitializeComponent() {
    this.button1 = new System.Windows.Forms.Button();
    this.button1.Location = new System.Drawing.Point(637, 167);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(75, 23);
    this.button1.TabIndex = 0;
    this.button1.Text = "button1";
    this.button1.UseVisualStyleBackColor = true;
    this.button1.Click += new System.EventHandler(this.button1_Click);// 点击事件
}
```

* Form1.cs 会在这边定义点击事件

```C#
private void button1_Click(object sender, EventArgs e)
{
}
```



# 手动创建窗口

```C#
// 窗口
class MyForm : Form {
    
}

// 启动
static void Main() {
    Application.Run(new MyForm())
}
```











































