using System.IO.Compression;
using System.Text;

namespace NewChart2OldPhiraReadable;

internal class Program
{
    static void Main(string[] args)
    {
        string filePath = args[0];

        var PEZfile = new ZipArchive(File.Open(filePath, FileMode.Open, FileAccess.ReadWrite), ZipArchiveMode.Update);
        var entry = PEZfile.GetEntry("info.txt");
        var infoFileStream = entry.Open();
        byte[] infoContentBuffer = new byte[infoFileStream.Length];
        infoFileStream.Read(infoContentBuffer, 0, infoContentBuffer.Length);
        string[] infoContentByLines = 
            Encoding.UTF8.GetString(infoContentBuffer)
                         .Replace("\r\n", "\uaaaa").Replace("\n", "\uaaaa")
                         .Split("\uaaaa")[1..];
        string[] allowFields =
            ["Name", "Path", "Song", "Picture", "Chart", "Level", "Composer", "Charter"];

        StringBuilder sb = new();
        sb.AppendLine("#");
        foreach(string line in infoContentByLines)
        {
            if (allowFields.Any(x => x == line.Split(":")[0]))
            {
                sb.AppendLine(line);
            }
        }

        infoFileStream.Seek(0, SeekOrigin.Begin);
        infoFileStream.Write(Enumerable.Repeat((byte)0, (int)infoFileStream.Length).ToArray(), 0, (int)infoFileStream.Length);
        infoFileStream.Seek(0, SeekOrigin.Begin);

        byte[] newInfoBinary = Encoding.UTF8.GetBytes(sb.ToString());
        infoFileStream.Write(newInfoBinary, 0, newInfoBinary.Length);
        infoFileStream.SetLength(newInfoBinary.Length);
        infoFileStream.Close();

        PEZfile.Dispose();
    }
}