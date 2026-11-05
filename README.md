# Contacts Management System 📇

A Windows Forms desktop application built with C# and SQL Server to manage contact information.

This project is part of my learning journey through the **Programming Advices roadmap by Dr. Mohammed Abu-Hadhoud**, where I practiced connecting C# applications with databases using ADO.NET.

## 🚀 About the Project

The Contacts Management System allows users to manage contact records through a simple desktop interface.

While building this project, I focused on understanding how different application layers work together and how data is transferred between a C# application and SQL Server.

The project follows **3-Tier Architecture** to keep the code organized and separate responsibilities.

<img width="1362" height="752" alt="Main Screen" src="https://github.com/user-attachments/assets/89bb0135-4516-466d-bf08-e195e2fcb28d" />
<img width="1362" height="761" alt="Add Screen" src="https://github.com/user-attachments/assets/8eae99ac-8bc6-425a-918b-22c485c84230" />



## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET Framework
- **UI:** Windows Forms (WinForms)
- **Database:** Microsoft SQL Server
- **Data Access:** ADO.NET
- **Architecture:** 3-Tier Architecture

## ✨ Features

- **Add Contacts:** Create new contact records.
- **View Contacts:** Display and search for contact information.
- **Update Contacts:** Edit existing contact details.
- **Delete Contacts:** Remove contact records.
- **Data Filtering & Sorting:** Work with DataTable, DataView, and DataSet.
- **Database Operations:** Execute SQL commands using ADO.NET.
- **SQL Injection Protection:** Use Parameterized Queries to handle user input safely.
- **Input Validation:** Validate data before performing database operations.

## 🏗️ Project Architecture

The application is divided into three main layers:

**1. Presentation Layer (PL)**

Handles the Windows Forms interface and user interactions.

**2. Business Logic Layer (BLL)**

Contains the application logic and manages communication between the presentation and data access layers.

**3. Data Access Layer (DAL)**

Handles communication with SQL Server and performs database operations using ADO.NET.

This separation makes the code easier to understand, maintain, and extend.

## 📂 Project Structure

```text
Contacts/
│
├── ContactsDataAccessLayer/
│
├── ContactsBusinessLayer/
│
└── ContactsPresentationLayer/
```

## 🎯 What I Learned

Through this project, I gained practical experience with:

- Connecting C# applications to SQL Server using ADO.NET.
- Performing CRUD operations.
- Working with DataTable, DataView, DataSet, and DataAdapter.
- Using Parameterized Queries to prevent SQL Injection.
- Understanding the responsibilities of each layer in 3-Tier Architecture.
- Organizing code and separating application responsibilities.

## 📚 Learning Source

This project was developed as part of:

**Programming Advices Roadmap — Course 18: C# & Database Connectivity (ADO.NET)**

Instructor: Dr. Mohammed Abu-Hadhoud

---

*This project represents another step in my journey toward becoming a Software Engineer, and a practical application of what I have learned so far.* 🚀
