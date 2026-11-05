\# Contacts Management Application 📇



A robust desktop application built for managing contacts efficiently, developed as part of my journey mastering C# and database connectivity through the Programming Advices roadmap.



\---



\## 🚀 About the Project

This project is a multi-tier Windows Forms desktop application designed to handle contact records seamlessly\[cite: 6]. It bridges the gap between local application logic and a relational SQL Server database using \*\*ADO.NET\*\*, implementing clean and professional software engineering principles.



\---



\## 🛠️ Built With

\* \*\*Language:\*\* C# (.NET Framework)\[cite: 6]

\* \*\*UI Framework:\*\* Windows Forms (WinForms)\[cite: 6]

\* \*\*Data Access Layer:\*\* ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `DataSet`, `DataTable`)\[cite: 6]

\* \*\*Database:\*\* Microsoft SQL Server\[cite: 6]

\* \*\*Architecture:\*\* 3-Tier Architecture\[cite: 6]



\---



\## 📐 Architecture \& Design

The project strictly follows the \*\*3-Tier Architecture\*\* pattern to ensure separation of concerns, maintainability, and scalability:

1\. \*\*Presentation Layer (PL):\*\* Windows Forms interface handling user interaction, form navigation, and input validation\[cite: 6].

2\. \*\*Business Logic Layer (BLL):\*\* Manages the application rules, entity validations, and data processing logic\[cite: 6].

3\. \*\*Data Access Layer (DAL):\*\* Direct communication with the SQL Server database, executing secure CRUD operations and queries\[cite: 6].



\---



\## ✨ Features

\* \*\*Full CRUD Operations:\*\* Add, view, update, and delete contact records efficiently.

\* \*\*Data Management:\*\* Utilizes `DataTable`, `DataView`, and `DataSet` for local data filtering, sorting, and manipulation\[cite: 6].

\* \*\*Security \& Best Practices:\*\* Implements \*\*Parameterized Queries\*\* to protect against SQL Injection\[cite: 6].

\* \*\*Robust Error Handling:\*\* Structured exception handling and data integrity validation across layers\[cite: 6].



\---



\## 📂 Project Structure

```text

Contacts/

│

├── ContactsDataAccessLayer/   # Database connection and SQL execution

├── ContactsBusinessLayer/     # Business rules and entity logic

└── ContactsPresentationLayer/ # Windows Forms UI and user interactions

