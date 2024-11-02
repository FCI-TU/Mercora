using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindIt.Application.ErrorHandling
{
	public enum StatusCode
	{
		Continue = 100,
		SwitchingProtocols = 101,
		Processing = 102,
		EarlyHints = 103,
		Checkpoint = 103,
		Ok = 200,
		Created = 201,
		Accepted = 202,
		NonAuthoritativeInformation = 203,
		NoContent = 204,
		ResetContent = 205,
		PartialContent = 206,
		MultiStatus = 207,
		AlreadyReported = 208,
		ImUsed = 226,
		MultipleChoices = 300,
		MovedPermanently = 301,
		Found = 302,
		MovedTemporarily = 302,
		SeeOther = 303,
		NotModified = 304,
		UseProxy = 305,
		TemporaryRedirect = 307,
		PermanentRedirect = 308,
		BadRequest = 400,
		Unauthorized = 401,
		PaymentRequired = 402,
		Forbidden = 403,
		NotFound = 404,
		MethodNotAllowed = 405,
		NotAcceptable = 406,
		ProxyAuthenticationRequired = 407,
		RequestTimeout = 408,
		Conflict = 409,
		Gone = 410,
		LengthRequired = 411,
		PreconditionFailed = 412,
		PayloadTooLarge = 413,
		RequestEntityTooLarge = 413,
		UriTooLong = 414,
		RequestUriTooLong = 414,
		UnsupportedMediaType = 415,
		RequestedRangeNotSatisfiable = 416,
		ExpectationFailed = 417,
		IAmATeapot = 418,
		InsufficientSpaceOnResource = 419,
		MethodFailure = 420,
		DestinationLocked = 421,
		UnprocessableEntity = 422,
		Locked = 423,
		FailedDependency = 424,
		TooEarly = 425,
		UpgradeRequired = 426,
		PreconditionRequired = 428,
		TooManyRequests = 429,
		RequestHeaderFieldsTooLarge = 431,
		UnavailableForLegalReasons = 451,
		InternalServerError = 500,
		NotImplemented = 501,
		BadGateway = 502,
		ServiceUnavailable = 503,
		GatewayTimeout = 504,
		HttpVersionNotSupported = 505,
		VariantAlsoNegotiates = 506,
		InsufficientStorage = 507,
		LoopDetected = 508,
		BandwidthLimitExceeded = 509,
		NotExtended = 510,
		NetworkAuthenticationRequired = 511,
	}
	public class Status
	{
		private static readonly Dictionary<int, string> httpStatusCodeMessage = new Dictionary<int, string> {
			{ 100, "Continue"},
			{ 101, "Switching Protocols"},
			{ 102, "Processing"}, { 103, "Early Hints"},
			{ 200, "OK"},
			{ 201, "Created"},
			{ 202, "Accepted"},
			{ 203, "Non-Authoritative Information"},
			{ 204, "No Content"},
			{ 205, "Reset Content"},
			{ 206, "Partial Content"},
			{ 207, "Multi-Status"},
			{ 208, "Already Reported"},
			{ 226, "IM Used"},
			{ 300, "Multiple Choices"},
			{ 301, "Moved Permanently"},
			{ 302, "Found"},
			{ 303, "See Other"},
			{ 304, "Not Modified"},
			{ 305, "Use Proxy"},
			{ 307, "Temporary Redirect"},
			{ 308, "Permanent Redirect"},
			{ 400, "Bad Request"},
			{ 401, "Unauthorized"},
			{ 402, "Payment Required"},
			{ 403, "Forbidden"},
			{ 404, "Not Found"},
			{ 405, "Method Not Allowed"},
			{ 406, "Not Acceptable"},
			{ 407, "Proxy Authentication Required"},
			{ 408, "Request Timeout"},
			{ 409, "Conflict"},
			{ 410, "Gone"},
			{ 411, "Length Required"},
			{ 412, "Precondition Failed"},
			{ 413, "Payload Too Large"},
			{ 414, "Request-URI Too Long"},
			{ 415, "Unsupported Media Type"},
			{ 416, "Requested range not satisfiable"},
			{ 417, "Expectation Failed"},
			{ 418, "I'm a teapot"},
			{ 419, "Insufficient Space On Resource"},
			{ 420, "Method Failure"},
			{ 421, "Destination Locked"},
			{ 422, "Unprocessable Entity"},
			{ 423, "Locked"},
			{ 424, "Failed Dependency"},
			{ 425, "Too Early"},
			{ 426, "Upgrade Required"},
			{ 428, "Precondition Required"},
			{ 429, "Too Many Requests"},
			{ 431, "Request Header Fields Too Large"},
			{ 451, "Unavailable For Legal Reasons"},
			{ 500, "Internal Server Error"},
			{ 501, "Not Implemented"},
			{ 502, "Bad Gateway"},
			{ 503, "Service Unavailable"},
			{ 504, "Gateway Timeout"},
			{ 505, "HTTP Version not supported"},
			{ 506, "Variant Also Negotiates"},
			{ 507, "Insufficient Storage"},
			{ 508, "Loop Detected"},
			{ 509, "Bandwidth Limit Exceeded"},
			{ 510, "Not Extended"},
			{ 511, "Network Authentication Required"},
		};
		public int StatusCode { get; set; }
		public string Message { get; set; }
		public Status(int statusCode, string? message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetHttpMessage(statusCode);
		}
		public Status(StatusCode statusCode, string? message = null)
		{
			StatusCode = ((int)statusCode);
			Message = message ?? GetHttpMessage(((int)statusCode));
		}
		public bool isSuccess()
		{
			return 200 <= StatusCode && StatusCode < 300;
		}
		public bool isError()
		{
			return !isSuccess();
		}

		public static string GetHttpMessage(int statusCode)
		{
			return httpStatusCodeMessage.GetValueOrDefault(statusCode) ?? "Invalid HTTP status code!";

		}
	}
}
