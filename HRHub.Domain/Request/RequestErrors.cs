using HRHub.Domain.Abstractions;

namespace HRHub.Domain.Request;

    public static class RequestErrors
    {
        public static Error NotFound = new(
            "Request.Found",
            "The Request with the specified idnentifier was not founnd");

        public static Error Overlap = new(
            "Request.Overlap",
            "The current Request is overlapping with an existing one");

        public static Error NotConfirmed = new(
            "Request.NotConfirmed",
            "The Request is not confirmed");

        public static Error AlreadyStarted = new(
            "Request.AlreadyStarted",
            "The annual leave has already started");

        public static Error NotEnough = new(
            "Request.NotEnough",
            "You don't have enough remaining leave days.");
    }

