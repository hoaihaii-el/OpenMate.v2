﻿namespace OpenMate.API.Domain.DTOs
{
    public class MessageDto
    {
        public int? RoomId { get; set; }
        public string? SenderId { get; set; }
        public string? Text { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
    }
}
