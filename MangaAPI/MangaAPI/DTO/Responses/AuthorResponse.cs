﻿namespace MangaAPI.DTO.Responses
{
    public class AuthorResponse
    {
        public ulong AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? Biography { get; set; }
        public string? BirthDate { get; set; }
        public string? AuthorImage { get; set; }
    }
}
