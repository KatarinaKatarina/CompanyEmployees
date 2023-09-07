namespace Shared.DataTransferObjects
{
    namespace Shared.DataTransferObjects
    {
        //public record CompanyDto(Guid Id, string Name, string FullAddress); //the way of defining records (properties!)
        public record CompanyDto
        {
            public Guid Id { get; init; } //init-only properties protect the state of the object from mutation once initialization is finished
            public string? Name { get; init; }
            public string? FullAddress { get; init; }
        }
    }
}
