-- Belgium Campus Registration Database Setup Script
-- Run this script in SQL Server Management Studio to initialize the database

-- Create the database if it doesn't exist
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'StudentDB')
BEGIN
    CREATE DATABASE StudentDB
END
GO

-- Use the StudentDB database
USE StudentDB
GO

-- Create the StudentDetails table if it doesn't exist
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'StudentDetails')
BEGIN
    CREATE TABLE StudentDetails (
        StudentID INT PRIMARY KEY NOT NULL,
        FirstName VARCHAR(100) NOT NULL,
        LastName VARCHAR(100) NOT NULL,
        CourseID VARCHAR(50) NOT NULL,
        RegistrationDate DATETIME DEFAULT GETDATE()
    )
END
GO

-- Print confirmation message
PRINT 'Database setup completed successfully!'
PRINT 'Database: StudentDB'
PRINT 'Table: StudentDetails'
PRINT ''
PRINT 'Table Structure:'
PRINT '- StudentID (INT, Primary Key)'
PRINT '- FirstName (VARCHAR 100)'
PRINT '- LastName (VARCHAR 100)'
PRINT '- CourseID (VARCHAR 50)'
PRINT '- RegistrationDate (DATETIME, Default: Current Date/Time)'
