public class SeriesMovieBook
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Pais { get; set; }
    public string Idioma { get; set; }
    public string FotoUrl { get; set; }
    public string Resumen { get; set; }
    public List<Character> Characters { get; set; }
}