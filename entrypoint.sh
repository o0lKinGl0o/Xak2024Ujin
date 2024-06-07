#!/bin/sh

# Функция для проверки доступности базы данных
wait_for_db() {
  until nc -z -v -w30 db 5432
  do
    echo "Ожидание соединение с БД..."
    sleep 1
  done
}

wait_for_db

# Указываем путь к проекту при выполнении миграций
PROJECT_PATH="/app/WebApplication3.csproj"

echo "Восстанавливаем инструменты dotnet"
dotnet tool restore

echo "Удаление существующей миграции, если она есть"
dotnet ef migrations remove --project $PROJECT_PATH --context ApplicationDbContext --force || echo "Нет существующей миграции"

echo "Создание новой миграции"
dotnet ef migrations add InitialCreate --project $PROJECT_PATH --context ApplicationDbContext
 
echo "Запуск миграций"
dotnet ef database update --project $PROJECT_PATH --context ApplicationDbContext

# Запуск основного приложения
dotnet WebApplication3.dll

