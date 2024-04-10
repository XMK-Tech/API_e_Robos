IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'UpdateDataCrossing') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].UpdateDataCrossing
GO
CREATE PROCEDURE [dbo].UpdateDataCrossing
AS

--Status:
--	Pending - 0
--	Done - 1
--	Error - 2


declare @pendingCrossings table (
	[crossingId] uniqueidentifier,
	[StartingDate] VARCHAR(10),
	[EndingDate] VARCHAR(10)
)

declare @crossingEntries table (
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastUpdateAt] [datetime2](7) NOT NULL,
	[InvoiceValue] [decimal](18, 2) NOT NULL,
	[TransactionValue] [decimal](18, 2) NOT NULL,
	[Difference] [decimal](18, 2) NOT NULL,
	[Document] [nvarchar](max) NULL,
	[CompanyName] [nvarchar](max) NULL,
	[ReferenceDate] [datetime2](7) NOT NULL,
	[DataCrossingId] [uniqueidentifier] NULL
)


-- Type
--   - Transaction - 0
--   - Invoice - 1
declare @groupedValue table (
	[Value] [decimal](18, 2) NOT NULL,
	[Date] VARCHAR(10),
	[Type] int,
	[Document] VARCHAR(255),
	[DataCrossingId] uniqueidentifier
)


insert into @pendingCrossings
select Id,
CAST(YEAR(StartingReference) AS VARCHAR(4)) + '-' + CAST(MONTH(StartingReference) AS VARCHAR(2)) + '-01',
CAST(YEAR(EndingReference) AS VARCHAR(4)) + '-' + CAST(MONTH(EndingReference) AS VARCHAR(2)) + '-01'
from DataCrossing where Status = 0

declare cross_cursor cursor for
select crossingId, StartingDate, EndingDate
from @pendingCrossings
open cross_cursor
declare @startDate varchar(6)
declare @endDate varchar(6)
declare @id uniqueidentifier
fetch next from cross_cursor
into @id, @startDate, @endDate
WHILE @@FETCH_STATUS = 0  
BEGIN
insert into @groupedValue
select
SUM(Value),
CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01',
1,
Document,
@id
from InvoiceEntry
where [IsInvalid] = 0
group by CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01', Document
having CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01' > @startDate
and CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01' < @endDate


insert into @groupedValue
select
SUM(Value),
CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01',
0,
Document,
@id
from TransactionEntry
where [IsInvalid] = 0
group by CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01', Document
having CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01' > @startDate
and CAST(YEAR(ReferenceDate) AS VARCHAR(4)) + '-' + CAST(MONTH(ReferenceDate) AS VARCHAR(2)) + '-01' < @endDate

insert into DivergencyEntry
select
NEWID(),
GETDATE(),
GETDATE(),
SUM(case when [Type] = 1 then Value else 0 end) as InvoiceValue,
SUM(case when [Type] = 0 then Value else 0 end) as TransactionValue,
SUM(case when [Type] = 1 then Value else 0 end) - SUM(case when [Type] = 0 then Value else 0 end) as 'Difference',
Document,
null,
CAST(YEAR(Date) AS VARCHAR(4)) + '-' + CAST(MONTH(Date) AS VARCHAR(2)) + '-01',
[DataCrossingId],
0
from @groupedValue
group by CAST(YEAR(Date) AS VARCHAR(4)) + '-' + CAST(MONTH(Date) AS VARCHAR(2)) + '-01', Document, [DataCrossingId]
update DataCrossing set Status = 1
where Id = @id
fetch next from cross_cursor
into @id, @startDate, @endDate
end   
close cross_cursor
go