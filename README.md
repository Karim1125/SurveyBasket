# Survey Basket

SurveyBasket – Backend API

A modular, scalable backend designed for building, managing, and analyzing surveys.

SurveyBasket is a clean, maintainable backend system that enables creating surveys, managing questions and options, collecting participants' votes, and retrieving aggregated results. The architecture emphasizes clarity, separation of concerns, and strong domain modeling — making the system easy to extend and integrate.

## 🚀 Features

### 📝 Survey Management

- Create, update, retrieve, and delete surveys.
- Associate surveys with multiple questions.
- Status handling (e.g., active/inactive depending on your business logic).
- Metadata support such as titles and descriptions.

### ❓ Question Management

- Add questions to surveys.
- Update or remove existing questions.
- Associate options with each question as needed.

### 🔠 Option Management

- Add selectable options for questions.
- Update or delete options.
- Maintain option order.

### 🗳 Vote Collection

- Submit participants’ answers to surveys.
- Store responses in a structured, relational format.
- Support different question types through dedicated entities.

### 📊 Results & Aggregation

- Retrieve survey results.
- View aggregated vote counts.
- Summaries of answers per question.

### 🧱 Clean Project Architecture

SurveyBasket follows a layered, maintainable structure:

- **Controllers** → API endpoint layer  
- **DTOs** → Request/response shaping  
- **Services** → Business logic  
- **Persistence Layer** → EF Core DbContext, configurations, migrations  
- **Entities** → Core domain modeling  

This structure ensures testability, maintainability, and clean responsibility boundaries.

## 🏗 Project Structure

```

SurveyBasket/
│
├── SurveyBasket.API/
│   ├── Controllers/
│   │   ├── SurveyController.cs
│   │   ├── QuestionController.cs
│   │   ├── OptionController.cs
│   │   ├── VoteController.cs
│   │   └── ResultController.cs
│   │
│   ├── DTOs/
│   │   ├── SurveyDTOs/
│   │   ├── QuestionDTOs/
│   │   ├── OptionDTOs/
│   │   ├── VoteDTOs/
│   │   └── ResultDTOs/
│   │
│   ├── Mapping/
│   │   └── MappingConfigurations.cs
│   │
│   ├── Persistence/
│   │   ├── ApplicationDbContext.cs
│   │   ├── Entities/
│   │   ├── EntitiesConfigurations/
│   │   └── Migrations/
│   │
│   ├── Services/
│   │   ├── SurveyService.cs
│   │   ├── QuestionService.cs
│   │   ├── OptionService.cs
│   │   ├── VoteService.cs
│   │   └── ResultService.cs
│   │
│   ├── Properties/
│   │   └── launchSettings.json
│   │
│   └── Program.cs
│
└── SurveyBasket.slnx

```

## 🧬 Domain Model Overview

### **Survey**

Represents a full survey, containing:

- Title
- Description
- List of questions
- Relationships to votes/responses

### **Question**

- Text
- Type (depending on your entity design)
- Options (if applicable)

### **Option**

- Text
- Ordering
- Associated Question

### **Vote & VoteAnswer**

- A vote represents a participant’s submission.
- VoteAnswer stores the actual response per question.

### **Result**

- Aggregated statistics returned by the system.
- Computed via `ResultService` and exposed via `ResultController`.

## 🌐 API Endpoints

### **Survey Endpoints**

```

GET    /api/surveys
GET    /api/surveys/{id}
POST   /api/surveys
PUT    /api/surveys/{id}
DELETE /api/surveys/{id}

```

### **Question Endpoints**

```

POST   /api/surveys/{surveyId}/questions
PUT    /api/questions/{id}
DELETE /api/questions/{id}

```

### **Option Endpoints**

```

POST   /api/questions/{questionId}/options
PUT    /api/options/{id}
DELETE /api/options/{id}

```

### **Vote Endpoints**

```

POST /api/votes

```

### **Result Endpoints**

```

GET /api/results/{surveyId}

```

Returns aggregated results for a given survey.

## 🗄 Database & Persistence

The project uses Entity Framework Core and a structured Persistence layer including:

- `ApplicationDbContext`
- Entity configurations per table
- Migrations
- Navigation relationships for surveys, questions, options, votes, and answers

The configuration is clean, explicit, and ready for scalable relational structure.

## ▶ Getting Started

### 1. Restore Dependencies

```

dotnet restore

```

### 2. Apply Migrations

```

dotnet ef database update

```

### 3. Run the API

```

dotnet run --project SurveyBasket.API

```

The API will start on the port defined in `launchSettings.json`.

## 🧪 Testing

The project follows a testable architecture with clean separation of services and controllers, enabling easy implementation of:

- Unit tests for services
- Integration tests for controllers
- In-memory EF Core testing support

## 📄 License

This project is owned by its creator and may be licensed or distributed as needed.
