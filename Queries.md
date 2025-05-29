# SQL Queries

## Create Database

```sql
CREATE DATABASE SchoolDB
GO
USE SchoolDB;
```

## Create Table

```sql
CREATE TABLE Students(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE,
)
CREATE TABLE Lecturers(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
)
CREATE TABLE Courses(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(50) NOT NULL,
    Code NVARCHAR(5) UNIQUE,
    Credits INT,
)
CREATE TABLE Classes(
    Id INT PRIMARY KEY IDENTITY,
    LecturerId INT FOREIGN KEY REFERENCES Lecturers(Id),
    CourseId INT FOREIGN KEY REFERENCES Courses(Id),
    [TIME] time
)

CREATE TABLE Enrollments(
    Id INT PRIMARY KEY IDENTITY,
    StudentId INT FOREIGN KEY REFERENCES Students(Id),
    ClassId INT FOREIGN KEY REFERENCES Classes(Id),
    CGPA DECIMAL(10,2),
    Grade NVARCHAR(2)
)
```
