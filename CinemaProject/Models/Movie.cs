using System;

namespace CinemaProject.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
        public string PosterPath { get; set; }
        public string VideoPath480p { get; set; }
        public string VideoPath720p { get; set; }
        public string VideoPath1080p { get; set; }

        public Movie(int id, string title, string genre, double rating)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Rating = rating;
            Description = string.Empty;
            PosterPath = string.Empty;
            VideoPath480p = "video_480p.mp4";
            VideoPath720p = "video_720p.mp4";
            VideoPath1080p = "video_1080p.mp4";
        }

        public Movie()
        {
            Title = string.Empty;
            Description = string.Empty;
            Genre = string.Empty;
            PosterPath = string.Empty;
            VideoPath480p = "video_480p.mp4";
            VideoPath720p = "video_720p.mp4";
            VideoPath1080p = "video_1080p.mp4";
        }

        public string GetVideoPathByQuality(string quality)
        {
            switch (quality)
            {
                case "480p":
                    return VideoPath480p;
                case "1080p":
                    return VideoPath1080p;
                default:
                    return VideoPath720p;
            }
        }
    }
}