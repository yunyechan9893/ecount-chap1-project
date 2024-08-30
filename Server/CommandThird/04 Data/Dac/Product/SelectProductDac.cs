using System;
using System.Collections.Generic;
using CommandThird._01_Command;
using Data.Db;
using Data.Entity;
using System.Text;

namespace Data.Dac
{
	public class SelectProductDac : BaseCommand<List<Product>>
	{
		public SelectProductDacRequestDto Request { get; set; }
		protected override void ExecuteCore()
		{
            StringBuilder sql = new StringBuilder(
                @"
				SELECT *
				FROM product_yyc
				WHERE com_code = @com_code
				ORDER BY write_dt ASC
			");

            var parameters = new Dictionary<string, object>() {
				{"@com_code",  Request.ComCode}
			};

			var dbManager = new DbManager();
			this.Output = dbManager.Query<Product>(sql.ToString(), parameters, (reader, data) => {
				data.Key.COM_CODE = Request.ComCode;
				data.Key.PROD_CD = reader["prod_cd"].ToString();
                data.PRICE = reader.GetInt32(3);
				data.PROD_NM = reader["prod_nm"].ToString();
				data.WRITE_DT = (DateTime)reader["write_dt"];
			});
		}
	}

	public class SelectProductDacRequestDto
	{
		public string ComCode { get; set; }

        public static implicit operator SelectProductDacRequestDto(FetchProductDacRequestDto v)
        {
            throw new NotImplementedException();
        }
    }
}
