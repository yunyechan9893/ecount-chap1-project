using Command._02_Extension;
using CommandThird._03_PipeLine;
using Data.Dac;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandThird
{
    public static class Controller
    {
        public static PipeLine pipeLine = new PipeLine();

        public static void CreateProduct(
            string comCode,
            string prodCd,
            int price,
            string prodNm
        )
        {

            int result = 0;

            pipeLine.Register<InsertProductDac, int>(new InsertProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new Product()
                        {
                            Key = new ProductKey()
                            {
                                COM_CODE = comCode,
                                PROD_CD = prodCd
                            },
                            PROD_NM = prodNm,
                            PRICE = price,
                            WRITE_DT = DateTime.Now
                        };
                    })
                    .Executed((res) => result = res);

            pipeLine.Execute();

            if (result == 1)
            {
                Console.WriteLine("등록에 성공했습니다.");
                return;
            }

            Console.WriteLine("등록에 실패했습니다.");
        }

        public static void FetchProduct(string comCode, string prodCd)
        {
            List<Product> result = new List<Product>();

            pipeLine.Register<FetchProductDac, List<Product>>(new FetchProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new FetchProductDacRequestDto()
                        {
                            ComCode = comCode,
                            ProdCd = prodCd
                        };
                    })
                    .Executed((Result) => result = Result);

            pipeLine.Execute();

            var resultText = "결과 값이 없습니다";
            if (result.vIsNotEmpty())
            {
                var product = result[0];
                resultText = $"{product.Key.COM_CODE} | {product.Key.PROD_CD} | {product.PROD_NM} | {product.PRICE} | {product.WRITE_DT}\n";
            }
            
            Console.WriteLine(resultText);
        }

        public static void SelectProduct(string comCode)
        {
            List<Product> result = new List<Product>();

            pipeLine.Register<SelectProductDac, List<Product>>(new SelectProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new SelectProductDacRequestDto()
                        {
                            ComCode = comCode,
                        };
                    })
                    .Executed((Result) => result = Result);

            pipeLine.Execute();

            StringBuilder resultText = new StringBuilder();

            foreach (Product product in result)
            {
                resultText.Append($"{product.Key.COM_CODE} | {product.Key.PROD_CD} | {product.PROD_NM} | {product.PRICE} | {product.WRITE_DT}\n");
            }

            Console.WriteLine(resultText.ToString());
        }

        public static void UpdateProduct(
            string comCode,
            string prodCd,
            int price,
            string prodNm
        )
        {
            int result = 0;

            pipeLine.Register<UpdateProductDac, int>(new UpdateProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new Product()
                        {
                            Key = new ProductKey()
                            {
                                COM_CODE = comCode,
                                PROD_CD = prodCd
                            },
                            PRICE = price,
                            PROD_NM = prodNm,
                            WRITE_DT = DateTime.Now
                        };
                    })
                    .Executed((res) => result = res);

            pipeLine.Execute();
        }

        public static void DeleteProduct(string comCode, string prodCd)
        {
            int result = 0;

            pipeLine.Register<DeleteProductDac, int>(new DeleteProductDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new Product()
                        {
                            Key = new ProductKey()
                            {
                                COM_CODE = comCode,
                                PROD_CD = prodCd
                            }
                        };
                    })
                    .Executed((res) => result = res);

            pipeLine.Execute();
        }

        public static void SelectSale(string comCode, string orderBySaleCode, string orderByQuantity)
        {
            List<Sale> result = new List<Sale>();

            pipeLine.Register<SelectSaleDac, List<Sale>>(new SelectSaleDac())
                   .AddFilter((cmd) => true)
                   .Mapping((cmd) =>
                   {
                       cmd.Request = new SelectSaleDacRequestDto()
                       {
                           ComCode = comCode
                       };
                   })
                   .Executed((res) => result = res);

            pipeLine.Execute();

            StringBuilder resultText = new StringBuilder();

            foreach (Sale sale in result)
            {
                resultText.Append($"{sale.Key.COM_CODE} | {sale.Key.IO_DATE} | {sale.Key.IO_NO} | {sale.PROD_CD} | {sale.QTY} | {sale.REMARKS} | {sale.WRITE_DT}\n");
            }

            Console.WriteLine(resultText.ToString());
        }

        public static void FetchSale(string comCode, string ioDate, int ioNo, string orderBySaleCode, string orderByQuantity)
        {
            List<Sale> result = new List<Sale>();

            pipeLine.Register<FetchSaleDac, List<Sale>>(new FetchSaleDac())
                   .AddFilter((cmd) => true)
                   .Mapping((cmd) =>
                   {
                       cmd.Request = new FetchSaleDacRequestDto()
                       {
                           ComCode = comCode,
                           IoDate = ioDate,
                           IoNo = ioNo
                       };

                       switch (orderBySaleCode)
                       {
                           case "1":
                               cmd.orders.Add(new Order<string>("qty", OrderType.asc));
                               break;
                           case "2":
                               cmd.orders.Add(new Order<string>("qty", OrderType.desc));
                               break;
                           default:
                               break;
                       }

                       switch (orderByQuantity)
                       {
                           case "1":
                               cmd.orders.Add(new Order<string>("com_code", OrderType.asc));
                               break;
                           case "2":
                               cmd.orders.Add(new Order<string>("com_code", OrderType.desc));
                               break;
                           default:
                               break;
                       }
                   })
                   .Executed((res) => result = res);

            pipeLine.Execute();

            StringBuilder resultText = new StringBuilder();

            foreach (Sale sale in result)
            {
                resultText.Append($"{sale.Key.COM_CODE} | {sale.Key.IO_DATE} | {sale.Key.IO_NO} | {sale.PROD_CD} | {sale.QTY} | {sale.REMARKS} | {sale.WRITE_DT}\n");
            }

            Console.WriteLine(resultText.ToString());
        }


        public static void CreateSale(
            string comCode,
            string ioDate,
            int ioNo,
            string prodCd,
            int qty,
            string remarks
        )
        {
            int result;



            pipeLine.Register<InsertSaleDac, int>(new InsertSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new Sale()
                        {
                            Key = new SaleKey()
                            {
                                COM_CODE = comCode,
                                IO_DATE = ioDate,
                                IO_NO = ioNo,
                            },
                            PROD_CD = prodCd,
                            QTY = qty,
                            REMARKS = remarks
                        };
                    })
                    .Executed((res) => result = res);

            pipeLine.Execute();
        }

        public static void UpdateSale(
            string comCode,
            string ioDate,
            int ioNo,
            string prodCd,
            int qty,
            string remarks
        )
        {
            int result = 0;

            pipeLine.Register<UpdateSaleDac, int>(new UpdateSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new Sale()
                        {
                            Key = new SaleKey()
                            {
                                COM_CODE = comCode,
                                IO_DATE = ioDate,
                                IO_NO = ioNo
                            },
                            PROD_CD = prodCd,
                            QTY = qty,
                            REMARKS = remarks
                        };
                    })
                    .Executed((res) => result = res);

            pipeLine.Execute();
        }

        public static void DeleteSale(string comCode, string ioDate, int ioNo)
        {
            int result = 0;

            pipeLine.Register<DeleteSaleDac, int>(new DeleteSaleDac())
                    .AddFilter((cmd) => true)
                    .Mapping((cmd) =>
                    {
                        cmd.Request = new Sale()
                        {
                            Key = new SaleKey()
                            {

                                COM_CODE = comCode,
                                IO_DATE = ioDate,
                                IO_NO = ioNo
                            }
                        };
                    })
                    .Executed((res) => result = res);

            pipeLine.Execute();
        }
    }
}
