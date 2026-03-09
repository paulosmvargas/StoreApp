namespace StoreApp.Api.External;

public class FakeStoreProduto
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Image { get; set; } = string.Empty;
}