using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KATALOG.model;

namespace KATALOG.model
{
    public partial class Product
    {
        public int ID_Продукты { get; set; }

        public string? Имя { get; set; }

        public string? Единица { get; set; }

        public decimal? Расходы { get; set; }

        public int? Максимальная_сумма_скидки { get; set; }

        public string? Производитель { get; set; }

        public string? Поставщик { get; set; }

        public int? Категория { get; set; }

        public int? Текущая_скидка { get; set; }

        public int? Количество_на_складе { get; set; }

        public string? Описание { get; set; }

        public string? Фото { get; set; }

        public ProductCategory FK_Product_Category { get; set; }

        //public virtual ProductCategory? CategoryNavigation { get; set; }

        //public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
