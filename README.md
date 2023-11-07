# Books
Home Page:
![image](https://github.com/Harish23-github/Books/assets/72464644/81314025-b4fb-4416-b998-aadc53ad8e56)

**Q1.** Create a REST API using .Net Core MVC and write a method to return a sorted list of
these by Publisher, Author (last, first), then title.<br>
Result View:<br>
BookController - GetSortedBooks()
![image](https://github.com/Harish23-github/Books/assets/72464644/20104b24-8a8e-460c-9fbc-1937af7e01b3)

**Q2.** Write another API method to return a sorted list by Author (last, first) then title.<br>
Result View:<br>
Book Controller - GetSecondSortedBooks()
![image](https://github.com/Harish23-github/Books/assets/72464644/74763eb1-3edf-42a7-8261-1949803db2b6)

**Q3.** If you had to create one or more tables to store the Book data in a SQL Server/Sql Lite
database, outline the table design along with fields and their datatypes.<br>
Solution:<br>
<pre>
  CREATE TABLE Book(
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    AuthorLastName NVARCHAR(100) NOT NULL,
    AuthorFirstName NVARCHAR(100) NOT NULL,
    Title NVARCHAR(MAX) NOT NULL,
	  Publisher NVARCHAR(MAX) NOT NULL,
	  Price DECIMAL(18,2) NOT NULL,
	  MlaCitation NVARCHAR(MAX) NOT NULL,
	  ChicagoCitation NVARCHAR(MAX) NOT NULL,
	  JournalTitle NVARCHAR(MAX) NOT NULL,
	  PublicationDate DATETIME2(7) NOT NULL,
	  PageRange NVARCHAR(100) NOT NULL,
	  VolumeNumber INT,
	  Url NVARCHAR(MAX) NOT NULL
);
</pre>


**Q4.**  Write stored procedures for steps 1 and 2, and use them in separate API methods to return
the same results.
1. BookController - GetSortedBooksUsingSproc()<br>
Execute the below Stored Procedure in SQL Server<br>
<pre>
  CREATE or ALTER PROCEDURE GetBooksByFirstSortOrder
AS
BEGIN
    SELECT Id, Publisher, CONCAT(AuthorLastName,', ', AuthorFirstName) as AuthorName, Title FROM Books(NOLOCK) ORDER BY Publisher, AuthorName, Title ASC
END;
</pre>

<pre>
  CREATE or ALTER PROCEDURE GetBooksBySecondSortOrder
AS
BEGIN
    SELECT Id, CONCAT(AuthorLastName,', ', AuthorFirstName) as AuthorName, Title FROM Books(NOLOCK) ORDER BY AuthorName, Title ASC
END;
</pre>
![image](https://github.com/Harish23-github/Books/assets/72464644/9b51e917-7f5d-4618-bfcc-7a0f2356eece)
2. BookController - GetSecondSortedBooksUsingSproc()
   ![image](https://github.com/Harish23-github/Books/assets/72464644/7e636fcf-bd8b-470b-83a2-a3c8ba0973bd)

**Q5.** Write an API method to return the total price of all books in the database.
![image](https://github.com/Harish23-github/Books/assets/72464644/57b5bae9-8a8c-4c13-bb72-f1acbb490c2b)

**Q6.** If you have a large list of these in memory and want to save the entire list to the database,
with only one call to the DB server.<br>
Solution:<br>

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'XYZ','The Mystery of Lost Keys','Johnson','Emma',28.00,'','','Detective Chronicles',SYSDATETIME(),'85-92',2,'https://doi.org/10.xxxx/0001')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'History Books Co.','Historical Insights','Martin','William',5000.00,'','','History Today',SYSDATETIME(),'10-18',5,'https://doi.org/10.xxxx/0002')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'Wonderful Science Press','The Science of Nature','Williams','Olivia',42.00,'','','Scientific Wonders',SYSDATETIME(),'40-52',4,'https://doi.org/10.xxxx/0003')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'Starry Skies Publications','Exploring the Universe','Miller','James',49.00,'','','Astronomy Journal',SYSDATETIME(),'60-70',1,'https://doi.org/10.xxxx/0004')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'XYZ','The Mystery of Lost Keys','Ahahnson','Kils',55.00,'','','Detective Chronicles',SYSDATETIME(),'85-92',2,'https://doi.org/10.xxxx/0005')

**Q7.** Add a property to the Book class that outputs the MLA (Modern Language Association)
style citation as a string ( https://images.app.goo.gl/YkFgbSGiPmie9GgWA ). Please add
whatever additional properties the Book class needs to generate the citation.<br>
BookController - GetMlaCitation()<br>
![image](https://github.com/Harish23-github/Books/assets/72464644/72d8a5e3-4d31-4e0c-93fe-51fd4e826de6)

**Q8.** Add another property to generate a Chicago style citation (Chicago Manual of Style)
( https://images.app.goo.gl/w3SRpg2ZFsXewdAj7 ).<br>
BookController - GetChicagoCitation()<br>
![image](https://github.com/Harish23-github/Books/assets/72464644/d45e762e-b1d9-4084-8b8f-e419fecc4aa9)


Test Data:<br>

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'XYZ','The Mystery of Lost Keys','Johnson','Emma',28.00,'','','Detective Chronicles',SYSDATETIME(),'85-92',2,'https://doi.org/10.xxxx/0001')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'History Books Co.','Historical Insights','Martin','William',5000.00,'','','History Today',SYSDATETIME(),'10-18',5,'https://doi.org/10.xxxx/0002')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'Wonderful Science Press','The Science of Nature','Williams','Olivia',42.00,'','','Scientific Wonders',SYSDATETIME(),'40-52',4,'https://doi.org/10.xxxx/0003')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'Starry Skies Publications','Exploring the Universe','Miller','James',49.00,'','','Astronomy Journal',SYSDATETIME(),'60-70',1,'https://doi.org/10.xxxx/0004')

INSERT INTO [dbo].[Books]([Id],[Publisher],[Title],[AuthorLastName],[AuthorFirstName],[Price],[MlaCitation],[ChicagoCitation] ,[JournalTitle],[PublicationDate],[PageRange],[VolumeNumber],[Url])
     VALUES(NEWID(),'XYZ','The Mystery of Lost Keys','Ahahnson','Kils',55.00,'','','Detective Chronicles',SYSDATETIME(),'85-92',2,'https://doi.org/10.xxxx/0005')





