using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
	public class ProductKey : IEntityKey
	{
		public string COM_CODE { get; set; }
		public string PROD_CD { get; set; }
	}

	public class Product : EntityBase<ProductKey>
	{
		public string PROD_NM { get; set; }
		public int PRICE { get; set; }
		public DateTime WRITE_DT { get; set; }
	}
}
