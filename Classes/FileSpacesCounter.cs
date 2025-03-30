using System.Threading.Tasks;

namespace MultiFileReader;

public class FileSpacesCounter : IFileSpacesCounter
{
    public async Task<int> CountSpaces(string filePath)
    {
        validateFilePath(filePath);

        string fileText = await File.ReadAllTextAsync(filePath);
        var spaceCount = fileText.Count(x => x == ' ');
        return spaceCount;
    }

    /// <summary>
    /// Проверка на валидность имени файла.
    /// </summary>
    /// <param name="filePath"> Путь к файлу.</param>
    /// <exception cref="ArgumentNullException"> Имя файла не может быть пустым. </exception>
    /// <exception cref="ArgumentException"> Такого файла не существует. </exception>
    private void validateFilePath(string filePath)
    {
        if (String.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentNullException("Имя файла не может быть пустым!");
        }
        if (!File.Exists(filePath))
        { throw new ArgumentException($"Файла {Path.GetFileName(filePath)} не существует!"); }
    }
}
