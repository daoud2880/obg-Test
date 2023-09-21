using obg_opgave;

namespace obg_Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void ValidateNameTest()
    {
        Book book = new Book()
        {
            Id = 3,
            Price = 100,
            Title = "Test"
        };
        book.ValidateTitle();

        Book nullName = new Book() { Id = 1, Price = 100, Title = null };
        Book nameShort = new Book() { Id = 2, Price = 200, Title = "ds" };

        Assert.ThrowsException<ArgumentNullException>(() => nullName.ValidateTitle());
        Assert.ThrowsException<ArgumentException>(() => nameShort.ValidateTitle());
        Assert.IsNotNull(book);
    }

    [TestMethod]
    public void ValidateToString()
    {
        Book book = new Book() { Id = 1, Title = "Book", Price = 100 };
        Assert.AreEqual("1,Book,100", book.ToString());
        Assert.AreNotEqual("1,Test,100", book.ToString());
    }

    [TestMethod]
    public void ValidatePrice()
    {
        Book exactly0 = new Book() { Id = 1, Price = 0, Title = "Test" };
        Assert.AreEqual(0,exactly0.Price);

        Book negativePrice = new Book() { Id = 2, Price = -1, Title = "Test2" };
        Book overPrice = new Book() { Id = 3, Price = 1400, Title = "test3" };
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => negativePrice.ValidatePrice());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => overPrice.ValidatePrice());
    }
}
