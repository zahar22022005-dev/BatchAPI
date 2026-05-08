namespace BatchAPI.Models
{
    /// <summary>
    /// Модель партии товара
    /// </summary>
    public class Batch
    {
        /// <summary>
        /// Уникальный идентификатор партии
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название товара
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Количество товара в партии
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Цена за единицу товара
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Общая стоимость партии (вычисляемое поле)
        /// Формула: Quantity × Price
        /// </summary>
        public decimal TotalCost => Quantity * Price;
    }
}