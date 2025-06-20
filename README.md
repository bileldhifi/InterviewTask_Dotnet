# 🔐 Password Manager - Backend (.NET API)

This is the backend API of the password manager built with ASP.NET Core.

## 📋 Features

- Get all passwords
- Add a new password
- Update an existing password
- Delete a password
- Password encryption support

## 🧰 Tech Stack

- ASP.NET Core Web API
- C#

## 📁 Endpoints

| Method | Endpoint              | Description             |
| ------ | --------------------- | ----------------------- |
| GET    | `/api/passwords`      | Get all passwords       |
| GET    | `/api/passwords/{id}` | Get a specific password |
| POST   | `/api/passwords`      | Add a new password      |
| PUT    | `/api/passwords/{id}` | Update a password       |
| DELETE | `/api/passwords/{id}` | Delete a password       |


## 📦 Installation

1- git clone https://github.com/bileldhifi/InterviewTask_Angular.git

2- cd InterviewTask_Dotnet

3- dotnet build

4- dotnet run
