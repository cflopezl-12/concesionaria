using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Succeeded { get; }
        public string? Message { get; }
        public IReadOnlyDictionary<string, string[]>? Errors { get; }
        public T? Data { get; }

        public ApiResponse(T data, string? message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
            Errors = null;
        }

        public ApiResponse(string message, IReadOnlyDictionary<string, string[]>? errors = null)
        {
            Succeeded = false;
            Message = message;
            Errors = errors;
            Data = default;
        }

        public static ApiResponse<T> Success(T data, string? message = null)
                                        => new(data, message);

        public static ApiResponse<T> Fail(string message, IReadOnlyDictionary<string, string[]>? errors = null)
                                        => new(message, errors);
    }

}
