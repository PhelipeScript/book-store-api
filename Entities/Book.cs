namespace BookStoreAPI.Entities;

public class Book
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public float Value { get; set; } = 0.0f;
    public int Quantity { get; set; } = 0;
}
