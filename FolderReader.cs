
using System.Diagnostics;

namespace MultiFileReader;

public class FolderReader : IFolderReader
{
    IFileSpacesCounter fileSpacesCounter = new FileSpacesCounter();

    public List<Task> GetTasks(string folderPath)
    {
        validateFilePath(folderPath);

        var files = Directory.GetFiles(folderPath).ToList();
        var tasks = new List<Task>();

        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);

            var task = Task.Run(async () =>
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                var count = await fileSpacesCounter.CountSpaces(file);
                Console.WriteLine($"Файл {fileName} содержит пробелы в количестве: {count}.");

                stopWatch.Stop();
                Console.WriteLine($"Считывание файла {fileName} заняло {stopWatch.ElapsedMilliseconds} мс");
            });
            tasks.Add(task);
        }
        return tasks;
    }

    /// <summary>
    /// Проверка корректности пути к папке.
    /// </summary>
    /// <param name="folderPath"> Путь к папке. </param>
    /// <exception cref="ArgumentNullException"> Имя файла пустое. </exception>
    /// <exception cref="ArgumentException"> Папка не найдена, либо в ней нет файлов. </exception>
    private void validateFilePath(string folderPath)
    {
        if (String.IsNullOrWhiteSpace(folderPath))
        {
            throw new ArgumentNullException("Путь к папке не может быть пустым!");
        }
        if (!Directory.Exists(folderPath))
        {
            throw new ArgumentException($"Папки {Path.GetFileName(folderPath)}, находящейся по адресу {Path.GetFullPath(folderPath)} не существует!");
        }
        if (!Directory.GetFiles(folderPath).Any())
        {
            throw new ArgumentException($"В папке {Path.GetFileName(folderPath)}, находящейся по адресу {Path.GetFullPath(folderPath)}, нет файлов!");
        }
    }
}
