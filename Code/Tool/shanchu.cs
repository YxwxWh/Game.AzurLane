using UnityEngine;

public static class shanchu
{
    public static void DeleteAllChild(this Transform trf)
    {
        //不需要获得所有子物体，只需要获得所有下方的一级物体
        //trf.childCount：可以获得所有子物体数量
        //trf.GetChild：可以通过下标获得所有的第一级子物体
        for (int i = 0; i < trf.childCount; i++)
        {
            Transform child = trf.GetChild(i);
            //将这个游戏对象，标记为待删除（下一帧开始前删除）
            //因为在被删除的对象上可能包含在帧末尾运行的生命周期函数，所以为了保证声明周期函数的正常运行，一般使用Destroy删除对象
            GameObject.Destroy(child.gameObject);
            //在for循环中，立即删除游戏对象（因为会打乱下标顺序，所以需要倒序删除）
            //GameObject.DestroyImmediate(child.gameObject);

            //GameObject.Destroy()和Object.Destroy()是一样的，因为GameObject是Object的子类

            //Object和object的区别
            //Object是Unity内置类的父类，资源，游戏物体
            //object可以代表各种数据类型，任意数据类型都可以转换为object
        }
    }
}