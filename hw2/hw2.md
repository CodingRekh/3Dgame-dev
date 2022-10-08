# 离散仿真引擎基础

## 简答题

### 1. 解释游戏对象和资源的区别与联系

**区别**：**游戏对象**是具有一定属性与功能的类的实体化，直接出现在游戏中，例如游戏中常见的玩家、怪物等；**资源**是预先准备好的模型、图片、音乐等文件数据，可以直接并重复使用。
  
**联系**：**资源**可以添加到**游戏对象作**为其一部分，而**游戏对象**可以保存作为一种**资源**以便捷地重复使用。

### 2. 以游戏案例分别总结资源、对象组织的结构

**资源目录组织结构**：一般包含Animation(动画)、Matreias(材料)、Prefab(预制)、Scene(场景)、Scripts(脚本)、Sprites(精灵)等；

**游戏对象树层次结构**：一般包含Camera(摄像头)、Background(背景)、Light(灯光)和一些自定义对象等。

### 3. 编写一段代码并使用debug语句验证MonoBehaviour基本行为或事件触发的条件

- **基本行为包括**: Awake() Start() Update() FixedUpdate() LateUpdate()
- **常用事件包括**: OnGUI() OnDisable() OnEnable()

#### 代码片段
```Csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update");
    }

    void Awake()
    {
        Debug.Log("Awake");
    }

    void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }

    void LateUpdate()
    {
        Debug.Log("LateUpdate");
    }

    void OnGUI()
    {
        Debug.Log("OnGUI");
    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}
```
#### 运行截图
![运行截图](/hw2/src/2.png "运行截图")

### 4. 了解 GameObject,Transform,Component 对象

#### 分别翻译官方对三个对象的描述

- GameObject: Unity场景中所有实体的基类；
- Transform: 描述物体的位置、旋转、大小；
- Component: 附加在游戏对象上的所有东西的基类。

#### 描述 table 对象（实体）的属性、table 的 Transform 的属性、 table 的部件

##### Table 对象（实体）的属性
- Name: 对象的名字；
- Static: 准备静态几何结构以用于自动批处理；
- Tag: 对象的标签；
- Layer: 可用于仅对某些特定的对象组投射光线、渲染或应用光照；

##### Transform 的属性
- Position: X、Y 和 Z 坐标中变换的位置；
- Rotation: 围绕 X、Y 和 Z 轴的旋转角度；
- Scale: 沿 X、Y 和 Z 轴的缩放。

#### 用UML图描述 三者的关系
![UML图](/hw2/src/1.png "UML图")

### 5. 资源预设与对象克隆（clone）

#### 预设有什么好处

**预设**是预制好的游戏对象，包含了完整的组件和属性。利用预制能够批量实例化出具有相同属性的游戏对象，提高工作效率。

#### 预设与对象克隆的关系

- **预设**：产生的对象与预设的对象是联系的，当修改预设时，它产生出来的对象也会被修改；
- **克隆**：克隆体和母体之间是独立的，修改不会互相干扰。

#### 写一段代码将Table预制资源实例化成游戏对象

```Csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createTable : MonoBehaviour
{
    public GameObject table;

    void Start()
    {
        GameObject temp = (GameObject)Instantiate(table, transform.position, transform.rotation);
    }

    void Update()
    {
    }
}
```

## 小型游戏项目代码

### 代码片段

```
Hello World
```