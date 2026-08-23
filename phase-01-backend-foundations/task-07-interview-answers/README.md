# Task 07 - Interview Answers & Explanation Pack

This document contains the interview questions required for Task 07.

The purpose of this task is to practice explaining the concepts used throughout Phase 01, not just implementing them. Each question below has a dedicated space for my own answer.

---

## C# & OOP

### 1. What is the difference between class and object?

**My Answer:**

> A class defines the properties and methods. An object is an instance of a class.

---

### 2. What is encapsulation?

**My Answer:**

> Encapsulation is controlling access to a specific property through access modifiers and controlled methods.

---

### 3. Why should account balance not be public?

**My Answer:**

> Because balance change is dependent on a transaction and you don't want to accidentally change it somewhere without a transaction existing for this change.

---

### 4. What is the difference between field and property?

**My Answer:**

> A field is a variable that stores data inside a class. A property is a field with a setter and a getter enabling encapsulation.

---

### 5. Why do we use constructors?

**My Answer:**

> To create objects of the classes we defined.

---

### 6. What is the purpose of a service class?

**My Answer:**

> A service class contains the logic of how a system behaves and how models interact with each other.

---

### 7. Why should we avoid huge Main methods?

**My Answer:**

> To make the code scalable and maintainable and easier to debug by the separation of concerns.

---

## Collections & LINQ

### 8. What is the difference between List and Array?

**My Answer:**

> An array is fixed in size. A list is an array that resizes.

---

### 9. When would you use Dictionary?

**My Answer:**

> When I want fast lookup and the data is unique.

---

### 10. What is LINQ used for?

**My Answer:**

> LINQ is used for querying collections such as `IEnumerable`s and `IQueryable`s.

---

### 11. What is the difference between Where and Select?

**My Answer:**

> `Where` filters data using a condition or a predicate. `Select` selects a specific property from the returned objects or creates a new object.

---

### 12. What is GroupBy used for?

**My Answer:**

> `GroupBy` is used to group similar data by a specific property.

---

### 13. What are Skip and Take used for?

**My Answer:**

> `Skip(x)` skips the first `x` records, `Take(x)` takes then next `x` records. They are used for pagination.

---

## SQL & Database

### 14. What is a primary key?

**My Answer:**

> A primary key is a unique identifier for a table.

---

### 15. What is a foreign key?

**My Answer:**

> A foriegn key is another table's primary key in the current table.

---

### 16. What is a one-to-many relationship?

**My Answer:**

> In the context of a Book and an Author, an Author can have many books, but a Book can have only one Author.

---

### 17. Why do we use JOIN?

**My Answer:**

> To get data from another table.

---

### 18. What is the difference between table and entity?

**My Answer:**

> An entity is the concept of what needs to be implemented. A table is the implementation of an enitity.

---

## Git, GitHub & Professional Delivery

### 19. Why do we use GitHub?

**My Answer:**

> For teamwork and coordination and a centralized place where everyone is contributing. Also for version control and deployment.

---

### 20. What makes a README useful?

**My Answer:**

> READMEs are useful because the provide a context and a summary of what's going on in the repo and provide instructions on how to use/run what's in the repo.

---

### 21. Why are multiple commits better than one final commit?

**My Answer:**

> Because it shows progress and it provides a history of commits where you can go back to a certain commit/version of the code.

---

### 22. Why is professional delivery important?

**My Answer:**

> 

---
