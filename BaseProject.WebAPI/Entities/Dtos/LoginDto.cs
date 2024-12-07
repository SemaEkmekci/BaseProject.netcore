namespace BaseProject.WebAPI.Entities.Dtos
{
    public sealed record LoginDto(string email, string password);
    // record türündeki nesneler değiştirilemez. Bu dto classı yalnıza veri taşıma için kullanılır.
    // sealed sınıflar türetilemez.
}
