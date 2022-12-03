Use BigDataInsert

go

create table SqlBulkCopyMethod
(
	pk int not null identity(1,1) primary key,
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go

create table SqlRowByRowMethod
(
	pk int not null identity(1,1) primary key,
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go

create table SqlRowByRowSprocMethod
(
	pk int not null identity(1,1) primary key,
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go

create procedure usp_RowByRowSprocProcedure
(
	@id uniqueidentifier,
	@title varchar(100),
	@dateCreatedUTC datetime
)
as
begin
	set nocount on
	insert into SqlRowByRowSprocMethod(Id,Title,DateCreatedUTC)
	values(@id,@title,@dateCreatedUTC)
end

go

create table SqlUserDefinedTableTypeMethod
(
	pk int not null identity(1,1) primary key,
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go

create type BigInsertTableType as table
(
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go

create procedure usp_UserDefinedTableTypeSproc
(
	@bigDataTable BigInsertTableType readonly
)
as
begin
	set nocount on
	insert into SqlUserDefinedTableTypeMethod(id,title,DateCreatedUTC)
	select Id,Title,DateCreatedUTC from @bigDataTable
end

go

create table EF_One_By_One_Method
(
	pk int not null identity(1,1) primary key,
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go

create table EF_Lazy_Batch_Method
(
	pk int not null identity(1,1) primary key,
	Id uniqueidentifier not null,
	Title varchar(100) not null,
	DateCreatedUTC datetime not null
)

go