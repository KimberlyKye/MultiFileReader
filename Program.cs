using MultiFileReader;

var folderPath = "";

while (String.IsNullOrWhiteSpace(folderPath))
{
    Console.WriteLine("Введите путь к папке:");
    folderPath = Console.ReadLine();
}

IFolderReader reader = new FolderReader();

var tasks = reader.GetTasks(folderPath);

await Task.WhenAll(tasks);
