namespace MultiFileReader;

/// <summary>
///  Класс для чтения файлов из папки. 
/// </summary>
public interface IFolderReader
{
    /// <summary>
    /// Считает все файлы из папки и вернет задачи на вывод количества пробелов в них в консоль.
    /// </summary>
    /// <param name="folderPath">Путь к папке.</param>
    /// <returns> Список задач, содержащий вывод количества пробелов в консоль. </returns>
    public List<Task> GetTasks(string folderPath);
}
