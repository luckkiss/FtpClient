# FtpClient
项目发布辅助工具，提升效率工具
用到本地数据库SQLite
项目运行会自动创建本地数据库和相关表
完整发布
增量发布（通过比较文件hash值判断文件是否发生改变）
子线程通过匿名委托更新界面防止界面卡死
完整发布比较耗时,增加确认提示框避免不必要的完整发布
增加快捷操作栏 一键增量发布当前项目