# Application Architecture Diagram

## System Architecture Overview

```
╔════════════════════════════════════════════════════════════════════╗
║              BELGIUM CAMPUS REGISTRATION APPLICATION              ║
║                    (Windows Forms Application)                    ║
╚════════════════════════════════════════════════════════════════════╝

┌─────────────────────────────────────────────────────────────────────┐
│                        PRESENTATION LAYER                           │
│                    (Windows Forms User Interface)                   │
├─────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  ┌──────────────────┐  ┌──────────────────┐  ┌──────────────────┐ │
│  │    Form1.cs      │  │  SearchForm.cs   │  │  DeleteForm.cs   │ │
│  │                  │  │                  │  │                  │ │
│  │ ✓ Registration   │  │ ✓ Student Query  │  │ ✓ Delete Record  │ │
│  │ ✓ Update Record  │  │ ✓ Display Results│  │ ✓ Confirmation   │ │
│  │ ✓ Input Validate │  │ ✓ Input Validate │  │ ✓ Validation     │ │
│  │ ✓ Error Handling │  │ ✓ Error Handling │  │ ✓ Error Handling │ │
│  └────────┬─────────┘  └────────┬─────────┘  └────────┬─────────┘ │
│           │                     │                     │           │
│           └─────────────────────┼─────────────────────┘           │
│                                 │                                 │
│                    Event Handlers & Validation                    │
│                                                                     │
└─────────────────────────────────────────────────────────────────────┘
                                  │
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                       BUSINESS LOGIC LAYER                          │
│                  (Data Processing & Validation)                    │
├─────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  ┌─────────────────────────────────────────────────────────────┐  │
│  │                    DataHandler.cs                           │  │
│  │                                                              │  │
│  │  ✓ Register(id, name, lastname, courseid)                 │  │
│  │  ✓ Update(id, name, lastname, courseid)                   │  │
│  │  ✓ Delete(id)                                              │  │
│  │  ✓ Search(id) → DataTable                                  │  │
│  │                                                              │  │
│  │  Features:                                                   │  │
│  │  • Parameterized SQL queries (SQL injection prevention)    │  │
│  │  • Try-catch error handling                                │  │
│  │  • Row affected verification                               │  │
│  │  • Using statements for resource management               │  │
│  └────────────────────┬──────────────────────────────────────┘  │
│                       │                                           │
│  ┌────────────────────┴──────────────────────────────────────┐  │
│  │            Input Validation & Error Handling              │  │
│  │                                                              │  │
│  │  ✓ Check for null/empty values                             │  │
│  │  ✓ Validate data types                                      │  │
│  │  ✓ Format error messages                                    │  │
│  │  ✓ Log exceptions                                           │  │
│  └──────────────────────────────────────────────────────────┘  │
│                                                                     │
└─────────────────────────────────────────────────────────────────────┘
                                  │
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                        DATA ACCESS LAYER                            │
│            (Database Connection & SQL Execution)                   │
├─────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  ┌──────────────────────────────────────────────────────────────┐ │
│  │                   Database Operations                         │ │
│  │                                                                │ │
│  │  SqlConnection    → Database connection management          │ │
│  │  SqlCommand       → SQL query execution                     │ │
│  │  SqlDataAdapter   → Data retrieval (Search)                │ │
│  │  SqlParameter     → Parameterized query values              │ │
│  │                                                                │ │
│  └──────────────────────────────────────────────────────────────┘ │
│                                                                     │
└─────────────────────────────────────────────────────────────────────┘
                                  │
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                         DATA MODEL LAYER                            │
│                      (Object Representation)                       │
├─────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  ┌──────────────────────────────────────────────────────────────┐ │
│  │                     Student.cs                               │ │
│  │                                                                │ │
│  │  Properties:                                                  │ │
│  │  • StudentID (int)                                            │ │
│  │  • Name (string)                                              │ │
│  │  • Lastname (string)                                          │ │
│  │  • CourseID (string)                                          │ │
│  │                                                                │ │
│  │  Constructors:                                                │ │
│  │  • Student() - Default                                        │ │
│  │  • Student(sid, name, lastname, courseid) - Parameterized   │ │
│  │                                                                │ │
│  └──────────────────────────────────────────────────────────────┘ │
│                                                                     │
└─────────────────────────────────────────────────────────────────────┘
                                  │
                                  ▼
┌─────────────────────────────────────────────────────────────────────┐
│                        DATABASE LAYER                               │
│                  (Microsoft SQL Server Database)                   │
├─────────────────────────────────────────────────────────────────────┤
│                                                                     │
│  ┌──────────────────────────────────────────────────────────────┐ │
│  │  Database: StudentDB                                         │ │
│  │                                                                │ │
│  │  ┌──────────────────────────────────────────────────────┐   │ │
│  │  │  Table: StudentDetails                              │   │ │
│  │  │                                                        │   │ │
│  │  │  ┌──────────────┬────────┬─────────────────────────┐ │   │ │
│  │  │  │ Column       │ Type   │ Constraints           │ │   │ │
│  │  │  ├──────────────┼────────┼─────────────────────────┤ │   │ │
│  │  │  │ StudentID    │ INT    │ PRIMARY KEY, NOT NULL │ │   │ │
│  │  │  │ FirstName    │ VARCHAR│ NOT NULL (100)        │ │   │ │
│  │  │  │ LastName     │ VARCHAR│ NOT NULL (100)        │ │   │ │
│  │  │  │ CourseID     │ VARCHAR│ NOT NULL (50)         │ │   │ │
│  │  │  │ Registration │ DATETIME│ DEFAULT GETDATE()    │ │   │ │
│  │  │  └──────────────┴────────┴─────────────────────────┘ │   │ │
│  │  │                                                        │   │ │
│  │  └──────────────────────────────────────────────────────┘   │ │
│  │                                                                │ │
│  └──────────────────────────────────────────────────────────────┘ │
│                                                                     │
└─────────────────────────────────────────────────────────────────────┘
```

---

## Data Flow Diagrams

### 1. Registration Flow
```
┌─────────────┐
│   USER      │
│  INTERFACE  │
└──────┬──────┘
       │ Enters: ID, First Name, Last Name, Course ID
       │ Clicks: Register Button
       ▼
┌─────────────┐
│   FORM1     │
│ VALIDATION  │
└──────┬──────┘
       │ Check: All fields filled?
       │ Check: StudentID is integer?
       ▼
┌─────────────┐
│ DATAHANDLER │
│  .Register()│
└──────┬──────┘
       │ Build SQL: INSERT INTO StudentDetails VALUES(...)
       │ Add parameters: @sid, @name, @lastname, @courseid
       │ Execute: command.ExecuteNonQuery()
       ▼
┌─────────────┐
│  DATABASE   │
│   INSERT    │
└──────┬──────┘
       │ Insert new row into StudentDetails table
       ▼
┌─────────────┐
│ SUCCESS/    │
│  ERROR      │
│  MESSAGE    │
└──────┬──────┘
       │ Display result to user
       ▼
┌─────────────┐
│  CLEAR      │
│   FORM      │
└─────────────┘
```

### 2. Search Flow
```
┌──────────────────┐
│  MAIN FORM       │
│  Click Search    │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  SEARCH FORM     │
│  OPENS (Modal)   │
└────────┬─────────┘
         │ User enters Student ID
         │
         ▼
┌──────────────────┐
│  VALIDATION      │
│  • Not empty?    │
│  • Is integer?   │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  DATAHANDLER     │
│  .Search(id)     │
└────────┬─────────┘
         │ Execute: SELECT * FROM StudentDetails WHERE StudentID = @sid
         │
         ▼
┌──────────────────┐
│  DATABASE        │
│  QUERY           │
└────────┬─────────┘
         │ Returns: DataTable with results
         │
         ▼
┌──────────────────┐
│  DATAGRIDVIEW    │
│  DISPLAY         │
└────────┬─────────┘
         │ Show results (read-only)
         │
         ▼
┌──────────────────┐
│  USER REVIEWS    │
│  RESULTS         │
└──────────────────┘
```

### 3. Delete Flow
```
┌──────────────────┐
│  MAIN FORM       │
│  Click Delete    │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  DELETE FORM     │
│  OPENS (Modal)   │
└────────┬─────────┘
         │ Warning: "This action will delete the record"
         │ User enters Student ID
         │
         ▼
┌──────────────────┐
│  VALIDATION      │
│  • Not empty?    │
│  • Is integer?   │
└────────┬─────────┘
         │
         ▼
┌──────────────────┐
│  CONFIRMATION    │
│  DIALOG          │
└────────┬─────────┘
         │ "Are you sure? This cannot be undone."
         │ Click: Yes / No
         ▼
         ├─────── NO ──────┐
         │                 ▼
         │           CLOSE FORM
         │
         └─────── YES ────┐
                          ▼
                    ┌──────────────────┐
                    │  DATAHANDLER     │
                    │  .Delete(id)     │
                    └────────┬─────────┘
                             │ Execute: DELETE FROM StudentDetails WHERE StudentID = @sid
                             │
                             ▼
                    ┌──────────────────┐
                    │  DATABASE        │
                    │  DELETE          │
                    └────────┬─────────┘
                             │ Removes row from StudentDetails table
                             │
                             ▼
                    ┌──────────────────┐
                    │  SUCCESS MESSAGE │
                    └─────────────────┘
```

---

## Component Relationships

```
┌─────────────────────────────────────────────────────────┐
│                   Program.cs (Entry Point)              │
│                    Application.Run()                    │
└────────────────────────┬────────────────────────────────┘
                         │
                ┌────────┴────────┐
                │                 │
                ▼                 ▼
        ┌─────────────┐   ┌─────────────┐
        │   Form1.cs  │   │ Program.cs  │
        │  (Primary)  │   │  (Startup)  │
        └──────┬──────┘   └─────────────┘
               │
        ┌──────┴──────────┐
        │                 │
        ▼                 ▼
    ┌─────────────┐  ┌──────────────┐
    │SearchForm.cs│  │DeleteForm.cs │
    │ (Secondary) │  │ (Secondary)  │
    └──────┬──────┘  └────────┬─────┘
           │                  │
           └────────┬─────────┘
                    │
                    ▼
            ┌──────────────────┐
            │DataHandler.cs    │
            │(All forms call)  │
            └────────┬─────────┘
                     │
          ┌──────────┼──────────┐
          │          │          │
          ▼          ▼          ▼
        Register  Update      Delete
          │          │          │
          └──────────┼──────────┘
                     │
                     ▼
          ┌──────────────────┐
          │  Student.cs      │
          │  (Data Model)    │
          └────────┬─────────┘
                   │
                   ▼
          ┌──────────────────┐
          │  SQL Server      │
          │  StudentDB       │
          └──────────────────┘
```

---

## Design Pattern: MVC-like Architecture

```
MODEL (Data)
├── Student.cs (Entity)
└── DataHandler.cs (Business Logic)

VIEW (Presentation)
├── Form1.cs (Main UI)
├── SearchForm.cs (Search UI)
└── DeleteForm.cs (Delete UI)

CONTROLLER (Event Handling)
├── Form1.button1_Click() (Register)
├── Form1.button4_Click() (Update)
├── SearchForm.Search_Click() (Search)
└── DeleteForm.button1_Click() (Delete)
```

---

## Security Layers

```
┌──────────────────────────────────────────┐
│         USER INPUT                       │
│  (Keyboard, Mouse, Clipboard)            │
└────────────────┬───────────────────────┘
                 │
                 ▼
┌──────────────────────────────────────────┐
│    LAYER 1: CLIENT VALIDATION           │
│  • IsNullOrWhiteSpace() check            │
│  • int.TryParse() validation             │
│  • MessageBox error display              │
└────────────────┬───────────────────────┘
                 │ (Only valid data passes)
                 ▼
┌──────────────────────────────────────────┐
│    LAYER 2: PARAMETERIZED QUERIES       │
│  • SQL parameters with @placeholder      │
│  • No string concatenation               │
│  • Prevents SQL injection                │
└────────────────┬───────────────────────┘
                 │
                 ▼
┌──────────────────────────────────────────┐
│    LAYER 3: DATABASE CONSTRAINTS        │
│  • PRIMARY KEY constraint                │
│  • NOT NULL constraints                  │
│  • Data type validation                  │
│  • Relationship constraints              │
└────────────────┬───────────────────────┘
                 │
                 ▼
┌──────────────────────────────────────────┐
│    DATA SAFELY STORED IN DATABASE       │
└──────────────────────────────────────────┘
```

---

## Technology Stack

```
FRONTEND
├── Language: C# (Windows Forms)
├── Framework: .NET Framework 4.7.2
├── UI Controls: TextBox, Button, Label, DataGridView, Panel
├── Styling: Flat Design, Custom Colors, Segoe UI Font
└── Architecture: Event-Driven (Click handlers)

BACKEND
├── Language: C#
├── Data Access: ADO.NET (SqlConnection, SqlCommand)
├── Query Style: Parameterized SQL
├── Pattern: Data Access Object (DAO)
└── Error Handling: Try-Catch blocks

DATABASE
├── Engine: Microsoft SQL Server 2012+
├── Database: StudentDB
├── Authentication: Windows Integrated Security (SSPI)
├── Table: StudentDetails
└── Schema: 5 columns (ID, FirstName, LastName, CourseID, RegistrationDate)

TOOLS
├── IDE: Visual Studio 2022 Community
├── Build Tool: MSBuild
├── Version Control: Git (optional)
└── Database Tool: SQL Server Management Studio
```

---

**Architecture designed for simplicity, security, and maintainability.**
