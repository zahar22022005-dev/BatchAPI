FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем файл проекта и восстанавливаем зависимости
COPY BatchAPI.csproj .
RUN dotnet restore "BatchAPI.csproj"

# Копируем ВСЕ остальные файлы проекта
COPY . .

# Публикуем приложение в папку /app/publish
RUN dotnet publish "BatchAPI.csproj" -c Release -o /app/publish --no-restore

# Образ для запуска (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Копируем собранное приложение из образа сборки
COPY --from=build /app/publish .

# Открываем порт (Render требует 8080)
EXPOSE 8080

# ОБЯЗАТЕЛЬНО: заставляем приложение слушать порт 8080 на всех интерфейсах
ENV ASPNETCORE_URLS=http://+:8080

# Точка входа
ENTRYPOINT ["dotnet", "BatchAPI.dll"]
