# YSServerChangeSetting
Genshin Impact tool, which is used to convert CN and OS services, is essentially a replacement file. Of course, there may be a better conversion method, capturing packet change requests, which are not provided here.
1. Download the replacement files for CN and OS servers and place them in the corresponding folders. It is recommended to use the same drive letter as the game. You know that cutting the same drive letter does not require reading or writing to the disk. No files provided here
2. Create a folder named GenshinFileCut with unlimited drive letters.
3. Create folders Setting, CN, and OS under GenshinFileCut.
4. Clone this project locally.
5. Microsoft Video Studio opens the YSServerChangeSetting.sln file to generate the project.
6. Copy the files from YSServerChangeSetting  bin  release or debug to the Setting folder created in the second step.
7. Clone SourceGameServer [CN initiator] to local.
After Microsoft Video Studio opens SourceGameServer.sln to generate the project, copy the files from SourceGameServer  bin  release or debug to the CN folder created in step three.
9. Clone GlobalServer [OS initiator] to local.
10. After Microsoft Video Studio opens GlobalServer.sln to generate the project, copy the files from GlobalServer  bin  release or debug to the OS folder created in step three.
11. Start YSServerChangeSetting.exe, select the game exe directory and the file directory extracted in the first step. After success, the corresponding files and file names will be listed. Save the configuration, and a config file will be generated in the current directory.
12. Compare the config file under config and YSServerChangeSetting  bin, and copy the excess attribute values from the bin file to the config file.
13. Copy the config file obtained in the previous step to the folder created in the second step, and change the LastLogin attribute to the server [CN or OS] where you last logged in or replaced the file.
Steps 11 to 13 only need to be executed once before the first switch
14. Start the game. Start the corresponding server's launcher.
After Genshin Impact is updated to the next version, or when the replacement files of CN and OS servers have changed significantly, it is necessary to repeat steps 11 to 13

原神工具，用来CN与OS服务转换，本质是替换文件。当然或许有更好的转换方法，抓包改变请求，这里不提供。
1.下载CN和OS服的替换文件，放到相应文件夹内，建议和游戏同盘符，你知道同盘符的剪切是不怎么需要读写磁盘的。这里不提供文件。
2.创建文件夹GenshinFileCut，盘符不限。
3.在GenshinFileCut下创建文件夹Setting、CN、OS。
4.将本项目clone到本地。
5.Microsoft Visuo Studio打开YSServerChangeSetting.sln文件生成项目。
6.将YSServerChangeSetting\bin\release或debugg里的文件复制到第二步创建的Setting文件夹。
7.clone SourceGameServer【CN启动器】到本地。
8.Microsoft Visuo Studio打开SourceGameServer.sln生成项目后，将SourceGameServer\bin\release或debugg里的文件复制到第三步创建的CN文件夹。
9.clone GlobalServer【OS启动器】到本地。
10.Microsoft Visuo Studio打开GlobalServer.sln生成项目后，将GlobalServer\bin\release或debugg里的文件复制到第三步创建的OS文件夹。
11.启动YSServerChangeSetting.exe，选择游戏exe目录与第一步解压的文件目录，成功后会列出相应文件和文件名，保存配置，会在当前目录下生成config文件。
12.对比config和YSServerChangeSetting\bin下的config文件，将bin下的文件多余的属性值复制到config文件。
13.将上一步获取的config文件复制到第二步创建的文件夹下，并将其中的LastLogin属性改为你上次登录或替换文件后的服【CN或OS】。
【第十一步到第十三步骤只需首次切换前执行一次】。
14.开始游戏。启动对应服的启动器。
原神更新到下一个版本后或CN和OS服的替换文件有大变化时，需重复第十一步到十三步的操作。
