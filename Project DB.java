CREATE TABLE Tenant (
tenantId VARCHAR(9) NOT NULL PRIMARY KEY,
HKID  VARCHAR(8) NOT NULL,
contactNumber  int(11) NOT NULL,
homeAddress VARCHAR(100) NOT NULL,
email VARCHAR(50) NOT NULL,
DOB date NOT NULL
);

CREATE TABLE Employee (
employeeId VARCHAR(11) NOT NULL PRIMARY KEY,
departmentID VARCHAR(5) NOT NULL,
title VARCHAR(20) NOT NULL,
type VARCHAR(2) NOT NULL CHECK(type  IN('FT','PT')),
employmentDate date NOT NULL,
HKID  VARCHAR(8) NOT NULL,
contactNumber  int(11) NOT NULL,
homeAddress VARCHAR(100) NOT NULL,
email VARCHAR(50) NOT NULL,
DOB date NOT NULL
);

CREATE TABLE Account (
employeeId VARCHAR(11) check (NOT employeeId = NULL OR NOT tenantId = NULL),
tenantId VARCHAR(9) check (NOT employeeId = NULL OR NOT tenantId = NULL),
account VARCHAR(11) NOT NULL PRIMARY KEY,
password VARCHAR(12) NOT NULL
);

CREATE TABLE Department (
DepartmentID VARCHAR(5) NOT NULL PRIMARY KEY,
DepartmentName VARCHAR(20) NOT NULL,
Location VARCHAR(20) NOT NULL
);

CREATE TABLE Branch(包埋入DPT)

CREATE TABLE ShowcaseInfo(
ShowcaseID VARCHAR(12) NOT NULL PRIMARY KEY,
DepartmentID VARCHAR(5) NOT NULL FOREIGN KEY REFERENCES Department(DepartmentID),
RentDollars Double(5,1) NOT NULL,
Size VARCHAR(10) NOT NULL,
Position VARCHAR(10) NOT NULL,
RentStatus VARCHAR(10) NOT NULL CHECK (RentStatus IN('registed','noregisted'))
);

CREATE TABLE Item(
ItemID VARCHAR(12) NOT NULL PRIMARY KEY,
ItemName VARCHAR(20) NOT NULL,
TenantID VARCHAR(9) NOT NULL,
BranchID VARCHAR(5) NOT NULL,
ShowcaseID VARCHAR(12) NOT NULL,
Category VARCHAR(3) NOT NULL,
Price Double(5,1) NOT NULL,
Description Varchar(20),
Photo Varchar(20),
Inventory int(4) NOT NULL,
NOS int(6) NOT NULL
);

CREATE TABLE Inventory(
InventoryNo VARCHAR(16) NOT NULL PRIMARY KEY,
ItemID VARCHAR(12) NOT NULL,
Quantity int(4) NOT NULL,
Date date NOT NULL,
Status VARCHAR(10) NOT NULL CHECK (Status IN('undone','done')),
TextFile VARCHAR(20) NOT NULL
);

CREATE TABLE Orders(
OrderID VARCHAR(16) NOT NULL PRIMARY KEY,
CustomerID VARCHAR(16) NOT NULL,
ItemID VARCHAR(12) NOT NULL,
Quantity int(4) NOT NULL,
Amount Double(5,1) NOT NULL,
Date date NOT NULL,
PaymentMethod Varchar(20) NOT NULL, 
Status Varchar(10) NOT NULL
);

CREATE TABLE ShowcaseLease(   
LeaseID VARCHAR(12) NOT NULL PRIMARY KEY,
ShowcaseID VARCHAR(12) NOT NULL,
tenantId VARCHAR(9) NOT NULL,
LeaseDate date NOT NULL,
LeasingTime Int(2) NOT NULL
);

CREATE TABLE RentRecord(
RentID int(16) NOT NULL PRIMARY KEY,
DepartmentID VARCHAR(5) NOT NULL,
ShowcaseID VARCHAR(12) NOT NULL,
TenantID VARCHAR(9) NOT NULL,
RentMonth int(4) NOT NULL,
RentFirstDay VARCHAR(10) NOT NULL,
RentLastDay VARCHAR(10) NOT NULL,
RentPrice Double(5,1) NOT NULL
);
