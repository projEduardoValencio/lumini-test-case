﻿namespace Lumini.Communication.Responses.Route;

public class ResponseLowCostTravel
{
    public List<string> Path { get; set; } = new List<string>();
    public decimal TotalValue { get; set; }
}