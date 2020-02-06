create database WhatYouGot;
go

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
	Id int identity(1, 1) primary key,
	Title varchar(max) not null
)