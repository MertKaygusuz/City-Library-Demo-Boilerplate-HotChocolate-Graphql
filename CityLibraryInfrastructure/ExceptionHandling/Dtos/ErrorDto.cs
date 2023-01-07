using System;
using System.Collections.Generic;

namespace CityLibraryInfrastructure.ExceptionHandling.Dtos;

[Serializable]
public class ErrorDto
{
    public ErrorDto()
    {
        
    }

    /// <summary>
    /// Create new instance and set the errors to "CustomError" key in Errors dictionary
    /// </summary>
    public ErrorDto(IEnumerable<string> errors)
    {
        Errors.Add("CustomError", errors);
    }

    /// <summary>
    /// Create new instance and set only one error text to "CustomError" key in Errors dictionary
    /// </summary>
    public ErrorDto(string errorText)
    {
        Errors.Add("CustomError", new List<string>() {errorText});
    }


    public string InternalErrorMessage { get; set; }

    public string InternalStackTrace { get; set; }

    public string InternalSource { get; set; }

    public Dictionary<string, IEnumerable<string>> Errors { get; set; } = new();
}