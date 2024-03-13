using System;

namespace coreApi.Models.Generic;

public class Result
{
    public bool Success { get; set; }

    public string Message { get; set; }

    public string TechMessage { get; set; }

    public Exception Exception { get; set; }
}

public class Result<T> : Result
{
    public T Data { get; set; }
}
