using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class InsertProductDac : BaseCommand<int>
	{
		public Product Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				INSERT INTO product_yyc (com_code, prod_cd, prod_nm, price, write_dt)
				VALUES (@com_code, @prod_cd, @prod_nm, @price, @write_dt)
			";

			var parameters = new Dictionary<string, object>() {
				{"@com_code", Request.Key.COM_CODE },
				{"@prod_cd", Request.Key.PROD_CD },
				{"@prod_nm", Request.PROD_NM },
				{"@price", Request.PRICE },
				{"@write_dt", Request.WRITE_DT },
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
