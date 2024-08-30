using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class DeleteItemDac : BaseCommand<int>
	{
		public ItemYyc Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				DELETE FROM flow.item
				WHERE code = @code;
			";

			var parameters = new Dictionary<string, object>() {
				{"@code", Request.CODE }
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
