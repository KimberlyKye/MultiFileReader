namespace MultiFileReader;

/// <summary>
/// Клас предназначен для подсчета пробелов в файле.
/// </summary> 
public interface IFileSpacesCounter
{
    /// <summary>
    /// Метод для подсчета пробелов в файле.
    /// </summary>
    /// <param name="filePath"> Путь к файлу, в котором будет произведен подсчет пробелов. </param>
    /// <returns> Количество пробелов в файле. </returns>
    public Task<int> CountSpaces(string filePath);
}
