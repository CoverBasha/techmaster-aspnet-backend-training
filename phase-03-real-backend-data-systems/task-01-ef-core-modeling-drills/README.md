# Task 01 --- EF Core Modeling Drill Pack

**Training:** TechMaster Academy --- ASP.NET Backend Career Training\
**Phase:** 03 --- Real Backend Data Systems\
**Project:** Training Center Registration API

> This README documents the EF Core modeling drills. Update the
> implementation/evidence checkboxes to match the work in the repository
> before submitting.

## Overview

The purpose of this task is to practice EF Core modeling, relationships,
migrations, and database verification before building the main Training
Center API. Separation of concerns between services, repositories and API layer was ignored in this task in order to focus on database. The database is called directly from the controllers.

### Concepts covered

-   `DbContext`, `DbSet<T>`, and migrations
-   One-to-one, one-to-many, and many-to-many relationships
-   Seed data
-   Soft deletion and audit fields
-   DTO projection and pagination

## Local setup

### Prerequisites

-   .NET SDK compatible with the project
-   SQL Server or SQL Server LocalDB
-   EF Core SQL Server and Design/Tools packages
-   `dotnet-ef` CLI tool

### Configuration

Set `ConnectionStrings:DefaultConnection` in local development
configuration or User Secrets. Do not commit production credentials or
real passwords.

Example placeholder:

``` json
{
  "ConnectionStrings": {
    "DefaultConnection": "<your-local-or-development-connection-string>"
  }
}
```

### Run the project and apply migrations

Run these commands from the project directory (adjust the startup/target
project arguments if your solution separates them):

``` bash
dotnet restore
dotnet build
dotnet ef migrations list
dotnet ef database update
dotnet run
```

If creating the initial migration from scratch, use the required name:

``` bash
dotnet ef migrations add InitialStudentSchema
dotnet ef database update
```

## Drills

  -------------------------------------------------------------------------
  Drill             Topic             Relationship /      Status
                                      purpose             
  ----------------- ----------------- ------------------- -----------------
  01                DbContext & first `AppDbContext`      \[ \]
                    migration         exposes             
                                      `DbSet<Student>`;   
                                      migration creates   
                                      `Students`          

  02                Student profile   One-to-one:         \[ \]
                                      `Student` ↔         
                                      `StudentProfile`    

  03                Instructor tracks One-to-many:        \[ \]
                                      `Instructor` →      
                                      `TrainingTrack`     

  04                Enrollment        Many-to-many        \[ \]
                                      between `Student`   
                                      and                 
                                      `TrainingTrack`,    
                                      represented by      
                                      `Enrollment` as a   
                                      join entity with    
                                      business data       

  05                Payment summary   One-to-one:         \[ \]
                                      `Enrollment` ↔      
                                      `PaymentSummary`    

  06                Seed data         Repeatable initial  \[ \]
                                      records for         
                                      students,           
                                      instructors,        
                                      tracks, and         
                                      enrollments         

  07                Soft delete       Mark a record as    \[ \]
                                      deleted instead of  
                                      physically removing 
                                      it                  

  08                Audit fields      Track               \[ \]
                                      creation/update     
                                      timestamps          
                                      automatically       

  09                Projection DTO    Select required     \[ \]
                                      fields into a DTO   
                                      rather than         
                                      returning full      
                                      entities            

  10                Pagination        Return a bounded    \[ \]
                                      page of records     
                                      with pagination     
                                      metadata as         
                                      implemented         
  -------------------------------------------------------------------------

## Relationship notes

### Student --- StudentProfile (one-to-one)

Each student has one profile, and each profile belongs to one student.
In this implementation, `StudentProfile.StudentID` is the profile's
primary key and foreign key to `Student`.

### Instructor --- TrainingTrack (one-to-many)

An instructor can be associated with multiple tracks. Each track has one
instructor through `TrainingTrack.InstructorId`.

### Student --- TrainingTrack through Enrollment (many-to-many)

A student can enroll in multiple tracks, and a track can have multiple
students. `Enrollment` is the explicit join entity, allowing
enrollment-specific data such as `EnrollmentDate` and `FinalGrade`.

### Enrollment --- PaymentSummary (one-to-one)

An enrollment can have one payment summary. The FK must uniquely
identify its enrollment. If using a shared/composite key, document the
exact key configuration in the implementation.

## Seed data

Seed data is configured to be repeatable (for example, with EF Core
`HasData`) and should not create duplicate rows every time the
application starts.

### Seed counts

  Entity              Required minimum   Seeded
  ----------------- ------------------ --------
  Students                           5        5
  Instructors                        2        2
  Training tracks                    3        3
  Enrollments                        5        5

### Known sample IDs

These are the fixed IDs used in the seed examples. Confirm they match
the final migration/database before sharing them with a reviewer.

  ----------------------------------------------------------------------------
  Record                              ID
  ----------------------------------- ----------------------------------------
  Student 1 --- Omar Hassan           `11111111-1111-1111-1111-111111111111`

  Student 2 --- Youssef Ahmed         `22222222-2222-2222-2222-222222222222`

  Student 3 --- Karim Mahmoud         `33333333-3333-3333-3333-333333333333`

  Student 4 --- Mariam Adel           `44444444-4444-4444-4444-444444444444`

  Student 5 --- Nour Khaled           `55555555-5555-5555-5555-555555555555`

  Instructor 1 --- Ahmed Hassan       `11111111-1111-1111-1111-111111111111`

  Instructor 2 --- Mariam Ibrahim     `22222222-2222-2222-2222-222222222222`

  Track 1 --- .NET Backend            `33333333-3333-3333-3333-333333333333`
  Development                         

  Track 2 --- Database Fundamentals   `44444444-4444-4444-4444-444444444444`

  Track 3 --- Cloud Development       `55555555-5555-5555-5555-555555555555`

  Enrollment 1                        `66666666-6666-6666-6666-666666666666`

  Enrollment 2                        `77777777-7777-7777-7777-777777777777`

  Enrollment 3                        `88888888-8888-8888-8888-888888888888`

  Enrollment 4                        `99999999-9999-9999-9999-999999999999`

  Enrollment 5                        `aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa`
  ----------------------------------------------------------------------------

