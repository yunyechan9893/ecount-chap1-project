using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;

namespace Data.Dac
{
	public class InserItemDac : BaseCommand<int>
	{
		public ItemYyc Request { get; set; }
		protected override void ExecuteCore()
		{
			var sql = @"
				INSERT INTO flow.item (code, name)
				VALUES (@code, @name)
			";

			var parameters = new Dictionary<string, object>() {
				{"@code", Request.CODE },
				{"@name", Request.NAME }
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Execute(sql, parameters);
		}
	}
}
