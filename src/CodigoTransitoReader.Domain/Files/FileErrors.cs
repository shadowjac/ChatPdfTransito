using CodigoTransitoReader.Domain.Abstractions;

namespace CodigoTransitoReader.Domain.Files;

public static class FileErrors
{
    public static Error NotFound => new Error("File.NotFound", "File Not Found");
    public static Error InvalidFile => new Error("File.InvalidFile", "Invalid File");
    public static Error InvalidFileExtension => new Error("File.InvalidFileExtension", "Invalid File Extension");
    public static Error FileAlreadyExists => new Error("File.FileAlreadyExists", "File Already Exists");
}