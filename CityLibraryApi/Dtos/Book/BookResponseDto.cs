namespace CityLibraryApi.Dtos.Book;

public class BookResponseDto : BookLoaderDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime? LastUpdatedAt { get; set; }

    public string CreatedBy { get; set; }
    
    public string LastUpdatedBy { get; set; }
}