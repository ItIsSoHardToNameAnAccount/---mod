# 简单写一下
## 物品数据
* 游戏在jsonData的init函数中读取物品的json数据，所以添加物品在该函数执行后用Postfix补丁往它的输出jsondata中追加数据即可，格式和官方的d_items.py.datas.json文件保持一致。

## 物品效果（seid）
* 完全自定义的效果可以不需要编写seid的json文件，直接用Prefix补丁对realizeSeid函数进行扩展即可，如果要编写json文件，注意id大小不能超过500.

## 丹方数据
* 这个就是天坑，创意工坊上有mod能实现了自定义丹方，有的又不行，我查阅了好久的代码，实在没看明白那堆没有注释的算法逻辑，但是有一点可以肯定，丹方是不能完全自定义的，如果写了丹方但练出来是废丹，说明丹方设置有问题，最好参考原版丹方进行微调。
