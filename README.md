# Load Shedding Middleware (.NET 10)

## 📌 Overview

This project demonstrates a custom **load shedding middleware** implemented in ASP.NET Core (.NET 10).
The system limits the number of concurrent HTTP requests to protect the server from overload.

It also includes an Aspire-based orchestration setup for running and monitoring the application.

---

## 🧠 Concept

**Load Shedding** is a technique used in distributed systems to:

* Prevent server overload
* Reject or delay excessive requests
* Maintain system stability under high load

This project implements:

* **Concurrency limiting**
* **Optional queue with timeout (SemaphoreSlim)**
* **Fail-fast strategy (HTTP 503)**

---

## 📦 Project Structure

* **LoadShedding.Api**
  Main Web API project with endpoints and middleware integration.

* **LoadShedding.Middleware**
  Contains load shedding logic and configuration.

* **LoadShedding.AppHost**
  Aspire orchestrator for running and monitoring the system.

* **LoadShedding.ServiceDefaults**
  Default configuration (logging, telemetry).

---

## ⚙️ Configuration

`appsettings.json`

```json
{
  "LoadShedding": {
    "MaxConcurrentRequests": 2
  }
}
```

* `MaxConcurrentRequests` — maximum number of requests processed simultaneously

---

## 🚀 Running the project

```bash
dotnet build
dotnet run --project LoadShedding.AppHost
```

---

## 🌐 Endpoints

* `/` — health check
* `/test` — simulated slow request (delay)

Example:

```
https://localhost:xxxx/test
```

---

## 🧪 Testing Load Shedding

1. Open multiple browser tabs or send concurrent requests
2. When the limit is exceeded, the server returns:

```
503 Service Unavailable
Too many requests
```
