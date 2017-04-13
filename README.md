# WebForm3LayerArch
Asp.Net three layer architecture : Web, BLL, IDAL, DAL, Model, DALFactory

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=
项目文件架构
 
1. Web
 
表现层
 
Web页和控件
 
引用BLL
 
WebUI.aspx
WebUI.aspx.cs 
GetContent()
 
2. BLL
 
业务逻辑层
 
业务逻辑组件
 
引用 IDAL，Model，使用DALFactory创建实例
 
Content.cs
 
ContentInfo GetContentInfo(int id)
 
3. IDAL
 
数据访问层接口定义
 
每个DAL实现都要实现的一组接口
 
引用 Model
 
IContent.cs
 
ContentInfo GetContentInfo(int id)
 
4. Model
 
业务实体
 
传递各种数据的容器
 
无引用
 
ContentInfo.cs
 
5. DALFactory
 
数据层的抽象工厂
 
创建反射，用来确定加载哪一个数据库访问程序集的类
 
引用IDAL，通过读取web.config里设置的程序集，加载类的实例，返回给BLL使用。
 
Content.cs
 
IDAL.Icontent create()
 
6. DAL
 
SQLServer数据访问层
 
Microsoft SQL Server特定的Pet Shop DAL实现，使用了IDAL接口
 
引用 Model和IDAL，被DALFactory加载的程序集，实现接口里的方法。
 
SqlHelper.cs 
Content.cs
 
SqlDataReader ExecuteReader()
PrepareCommand()
ContentInfo GetContentInfo(int id)
 
OracleDAL
 
Oracle数据访问层
 
7. DBUtility
 
数据库访问组件基础类
 
GetSqlServerConnectionString得到数据库连接字符串，也可省去该项目，在SQLServerDAL.SqlHelper中用static readonly string SqlConnectionString代替。
 
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=
 
实现步骤过程
1、创建Model，实现业务实体。
2、创建IDAL，实现接口。
3、创建SQLServerDAL，实现接口里的方法。
4、增加web.config里的配置信息，为SQLServerDAL的程序集。
5、创建DALFactory，返回程序集的指定类的实例。
6、创建BLL，调用DALFactory，得到程序集指定类的实例，完成数据操作方法。
7、创建WEB，调用BLL里的数据操作方法。
注意：
1、web.config里的程序集名称必须与SQLServerDAL里的输出程序集名称一致。
2、DALFactory里只需要一个DataAccess类，可以完成创建所有的程序集实例。
3、项目创建后，注意修改各项目的默认命名空间和程序集名称。
4、注意修改解决方案里的项目依赖。
5、注意在解决方案里增加各项目引用。

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=
++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++=

各层间的访问过程
1、传入值，将值进行类型转换(为整型)。
2、创建BLL层的content.cs对象c，通过对象c访问BLL层的方法GetContentInfo(ID)调用BLL层。
3、BLL层方法GetContentInfo(ID)中取得数据访问层SQLServerDAL的实例,实例化IDAL层的接口对象dal，这个对象是由工厂层DALFactory创建的，然后返回IDAL层传入值所查找的内容的方法dal.GetContentInfo(id)。
4、数据工厂通过web.config配置文件中给定的webdal字串访问SQLServerDAL层，返回一个完整的调用SQLServerDAL层的路径给 BLL层。
5、到此要调用SQLServerDAL层，SQLServerDAL层完成赋值Model层的对象值为空，给定一个参数，调用SQLServerDAL层的SqlHelper的ExecuteReader方法,读出每个字段的数据赋值给以定义为空的Model层的对象。
6、SqlHelper执行sql命令，返回一个指定连接的数据库记录集，在这里需要引用参数类型，提供为打开连接命令执行做好准备PrepareCommand。
7、返回Model层把查询得到的一行记录值赋值给SQLServerDAL层的引入的Model层的对象ci，然后把这个对象返回给BLL。
8、回到Web层的BLL层的方法调用,把得到的对象值赋值给Lable标签，在前台显示给界面
