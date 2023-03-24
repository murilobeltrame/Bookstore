namespace Bookstore.GraphQl.Types
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OriginCountry { get; set; }
        public string HeadquartersLocation { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }

    public class PublisherType : ObjectType<Publisher>
    {
        //protected override void Configure(IObjectTypeDescriptor<Publisher> descriptor)
        //{
        //    base.Configure(descriptor);
        //    descriptor.Field(f => f.Books).ResolveWith(x => x)
        //}
    }
}