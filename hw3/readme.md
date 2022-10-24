# 空间与运动

##  游戏对象运动的本质是什么？

游戏对象运动的本质是游戏对象空间属性的改变过程。

## 使用三种方法实现物体的抛物线运动

[**项目地址**](/hw3/transform_script/)

### 方法1. 对transform属性赋增值
```Csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Transform : MonoBehaviour
{

    public float v0 = 3.0f; //初速度
    public float a = 1.0f; //加速度
    private float vt; //纵向速度

    // Start is called before the first frame update
    void Start()
    {
        vt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vt += a;
        this.transform.position += Time.deltaTime * Vector3.right * v0;
        this.transform.position += Time.deltaTime * Time.deltaTime * Vector3.down * vt;
    }
}
```

### 方法2. 用Vector3计算位移
```Csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Vector : MonoBehaviour
{

    public float v0 = 3.0f; //初速度
    public float a = 1.0f; //加速度
    private float vt; //纵向速度

    // Start is called before the first frame update
    void Start()
    {
        vt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vt += a;
        Vector3 v = new Vector3(Time.deltaTime * v0, -Time.deltaTime * vt, 0);
        transform.position += v;
    }
}
```

### 方法3. 使用Translate函数
```Csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Translate : MonoBehaviour
{

    public float v0 = 3.0f; //初速度
    public float a = 1.0f; //加速度
    private float vt; //纵向速度

    // Start is called before the first frame update
    void Start()
    {
        vt = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        vt += a;
        Vector3 v = new Vector3(Time.deltaTime * v0, -Time.deltaTime * vt, 0);
        transform.Translate(v);
    }
}

```

## 太阳系仿真

[**项目地址**](/hw3/solar_system/)

## 牧师与魔鬼小游戏

[**项目地址**](/hw3/priest_and_devil/)