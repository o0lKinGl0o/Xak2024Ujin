# Используем базовый образ для .NET SDK для сборки
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Копируем проект и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем остальные файлы и собираем проект
COPY . ./
RUN dotnet publish -c Debug -o out

# Стадия выполнения
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Устанавливаем необходимые инструменты и зависимости
RUN apt-get update && apt-get install -y netcat-openbsd

# Устанавливаем Entity Framework CLI
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

# Копируем артефакты сборки из предыдущей стадии
COPY --from=build-env /app/out .
# Копируем исходные файлы проекта для выполнения миграций
COPY --from=build-env /app .

# Копируем сертификат
COPY certificate.pfx .

# Копируем скрипт запуска и делаем его исполняемым
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh

# Указываем команду для запуска приложения
ENTRYPOINT ["./entrypoint.sh"]


