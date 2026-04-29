# AspGodPractice - ASP.NET MVC Movie Application

A practice project built with **ASP.NET MVC 5** (targeting .NET Framework 4.7.2) to demonstrate clean architecture, repository patterns, and separation of concerns within a legacy-style web application.

---

## 🏗️ Project Architecture

This project follows a structured N-Tier approach to separate business logic from data access and the presentation layer:

- **Controllers**: Handles user requests and coordinates between Services and Views.
- **Services**: Contains business logic and orchestrates data flow.
- **Repositories**: Encapsulates data access logic using a specialized `SqlHelper`.
- **ViewModels**: Specialized objects designed for transferring data to the Views, ensuring the Domain Model is not exposed directly.
- **Utilities**: Contains shared helpers, such as `SqlHelper.cs` for database interactions.

---

## 🛠️ Tech Stack

- **Framework**: ASP.NET MVC 5 (.NET Framework 4.7.2)
- **Frontend**: Bootstrap 5, jQuery, Modernizr
- **Data Handling**: Newtonsoft.Json, ADO.NET (via SqlHelper)
- **Optimization**: Microsoft ASP.NET Web Optimization (Bundling and Minification)

---

## 📁 Directory Structure

```text
📂 AspGodPractice
├── 📂 App_Start          # Configuration (Bundles, Filters, Routes)
├── 📂 Controllers        # MoviesController.cs
├── 📂 Models             # Domain Models (Movie.cs)
├── 📂 Repositories       # Data access layer (IMovieRepository)
├── 📂 Services           # Business logic layer (IMovieService)
├── 📂 ViewModels         # UI-specific models
├── 📂 Views              # Razor templates (Index.cshtml, Layouts)
├── 📂 Utilities          # SqlHelper.cs
└── Web.config            # Application configuration
