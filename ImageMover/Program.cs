// See https://aka.ms/new-console-template for more information

// args = new string[] { "/Users/lewis/Downloads/xianju/18" };

var path = args.ElementAtOrDefault(0);
if (string.IsNullOrWhiteSpace(path))
{
    Console.WriteLine("前输入图片根目录");
    return;
}

var di = new DirectoryInfo(path);
if (!di.Exists)
{
    Console.WriteLine("图片根目录不存在");
    return;
}


var directories = Directory.GetDirectories(path);

foreach (var directory in directories)
{
    var interval = Path.GetRelativePath(path, directory);
    var files = Directory.GetFiles(directory);
    foreach (var file in files)
    {
        var name = Path.GetFileName(file);
        var newFileName = $"{di.Name}_{interval}_{name}";
        var targetPath = Path.Combine(path, newFileName);
        if (!File.Exists(targetPath))
        {
            File.Copy(file, targetPath);
        }

        Console.WriteLine($"{newFileName} moved");
    }
}

Console.WriteLine("Bye!");