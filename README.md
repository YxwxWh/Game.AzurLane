# Game.AzurLane
 复刻手游碧蓝航线的部分功能
 此游戏是我和同学一起开发，我负责游戏UI界面的搭建和游戏内玩家与装备数据的确定以及各个页面的数据交互
 

复刻手游碧蓝航线部分功能，使用MVC设计模式，界面使用UGUI绘制，使用Json序列化与反序列化对数据进行操作，核心模块使用C#开发。
核心系统：角色背包系统，装备背包系统，人物养成系统。

角色背包系统：利用Json读取玩家角色背包的动态数据和静态数据，根据动态数据中的角色ID与本地数据的ID匹配后，合并数据并把角色信息显示在界面。
装备背包系统：机制与角色背包一致，读取到动态与静态数据后根据装备ID匹配后进行合并，随后刷新在背包界面。可以对装备进行售卖和强化操作。玩家所拥有的金币会根据强化或售卖操作变化而变化。
人物养成系统：角色每升一级属性都会成长，同时也可以穿戴装备来增加属性。在进行穿戴装备时会从json表里分离出当前选择的角色的数据，对其数据进行修改后存回数据表并立即刷新一次数据以防止数据出现显示错误

萌新一枚，代码若有不足与错误还请多多包涵

https://www.bilibili.com/video/av58029861/ 视频链接
