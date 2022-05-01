using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeAPI.Web.Data
{
    public interface IResult
    {
        public int StatusCode { get; }

        public bool IsSuccess { get; }

        public object Value { get; }

        public IEnumerable<Tuple<string, string>> Errors { get; }
    }

    public class Result : IResult
    {
        public int StatusCode { get; private set; }

        public bool IsSuccess => StatusCode >= 200 && StatusCode <= 299;

        protected object _Value;
        public object Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();
                return _Value;
            }
        }
        
        private List<Tuple<string, string>> _Errors = new List<Tuple<string, string>>();
        public IEnumerable<Tuple<string, string>> Errors => _Errors;

        protected Result(int statusCode)
        {
            StatusCode = statusCode;
        }

        public static Result Ok() => new(200);
        public static Result<T> Ok<T>(T value) => new(200, value);

        public static Result BadRequest() => new(400);
        public static Result<T> BadRequest<T>(T value) => new(400, value);

        public static Result NotFound() => new(404);
        public static Result<T> NotFound<T>(T value) => new(404, value);

        public static Result ServerError() => new(500);
        public static Result<T> ServerError<T>(T value) => new(500, value);
    }

    public class Result<T> : Result
    {
        public new object Value
        {
            get
            {
                return (T)base.Value;
            }
        }

        internal Result(int statusCode, T value = default) : base(statusCode)
        {
            _Value = value;
        }

        
    }
}
