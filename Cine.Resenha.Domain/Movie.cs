﻿namespace Cine.Resenha.Domain;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string CoverLink { get; set; }
    public string WhoChose { get; set; }
    public int ReleaseYear { get; set; }
    public DateTime? WatchedDate { get; set; }
    public decimal Rating { get; set; } = 0.0m;
    public int Duration { get; set; } = 0;
    public bool Watched { get; set; } = false;
}