﻿using Common.Model;
using Repository.EntityModel;
using Repository.Repository;
using System;
using System.Collections.Generic;

namespace Services.Service
{
    public class BorrowService
    {
        public static List<BorrowedBookCopy> GetActiveBorrowedBooks(string PersonId) {
            return MapBorrow(BorrowRepository.GetActiveBorrowListByPersonId(PersonId));    
        }
        
        public static List<BorrowedBookCopy> GetHistoryBorrowedBooks(string PersonId) {
            return MapBorrow(BorrowRepository.GetHistoryBorrowListByPersonId(PersonId));
        }
        
        public static List<BorrowedBookCopy> MapBorrow(List<borrow> b) {
            List<BorrowedBookCopy> BorrowedBookCopy = new List<BorrowedBookCopy>();
            foreach (borrow borrow in b)
            {
                copy c = CopyRepository.GetCopyByBarcode(borrow.Barcode);
                BorrowedBookCopy.Add(new BorrowedBookCopy() { 
                    borrow = borrow,
                    authors = AuthorRepository.GetAuthorsByBookISBN(c.ISBN),
                    book = BookRepository.GetBook(c.ISBN),
                    category = CategoryRepository.GetCategoryById(BorrowerRepository.GetBorrower(borrow.PersonId).CategoryId),
                    fine = FineRepository.GetFine(borrow.Barcode, borrow.PersonId)
                });
            }
            return BorrowedBookCopy;
        }

        public static void RenewLoan(borrower br, string barcode)
        {
            DateTime ToBeReturnedDate = DateTime.Today.AddDays(CategoryRepository.GetCategoryById(br.CategoryId).Period);
            BorrowRepository.UpdateBorrowDates(br.PersonId, barcode, ToBeReturnedDate);
        }

        public static void RenewAllLoans(borrower br, List<BorrowedBookCopy> borrowes)
        {
            DateTime ToBeReturnedDate = DateTime.Today.AddDays(CategoryRepository.GetCategoryById(br.CategoryId).Period);
            foreach (BorrowedBookCopy b in borrowes)
                BorrowRepository.UpdateBorrowDates(br.PersonId, b.borrow.Barcode, ToBeReturnedDate);
        }
    }
}
