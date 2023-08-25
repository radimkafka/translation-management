App can be run either from docker compose or manualy starting backend and frontend.

# Docker compose

docker compose up

# Manualy

Open two terminals(one for backend and one for frontend) in repo root.

Api will run on localhost:5000 and frontend on localhost:5173

## Backend

- dotnet run --project .\backend\TranslationManagement.Api\TranslationManagement.Api.csproj

## Frontend

- cd frontend
- npm ci
- npm run dev
