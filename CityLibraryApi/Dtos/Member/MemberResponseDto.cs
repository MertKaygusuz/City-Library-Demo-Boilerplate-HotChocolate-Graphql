namespace CityLibraryApi.Dtos.Member;

public class MemberResponseDto : MemberLoaderDto
{
    public DateTime CreatedAt { get; set; }

    public DateTime? LastUpdatedAt { get; set; }

    public string LastUpdatedBy { get; set; }
}