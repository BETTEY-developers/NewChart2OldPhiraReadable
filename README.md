#  NewChart2OldPhiraReadable
一个将新版本(>=1.5)RPE(Re: PhiEdit)导出的pez文件格式转换成旧版Phira能够读取的谱面格式的小工具

## How to build
`csc Program.cs`

或

`msbuild <YourWorkDirectory>\NewChart2OldPhiraReadable.sln`

## How to use

### Step

将不可读取的pez格式文件拖动到名为`NewChart2OldPhiraReadable.exe`或在该可执行文件所在目录下输入`NewChart2OldPhiraReadable <YourChartFilePath>`即可运行

### Result

该过程将在pez格式文件内进行，当转换完成后，你将会在pez格式文件里面的`info.txt`里面看到内容的改变

*注意：转换前提为"info.txt等各项文件格式正确"且转换目标为"新版本RPE导出的pez格式文件"而非"人为修改而导致损坏的pez格式文件"，请注意。（好孩子不要乱玩转换器，会玩坏的xwx）----

## Author

Elipese. 2024
