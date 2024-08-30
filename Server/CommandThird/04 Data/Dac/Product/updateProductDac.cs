using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class UpdateProductDac : BaseCommand<int>
	{
		public Product Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				UPDATE product_yyc
				SET prod_nm = @prod_nm, price = @price, write_dt = @write_dt
				WHERE com_code = @com_code AND prod_cd = @prod_cd;
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
