DECLARE @Counter int = 0
WHILE (SELECT COUNT(*) FROM log) < 100000
BEGIN
  INSERT INTO log(id, date, text)
  values (@Counter, CONVERT(datetime, @Counter), convert(text, CONVERT(varchar, @Counter)))
  SET @Counter = @Counter + 1
END

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

select date from log
where date between '1900/01/01' and '1990/01/01'	

select date from logWithoutIndex
where date between '1900/01/01' and '1990/01/01'

create fulltext catalog logFullTextCatalog

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS

CREATE FULLTEXT INDEX ON logFullTextIndex

(textIndex, [text] LANGUAGE 1033)
KEY INDEX PK_logFullTextIndex
ON logFullTextCatalog

select * from logFullTextIndex where text = 5

--Select * from logFullTextIndex Where Contains(textIndex, '5')

--insert into logFullTextIndex select id, date, text, text from log

--delete from logFullTextIndex
--SELECT date, text INTO dbo.logWithoutIndex FROM log

--SELECT date, text INTO dbo.logFullTextIndex FROM log
