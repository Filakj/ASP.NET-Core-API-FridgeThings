create database WhatYouGotDB;
go

use WhatYouGotDB; 

create table Account (
	Id int identity(1, 1) primary key,
	Username varchar(max) COLLATE Latin1_General_CS_AS not null,
	Passphrase varchar(max) COLLATE Latin1_General_CS_AS not null,
	FirstName varchar(max) not null,
	LastName varchar(max) not null,
	Email varchar(max) not null
)

create table Favorite (
	Id int identity(1, 1) primary key,
	UserId int not null,
	RecipeId int not null
)



create table Review (
	Id int identity(1, 1) primary key,
	UserId int not null,
	RecipeId int not null,
	Rating int not null,
	Comment varchar(max) not null
)



create table Recipe (
	Id int primary key,
	Title varchar(max) not null, 
	Image varchar(max) not null
)

create table Ingredient ( 
	Id int primary key, 
	RecipeId int not null, 
	Image varchar(max) not null,
	Name varchar(max) not null, 
	Ammount decimal not null, 
	Unit varchar(max) not null
)

create table Instruction( 
	Id int identity(1,1) primary key, 
	RecipeId int not null, 
	StepNumber int not null, 
	Description varchar(max) not null
)



Select * From Account
Select * From Favorite
Select * From Recipe	
Select * From Review
Select * From Ingredient
Select * From Instruction



Insert into Account(Username, Passphrase, FirstName, LastName, Email)
Values('JF100','Password1','John','Filak', 'JF100@gmail.com')

Insert into Account(Username, Passphrase, FirstName, LastName, Email)
Values('Andre3k','Password1','Andre','Three-Thousand', 'A3K@gmail.com')
