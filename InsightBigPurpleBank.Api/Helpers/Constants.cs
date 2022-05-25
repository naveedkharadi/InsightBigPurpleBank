namespace InsightBigPurpleBank.Api.Helpers
{
    public static class Constants
    {
        public const int MaxPageSizeByCDS = 1000;
        public static class Headers
        {
            public const string Version = "x-v";
            public const string MinVersion = "x-min-v";
        }

        public static class ErrorCodes
        {
            public const string _400_InvalidVersion = "urn:au-cds:error:cds-all:Header/InvalidVersion";
            public const string _400_InvalidField = "urn:au-cds:error:cds-all:Field/Invalid";
            public const string _400_InvalidDate = "urn:au-cds:error:cds-all:Field/InvalidDateTime";
            public const string _400_InvalidPageSize = "urn:au-cds:error:cds-all:Field/InvalidPageSize";

            public const string _406_UnsupportedVersion = "urn:au-cds:error:cds-all:Header/UnsupportedVersion";

            public const string _422_InvalidPage = "urn:au-cds:error:cds-all:Field/InvalidPage";
            
            public const string _500_InternalServerError = "urn:au-cds:error:cds-all:Application/InternalServerError";
        }
    }
}
