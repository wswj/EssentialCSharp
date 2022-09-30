using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCSharp
{
    /// <summary>
    /// 递归计算当前文件夹下的代码行数
    /// </summary>
    public class TestRecurrence
    {
        static void Main(string[] args)
        {
            string fileName = "";
            if (args.Length == 0)
            {
                fileName = Directory.GetCurrentDirectory();
            }else
            {
                fileName = args[0];
            }
            int lineCount= GetDirectorLineCounts(fileName);
            Console.WriteLine(lineCount);
        }
        static int GetDirectorLineCounts(string directorName)
        {
            int lineCount = 0;
            var files = Directory.GetFiles(directorName, "*.cs");
            foreach (var file in files)
            {
                lineCount += LineCounts(file);
            }
            foreach (var director in Directory.GetDirectories(directorName))
            {
                lineCount += GetDirectorLineCounts(director);
            }
            return lineCount;
        }
        static int LineCounts(string file)
        {
            if (string.IsNullOrEmpty(file)) throw new Exception("文件名不能为空");
            string line = null;
            int lineCount = 0;
            FileStream stream = File.OpenRead(file);
            StreamReader reader = new StreamReader(stream);
            line = reader.ReadLine();
            while (line != null)
            {
                if (line.Trim() != "")
                {
                    lineCount++;
                }
                line = reader.ReadLine();
            }
            return lineCount;
        }
    }
}
