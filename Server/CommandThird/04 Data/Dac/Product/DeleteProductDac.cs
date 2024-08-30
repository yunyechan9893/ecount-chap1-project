using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class DeleteProductDac : BaseCommand<int>
	{
		public Product Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				DELETE FROM product_yyc
				WHERE com_code = @com_code AND prod_cd = @prod_cd;
			";

			var parameters = new Dictionary<string, object>() {
				{"@com_code", Request.Key.COM_CODE },
				{"@prod_cd", Request.Key.PROD_CD }
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
