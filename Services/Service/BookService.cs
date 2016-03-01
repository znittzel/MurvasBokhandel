﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Model;
using Repository.Repository;
using Repository.EntityModel;

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

        public static BookWithAuthorS GetBookWithAuthors(string isbn)
        {
            return MapBookWithAuthorS(BookRepository.dbGetBook(isbn));
        }

        private static BookWithAuthorS MapBookWithAuthorS(book b)
        {
            BookWithAuthorS bookandauthers = new BookWithAuthorS();
            bookandauthers.Book = b;
            bookandauthers.Authors = AuthorService.GetAuthersByBook(b.ISBN);
            return bookandauthers;
        }

<<<<<<< HEAD
        public static void UpdateBook(book b)
        {
            BookRepository.dbUpdateBook(b);
        }
=======
        public static List<book> GetBooksBySearch(string input)
        {
            return BookRepository.dbGetBooksBySearch(input);
        }

        //public static AuthorWithBooks GetAuthorWithBooks(int aid)
        //{
        //    return MapAuthorWithBooks(AuthorRepository.dbGetAuthor(aid));
        //}

        //public static AuthorWithBooks MapAuthorWithBooks(author a)
        //{
        //    AuthorWithBooks authorwithbooks = new AuthorWithBooks();
        //    authorwithbooks.Author = a;
        //    authorwithbooks.Books = BookService.GetBooksByAuthor(a.Aid);
>>>>>>> Public_D2Adam

        public static void StoreBook(book b)
        {
            BookRepository.dbStoreBook(b);
        }

        public static void RemoveBook(book b)
        {
            BookRepository.dbRemoveBook(b);
            BookAuthorRepository.dbRemoveBookAuthorByISBN(b.ISBN);
        }
    }
}
