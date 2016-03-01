﻿using Repository.EntityModel;
using Repository.Repository;
using System.Collections.Generic;

namespace Services.Service
{
    public class BookService
    {
        public static List<book> GetBooksByAuthor(int aid)
        {
            return BookRepository.dbGetBookListByAuthor(aid);
        }

        public static book GetBook(string isbn) {
            return BookRepository.dbGetBook(isbn);
        }

        public static List<book> GetBooks()
        {
            return BookRepository.dbGetBooks();
        }

        public static void UpdateBook(book b)
        {
            BookRepository.dbUpdateBook(b);
        }

        public static void StoreBook(book b)
        {
            BookRepository.dbStoreBook(b);
        }

        public static void RemoveBook(book b)
        {
        }

    }
}
