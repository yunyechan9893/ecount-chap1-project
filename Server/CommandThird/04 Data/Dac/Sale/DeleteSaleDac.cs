using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class DeleteSaleDac : BaseCommand<int>
	{
		public Sale Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				DELETE FROM flow.sale_yyc
				WHERE date = @date AND number = @number;
			";

			var parameters = new Dictionary<string, object>() {
				{"@date", Request.Key.DATE },
				{"@number", Request.Key.NUMBER }
            };

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
