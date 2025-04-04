﻿using MarketToolsV3.FakeData.WebApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Nodes;

namespace MarketToolsV3.FakeData.WebApi.Application.Models
{
    public class NewTaskDetailsDto
    {
        public string? Tag { get; set; }
        public TaskEndCondition TaskEndCondition { get; set; }
        public TaskCompleteCondition TaskCompleteCondition { get; set; }
        public int NumberOfExecutions { get; set; }
        public int TimeoutBeforeRun { get; set; }
        public string? Path { get; set; }

        [Required(ErrorMessage = "Необходимо ввести метод HTTP запроса.")]
        public required string Method { get; set; }
        public JsonNode? Body { get; set; }
        public int? NumGroup { get; set; }
    }
}
