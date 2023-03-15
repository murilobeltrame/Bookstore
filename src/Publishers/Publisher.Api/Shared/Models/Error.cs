namespace Publisher.Api.Shared.Models
{
    public record Error
    {
        public string Type{
            get;
            private set;
        }

        public string Description{
            get;
            private set;
        }

        public Error(string type, string description) => (Type, Description) = (type, description);

        public Error(Exception exception) => (Type, Description) = (exception.GetType().Name, exception.Message);
    }
}
