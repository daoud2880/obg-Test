﻿using obg_opgave;

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
        Book negativePrice = new Book() { Id = 2, Price = -1, Title = "Test2" };
        Book book1 = new Book() { Id = 4, Price = 1, Title = "test4" };
        Book overPrice = new Book() { Id = 3, Price = 1201, Title = "test3" };
        Book rightUnderMax = new Book() { Id = 5, Price = 1199, Title = "Test5" };
        Book exactly1200 = new Book() { Id = 6, Price = 1200, Title = "test7" };

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => negativePrice.ValidatePrice());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => overPrice.ValidatePrice());
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => exactly0.ValidatePrice());
        book1.ValidatePrice();
        rightUnderMax.ValidatePrice();
        exactly1200.ValidatePrice();
    }

    [TestMethod]
    public void ValidateGet()
    {
        //Arrange
        BooksRepository books = new BooksRepository();
        //Act
        List<Book> booksTest = (List<Book>)books.Get();
        //Assert
        Assert.AreEqual(5, booksTest.Count);
        Assert.AreEqual("Narnia", booksTest[0].Title);
        Assert.AreEqual(100, booksTest[0].Price);
    }

    [TestMethod]
    public void ValidateGetById()
    {
        //arrange
        BooksRepository c = new BooksRepository();
        //Act
        Book? book = c.GetById(1);
        //assert
        Assert.IsNotNull(book);
        Assert.AreEqual("Narnia", book.Title);
        Assert.AreEqual(100, book.Price);
        Assert.AreEqual(1, book.Id);
    }

    [TestMethod]
    public void ValidateAdd()
    {
        //Arrange
        BooksRepository c = new BooksRepository();
        //Act
        Book newBook = new Book()
        {
            Id = 4,
            Title = "Think and grow rich",
            Price = 800
        };
        Book added = c.AddBook(newBook);
        //Assert
        Assert.AreNotEqual(4, added.Id);
        Assert.AreEqual(800, added.Price);
        Assert.AreEqual("Think and grow rich", added.Title);
        Assert.AreEqual(6, added.Id);
    }
}
