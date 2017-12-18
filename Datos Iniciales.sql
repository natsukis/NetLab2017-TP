
USE Employees

DELETE FROM dbo.Employees
DELETE FROM dbo.Shifts
DELETE FROM dbo.Countries

DBCC CHECKIDENT ('Employees.dbo.Employees',RESEED, 0)
DBCC CHECKIDENT ('Employees.dbo.Shifts',RESEED, 0)
DBCC CHECKIDENT ('Employees.dbo.Countries',RESEED, 0)

INSERT INTO dbo.Shifts
VALUES ('Morning',9,16)

INSERT INTO dbo.Shifts
VALUES ('Afternoon',16,0)

INSERT INTO dbo.Shifts
VALUES ('Night',0,9)


INSERT INTO dbo.Countries
values ('Argentina')

INSERT INTO dbo.Countries
values ('Brasil')

INSERT INTO dbo.Countries
values ('United States')


INSERT INTO dbo.Employees
VALUES ('Bruce','Willis','2015-12-02 0:0:0',150,1,1)

INSERT INTO dbo.Employees
VALUES ('Sylvester','Stallone','2015-06-10 0:0:0',250,2,1)

INSERT INTO dbo.Employees
VALUES ('Jason','Statham','2014-04-05 0:0:0',125,3,3)

INSERT INTO dbo.Employees
VALUES ('Mel','Gibson','2016-07-21 0:0:0',180,3,2)