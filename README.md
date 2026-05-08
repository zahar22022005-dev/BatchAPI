# BatchAPI

## Назначение
Веб-сервис для управления партиями товаров на складе.

## Основные функции
- Получение списка всех партий (GET /api/Batch)
- Получение партии по ID (GET /api/Batch/{id})
- Добавление новой партии (POST /api/Batch)

## Примеры запросов

### GET /api/Batch
**Ответ:**
[
  { "id": 1, "productName": "Sneakers", "quantity": 100, "price": 50.0, "totalCost": 5000.0 }
]

### POST /api/Batch
**Тело запроса:**

{ "productName": "Хлеб", "quantity": 50, "price": 30.0 }
**Ответ (201 Created):**

{ "id": 3, "productName": "Хлеб", "quantity": 50, "price": 30.0, "totalCost": 1500.0 }