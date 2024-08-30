using System;
using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;
using System.Text;

namespace Data.Dac
{
	public class FetchProductDac : BaseCommand<List<Product>>
	{
		public FetchProductDacRequestDto Request { get; set; }
		protected override void ExecuteCore()
		{
            StringBuilder sql = new StringBuilder(
                @"
				SELECT *
				FROM product_yyc
				WHERE com_code = @com_code AND prod_cd = @prod_cd
				ORDER BY write_dt ASC
			");

            var parameters = new Dictionary<string, object>() {
				{"@com_code",  Request.ComCode},
				{"@prod_cd",  Request.ProdCd}
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Query<Product>(sql.ToString(), parameters, (reader, data) => {
				data.Key.COM_CODE = Request.ComCode;
				data.Key.PROD_CD = Request.ProdCd;
				data.PRICE = reader.GetInt32(3);
				data.PROD_NM = reader["prod_nm"].ToString();
				data.WRITE_DT = (DateTime)reader["write_dt"];
			});
		}
	}

	public class FetchProductDacRequestDto
	{
		public string ComCode { get; set; }
		public string ProdCd { get; set; }
	}
}
