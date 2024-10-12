public class Character
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Alias { get; set; }
    public string Raza { get; set; }
    public string FotoUrl { get; set; }
    public int Edad { get; set; }
    public string PoderCaracteristico { get; set; }
    public int SeriesMovieBookId { get; set; }
    public SeriesMovieBook SeriesMovieBook { get; set; }
}