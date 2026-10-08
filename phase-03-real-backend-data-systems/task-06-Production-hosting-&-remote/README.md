# TechMaster Phase 3 – Training Center Management System

A backend training project developed as part of the TechMaster Academy ASP.NET Backend Career Training program.

## Live Deployment

**Application URL:** http://techmasterphase3trainingcenter.runasp.net/

## Technologies

* C#
* ASP.NET Core Web API
* Entity Framework Core
* Microsoft SQL Server
* RESTful APIs
* Swagger / OpenAPI

## Overview

The system manages training center operations, including students, instructors, training tracks, enrollments, and payments. It uses Entity Framework Core for database access and SQL Server for persistent storage.

## API Endpoints

Base URL: `http://techmasterphase3trainingcenter.runasp.net`

### Students

| Method | Endpoint                         | Description                                     |
| ------ | -------------------------------- | ----------------------------------------------- |
| GET    | `/api/students`                  | Retrieve students with pagination and filters   |
| GET    | `/api/students/{id}`             | Retrieve student details and enrollment summary |
| POST   | `/api/students`                  | Create a student                                |
| PUT    | `/api/students/{id}`             | Update student information                      |
| DELETE | `/api/students/{id}`             | Soft-delete a student                           |
| GET    | `/api/students/{id}/enrollments` | Retrieve a student's enrollment history         |

### Instructors

| Method | Endpoint                       | Description                               |
| ------ | ------------------------------ | ----------------------------------------- |
| GET    | `/api/instructors`             | Retrieve all instructors                  |
| GET    | `/api/instructors/{id}`        | Retrieve instructor details               |
| POST   | `/api/instructors`             | Create an instructor                      |
| PUT    | `/api/instructors/{id}`        | Update instructor information             |
| GET    | `/api/instructors/{id}/tracks` | Retrieve tracks assigned to an instructor |

### Training Tracks

| Method | Endpoint                    | Description                                     |
| ------ | --------------------------- | ----------------------------------------------- |
| GET    | `/api/tracks`               | Retrieve tracks with filtering options          |
| GET    | `/api/tracks/{id}`          | Retrieve track details and capacity information |
| POST   | `/api/tracks`               | Create a training track                         |
| PUT    | `/api/tracks/{id}`          | Update track information                        |
| DELETE | `/api/tracks/{id}`          | Soft-delete a track                             |
| GET    | `/api/tracks/{id}/students` | Retrieve students enrolled in a track           |

### Enrollments

| Method | Endpoint                       | Description                                                                  |
| ------ | ------------------------------ | ---------------------------------------------------------------------------- |
| GET    | `/api/enrollments`             | Retrieve enrollments with status, track, student, and payment-status filters |
| GET    | `/api/enrollments/{id}`        | Retrieve enrollment details, including student, track, and payments          |
| POST   | `/api/enrollments`             | Enroll a student in a training track                                         |
| PUT    | `/api/enrollments/{id}/status` | Update enrollment status                                                     |

### Payments

| Method | Endpoint                         | Description                                          |
| ------ | -------------------------------- | ---------------------------------------------------- |
| GET    | `/api/payments`                  | Retrieve payments with date-range and status filters |
| POST   | `/api/payments`                  | Create a payment for an enrollment                   |
| GET    | `/api/enrollments/{id}/payments` | Retrieve payment history for an enrollment           |
| PUT    | `/api/payments/{id}/status`      | Update payment status                                |

## Database and Deployment

The application is hosted on MonsterASP.NET and uses a remote Microsoft SQL Server database. Entity Framework Core migrations manage database schema changes.

## API Documentation

Swagger/OpenAPI is used to document and test the API endpoints, where enabled in the deployed environment.
