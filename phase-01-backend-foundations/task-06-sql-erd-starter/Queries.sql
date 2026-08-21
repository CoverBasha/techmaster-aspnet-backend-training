--1
SELECT * from Books;

--2
SELECT * from Members where IActive  = true;

--3
SELECT * from books where category = 'category';

--4 
SELECT COUNT(*) from books where category = 'category';

--5
SELECT FullName, Title from BorrowRecords br INNER JOIN Books b on b.BookId = br.BookId;

--6
SELECT * from BorrowRecords br INNER JOIN Books b on b.BookId = br.BookId where ReturnDate > DueDate;

--7
SELECT * from BorrowRecords where MemberId = '';

--8
SELECT * from Books where AvailableCopies > 0;

--9
SELECT FullName, COUNT(B.BookId) from Authors A left join Books B on A.AuthorId = B.AuthorId
GROUP BY FullName;

--10

SELECT TOP 5 B.Title, COUNT(Br.BookId) from Books B inner join BorrowRecords BR on B.BookId = BR.BookId
GROUP BY B.Title
ORDER BY COUNT(Br.BookId) DESC