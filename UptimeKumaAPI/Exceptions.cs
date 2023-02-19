using System;

namespace UptimeKumaAPI
{
    public class APIConnectException : Exception
    {
        public APIConnectException() : base() { }
    }

    public class IncidentCheckException : Exception
    {
        public IncidentCheckException() : base() { }
    }

    public class PublicGroupListCheckException : Exception
    {
        public PublicGroupListCheckException() : base() { }
    }

    public class PushException : Exception
    {
        public PushException() : base() { }
    }
}